using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
namespace Character_movement
{
    public partial class Dungeon : Form
    {
        public Player player;
        private Barrier[] barrier;
        private TreasureChest tchest;
        public Dungeon()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            Paint += Form1_Paint;
            MouseClick += Form1_Click;
            MouseMove += Form1_MouseMove;
            barrier = new Barrier[100];
            
        }
        Image backbuffer;
        int clientwidth;//controls the form window width
        int clientheight;//controls the form window height
        PictureBox Hero = new PictureBox();//creates the hero picturebox
        PictureBox stairs = new PictureBox();
       
        int[] chestarray = new int[10];
        PictureBox background = new PictureBox();//creates the background picturebox
        bool isrunning = true;
        int mousex;
        int mousey;
        int herox=10;//location of heroes x point
        int heroy=10;//locataion of heroes y point
        int frame = 0;
        int walkcheck = 0;
        int randomNumber;
        int herobase = 1;
        int[] boardarray = new int[100];
        int boardvalue=0;
        int tempx;
        int tempy;
        int pass;
        int treasuretot = 0;
        //Medium speed: movespeed =2/movespeedanim=350 
        //Fast speed: movespeed =5/movespeedanim=50 
        // instant: movespeed =50/movespeedanim=1

        int test1;
        combat combatform = new combat();
        int movespeed = 5;
        int movespeedanim = 50;
        Bitmap walkdown1 = new Bitmap(Properties.Resources.walkdown1);
        Bitmap walkdown2 = new Bitmap(Properties.Resources.walkdown2);
        Bitmap walkdown3 = new Bitmap(Properties.Resources.walkdown3);
        Bitmap walkleft1 = new Bitmap(Properties.Resources.walkleft1);
        Bitmap walkleft2 = new Bitmap(Properties.Resources.walkleft2);
        Bitmap walkleft3 = new Bitmap(Properties.Resources.walkleft3);
        Bitmap walkright1 = new Bitmap(Properties.Resources.walkright1);
        Bitmap walkright2 = new Bitmap(Properties.Resources.walkright2);
        Bitmap walkright3 = new Bitmap(Properties.Resources.walkright3);
        Bitmap walkup1 = new Bitmap(Properties.Resources.walkup1);
        Bitmap walkup2 = new Bitmap(Properties.Resources.walkup2);
        Bitmap walkup3 = new Bitmap(Properties.Resources.walkup3);
        Bitmap stonebackground = new Bitmap(Properties.Resources.Floor_trial34);
        Random random = new Random();
        int[] testarray = new int[100];

        
        Bitmap horzwall = new Bitmap(Properties.Resources.horzontalwall);
        Bitmap fourwall = new Bitmap(Properties.Resources.fourwall);

        Bitmap rightcap = new Bitmap(Properties.Resources.horzrightcap);
        Bitmap leftcap = new Bitmap(Properties.Resources.horzleftcap);
        Bitmap bottomcap = new Bitmap(Properties.Resources.vertbottomcap );
        Bitmap topcap = new Bitmap(Properties.Resources.verttopcap);

        Bitmap rightchest1 = new Bitmap(Properties.Resources.tchestrt1);
        Bitmap rightchest2 = new Bitmap(Properties.Resources.tchestrt2);
        Bitmap rightchest3 = new Bitmap(Properties.Resources.tchestrt3);
        Bitmap rightchest4 = new Bitmap(Properties.Resources.tchestrt4);

        Bitmap stairsdown = new Bitmap(Properties.Resources.stairsdown);
       
        Pen Red = new System.Drawing.Pen(System.Drawing.Color.Red);
        Pen yellow = new System.Drawing.Pen(System.Drawing.Color.Yellow);
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            clientwidth = 800;
            clientheight = 520;
            this.ClientSize = new Size(clientwidth, clientheight);
            Hero.Location = new Point(herox, heroy);
            Hero.Size = new Size(50, 50);
            Hero.Image = walkdown1;
            Controls.Add(Hero);
            Hero.BackColor = Color.Transparent;
            player = new Player(50, 10, 20, 0, 1);
            createboard();
            combatform.Visible = false;
            GameLoop();
        }
        private void GameLoop()
        {
            backbuffer = new Bitmap(clientwidth, clientheight);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            while (isrunning == true)
            {
                Application.DoEvents();
                this.Invalidate();
                this.Update();
                this.Refresh();
            }
        }
        private void Form1_Click(object sender, System.EventArgs e)
        {
            if(mousex>=685 & mousex  <=760 & mousey>=10 &mousey<=30 )
            {
                for (int i=0;i<100;i++)
                {
                    testarray[i] = 0;
                    boardarray[i] = 0;
                }
                createboard();
            }
        }
        public void reinit()
        {
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
        public void clearall()
        {
            for (int i = 0; i < barrier.Length; i++)
            {
                if (barrier[i] != null)
                {
                    Controls.Remove(barrier[i].barrier);
                    Controls.Remove(tchest.treasurechest);
                }
            }
            herox = 10;
            heroy = 10;
            boardvalue = 0;
            walkcheck = 0;
            Hero.Location = new Point(herox, heroy);
        }
        private void createboard()
        {
            clearall();
            for (int i = 11; i < boardarray.Length - 10; i++)
            {
                randomNumber = random.Next(1, 7);
                boardarray[i] = randomNumber;
            }
            boardarray[99] = 0;
            Controls.Remove(stairs);
            treasuretot = random.Next(1, 5);
            findfives();
            placechest();
        }
        private void placechest()
        {
            int boardarrayx = 10;
            int boardarrayy = 10;
        if (treasuretot > 0)
            {
                randomNumber = random.Next(1, 100);
                if (boardarray[randomNumber] != 5)
                {
                    boardarray[randomNumber] = 100;
                    boardarray[0] = 0;
                    for (int i = 0; i < 99; i++)
                    {
                        if (boardarray[i] == 100)
                        {
                            treasuretot -= 1;
                            tchest = new TreasureChest(boardarrayx, boardarrayy);
                            tchest.treasurechest.Image = rightchest1;
                            Controls.Add(tchest.treasurechest);
                        }
                        boardarrayx += 50;
                        if (i == 9 || i == 19 || i == 29 || i == 39 || i == 49 || i == 59 || i == 69 || i == 79 || i == 89)
                        {
                            boardarrayx = 0;
                            boardarrayy += 50;
                        }
                      }
                }
                else
                {
                placechest();
                }
             }
            else 
            {
                stairs.Image = stairsdown;
                stairs.BackColor = Color.Transparent;
                boardarray[99] =9999;
                Controls.Add(stairs);
                stairs.Location = new Point(460, 460);
            }
          }
        
        private void findfives()
        {
            test1 = 0;
            int boardarrayx = 10;
            int boardarrayy = 10;
            for (int i = 0; i < 99; i++)
            {
                if (boardarray[i] == 5)
                {
                    test1 += 1;
                    barrier[i] = new Barrier( boardarrayx + 10, boardarrayy);
                    Controls.Add(barrier[i].barrier);
                    barrier[i].barrier.Image = fourwall;
                    randomNumber = random.Next(1, 4);
                }
                boardarrayx += 50;
                if (i == 9 || i == 19 || i == 29 || i == 39 || i == 49 || i == 59 || i == 69 || i == 79 || i == 89)
                {
                    boardarrayx = 0;
                    boardarrayy += 50;
                }
            }
}
        private void rewardchest()
        {
            Controls.Remove(stairs);
            Controls.Remove(tchest.treasurechest);
            boardarray[boardvalue+ pass] = 0;
            placechest();
        }
        private void checkenemy()
        {
            randomNumber = random.Next(1, 100);
            if(randomNumber >70)
            {
              combatform.Visible = true;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D && walkcheck != 1)
                {
                if (herox == 460||boardarray[boardvalue+1 ]==5 )
                    {  }
                else if(boardarray[boardvalue + 1] == 9999)
                    {
                    createboard();
                    }
                else if (boardarray[boardvalue+1]==100)
                    {
                    pass = 1;
                    chestanim.Interval = 10;
                    chestanim.Start();
                    }

                else
                {
                   boardvalue += 1;
                   walkcheck = 1;
                   KeyDown -= new KeyEventHandler(Form1_KeyDown);
                   moveright.Interval = 1;
                   moverightanim.Interval = movespeedanim;
                   moverightanim.Start();
                   moveright.Start();
                    
                 }
        }
                if (e.KeyCode == Keys.A && walkcheck != 1)
                {
                    if (herox == 10 || boardarray[boardvalue-1] == 5 )
                        {}
                    else if (boardarray[boardvalue - 1] == 9999)
                    {
                    createboard();
                    }
                    else if (boardarray[boardvalue - 1] == 100)
                    {
                    pass = -1;
                    chestanim.Interval = 10;
                    chestanim.Start();
                    }
                else
                    {
                    boardvalue -= 1;
                    walkcheck = 1;
                        KeyDown -= new KeyEventHandler(Form1_KeyDown);
                        moveleft.Interval = 1;
                        moveleftanim.Interval = movespeedanim;
                        moveleftanim.Start();
                        moveleft.Start();
                    }
                }

            if (e.KeyCode == Keys.W && walkcheck != 1)
                {
                if (heroy == 10 || boardarray[boardvalue-10] == 5 )
                    { }
                else if (boardarray[boardvalue -10] == 9999)
                {
                    createboard();
                }
                else if (boardarray[boardvalue - 10] == 100)
                {
                    pass = -10;
                    chestanim.Interval = 10;
                    chestanim.Start();
                }
                else
                    {
                    boardvalue -= 10;
                    walkcheck = 1;
                        KeyDown -= new KeyEventHandler(Form1_KeyDown);
                        moveup.Interval = 1;
                        moveupanim.Interval = movespeedanim;
                        moveupanim.Start();
                        moveup.Start();
                    }
                }

            if (e.KeyCode == Keys.S && walkcheck != 1)
                {
                if (heroy == 460 || boardarray[boardvalue+10] == 5 )
                    {  }
                else if (boardarray[boardvalue + 10] == 9999)
                {
                    createboard();
                }
                else if (boardarray[boardvalue + 10] == 100)
                {
                    pass = 10;
                    chestanim.Interval = 10;
                    chestanim.Start();
                }
                else
                    {
                    boardvalue += 10;
                    walkcheck = 1;
                        KeyDown -= new KeyEventHandler(Form1_KeyDown);
                        movedown.Interval = 1;
                        movedownanim.Interval = movespeedanim;
                        movedownanim.Start();
                        movedown.Start();
                    }
                }
            }
        
      
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousex = e.X;
            mousey = e.Y;
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
           
            e.Graphics.DrawImage(stonebackground, 11, 11, 499, 499);
            e.Graphics.DrawString("X." + herox + "\r\n" + "Y." + heroy, this.Font, Brushes.Yellow, 460, 100);
            e.Graphics.DrawString("X." + mousex + "\r\n" + "Y." + mousey, this.Font, Brushes.GreenYellow, 460, 0);

            e.Graphics.DrawRectangle(Red, new Rectangle(685,  10, 75, 20));
            e.Graphics.DrawString("New Board" , this.Font, Brushes.Yellow,  690, 15);
            for (int i = 0; i < 99; i++)
            {
             tempx += 50;
                if (i == 9 || i == 19 || i == 29 || i == 39 || i == 49 || i == 59 || i == 69 || i == 79 || i == 89 || i == 99)
                {
                    tempy += 50;
                    tempx = 0;
                }
               }
            tempy = 0;
            tempx = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    e.Graphics.DrawRectangle(Red, new Rectangle(tempx + 10, tempy + 10, 50, 50));
                    tempx += 50;
                }
                tempy += 50;
                tempx = 0;
            }



            if (mousex >=10 && mousex <=60 && mousey <=60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(10, 10, 50, 50));
            }
            if (mousex >= 61 && mousex <= 100 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(60, 10, 50, 50));
            }
            if (mousex >= 101 && mousex <= 150 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(110, 10, 50, 50));
            }
            if (mousex >= 151 && mousex <= 210 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(160, 10, 50, 50));
            }
            if (mousex >= 211 && mousex <= 260 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(210, 10, 50, 50));
            }
            if (mousex >= 261 && mousex <= 310 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(260, 10, 50, 50));
            }
            if (mousex >= 311 && mousex <= 360 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(310, 10, 50, 50));
            }
            if (mousex >= 361 && mousex <= 410 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(360, 10, 50, 50));
            }
            if (mousex >= 411 && mousex <= 460 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(410, 10, 50, 50));
            }
            if (mousex >= 461 && mousex <= 500 && mousey <= 60)
            {
                e.Graphics.DrawRectangle(yellow, new Rectangle(460, 10, 50, 50));
            }
        }
   
        private void movedown_Tick(object sender, EventArgs e)
        {
            if (herobase <=49)
            {
                heroy += movespeed;
                Hero.Location = new Point(herox, heroy);
                if(herobase==0)
                {
                    Hero.Image = walkdown1;
                }
                herobase += movespeed;
            }
            
            else
            {
                movedown.Stop();
                herobase = 0;
                KeyDown += new KeyEventHandler(Form1_KeyDown);
                checkenemy();
            }
            
        }
         private void movedownanim_Tick(object sender, EventArgs e)
        {
            if (frame == 0)
            {
               Hero.Image = walkdown1;
                frame = 1;
            }
            else if (frame == 1)
            {
                Hero.Image = walkdown2;
                frame = 2;
            }
            else if (frame == 2)
            {
                Hero.Image = walkdown3;
                frame = 3;
            }
            else
            { 
                Hero.Image = walkdown2;
                frame = 0;
                movedownanim.Stop();
            walkcheck = 0;
            }
        }


        private void moveup_Tick(object sender, EventArgs e)
        {
            if (herobase <=49)
            {
                heroy -= movespeed;
                Hero.Location = new Point(herox, heroy);
                if (herobase==0)
                {
                    Hero.Image = walkup1;
                }
                herobase += movespeed;
            }
            else
            {
                moveup.Stop();
                herobase =0;
                KeyDown += new KeyEventHandler(Form1_KeyDown);
                checkenemy();
            }
            
        }
        private void moveupanim_Tick(object sender, EventArgs e)
        {
           
            if (frame == 0)
            {
               Hero.Image = walkup1;
                frame = 1;
            }
            else if (frame == 1)
            {
                Hero.Image = walkup2;
                frame = 2;
            }
            else if (frame == 2)
            {
                Hero.Image = walkup3;
                frame = 3;
            }
            else
            {
                Hero.Image = walkup2;
                frame = 0;
                moveupanim.Stop();
                walkcheck = 0;
            }
        }

        private void moveright_Tick(object sender, EventArgs e)
        {
            if (herobase <= 49)
            {
                herox += movespeed;
                Hero.Location = new Point(herox, heroy);
                if (herobase == 0)
                {
                    Hero.Image = walkright1;
                }
                herobase += movespeed;
            }
            else
            {
                moveright.Stop();
                herobase = 0;
                KeyDown += new KeyEventHandler(Form1_KeyDown);
                checkenemy();
            }
            
        }
        private void moverightanim_Tick(object sender, EventArgs e)
        {
            if (frame == 0)
            {
               
                Hero.Image = walkright1;
                frame = 1;
            }
            else if (frame == 1)
            {
                Hero.Image = walkright2;
                frame = 2;
            }
            else if (frame == 2)
            {
                Hero.Image = walkright3;
                frame = 3;
            }
            else
            {
                Hero.Image = walkright2;
                frame = 0;
                moverightanim.Stop();
                walkcheck = 0;
            }
        }

        private void moveleft_Tick(object sender, EventArgs e)
        {
            if (herobase <= 49)
            {
                herox -= movespeed;
                Hero.Location = new Point(herox, heroy);
                if(herobase==0)
                {
                    Hero.Image = walkleft1;
                }
                herobase += movespeed;
            }
            else
            {
                moveleft.Stop();
                herobase = 0;
                KeyDown += new KeyEventHandler(Form1_KeyDown);
                checkenemy();
            }
           
        }

        private void moveleftanim_Tick(object sender, EventArgs e)
        {
            if (frame == 0)
            {
                Hero.Image = walkleft1;
                frame = 1;
            }
            else if (frame == 1)
            {
                Hero.Image = walkleft2;
                frame = 2;
            }
            else if (frame == 2)
            {
                Hero.Image = walkleft3;
                frame = 3;
            }
            else
            {
                Hero.Image = walkleft2;
                frame = 0;
                moveleftanim.Stop();
                walkcheck = 0;
            }
        }

        private void chestanim_Tick(object sender, EventArgs e)
        {
            if (frame == 0)
            {
                chestanim.Interval = 300;
                tchest.treasurechest.Image = rightchest1;
                frame = 1;
            }
            else if (frame == 1)
            {
                tchest.treasurechest.Image = rightchest2;
                frame = 2;
            }
            else if (frame == 2)
            {
                tchest.treasurechest.Image = rightchest3;
                frame = 3;
            }
            else
            {
                tchest.treasurechest.Image = rightchest4;
                frame = 0;
                chestanim.Stop();
                rewardchest();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
