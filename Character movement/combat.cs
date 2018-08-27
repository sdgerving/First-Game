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
    
    public partial class combat : Form
    {
        public Player player;
        public Weapon currentweapon;
        private Monster currentMonster;
        private Barrier creature;

        Pen Red = new System.Drawing.Pen(System.Drawing.Color.Red);
        Pen yellow = new System.Drawing.Pen(System.Drawing.Color.Yellow);
        int frame = 0;
        Random random = new Random();
        Image backbuffer;
        PictureBox Hero = new PictureBox();//creates the hero picturebox
        PictureBox background = new PictureBox();//creates the background picturebox
        int clientwidth;//controls the form window width
        int clientheight;//controls the form window height
        bool isrunning = true;
        int mousex;
        int mousey;
        int tracking;
        int randomNumber;
        int attacker=0;
        int defender=0;

        Weapon currentWeapon = new Weapon(World.ITEM_ID_RUSTY_SWORD, "Rusty sword", "Rusty swords", 0, 5);

        float currentsize;
            
        public combat()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            MouseMove += Form1_MouseMove;
            MouseClick += Form1_Click;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.VisibleChanged += new EventHandler(this.combat2);



        }
        private void combat2(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                onload();
            }
        }
        private void Form1_Click(object sender, System.EventArgs e)
        {
            if (mousex >= 685 & mousex <= 760 & mousey >= 10 & mousey <= 30)
            {
                Controls.Remove(creature.barrier);
                this.Visible = false; 
            }
            if (mousex >= 685 & mousex <= 760 & mousey >= 40 & mousey <= 60)
            {
                //attackroll();
            }
        }
        private void combat_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            clientwidth = 800;
            clientheight = 520;
            this.ClientSize = new Size(clientwidth, clientheight);
            this.Activate();
            this.BackColor = System.Drawing.Color.Black;
        }
        public void onload()
        {
            randomNumber = random.Next(1, 4);
            
            Monster standardMonster = World.MonsterByID(randomNumber);
            currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaximumDamage, standardMonster.MinimumDamage,
            standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoint, standardMonster.MaximumHitPoints,
            standardMonster.creatureImage);

            string imageName = standardMonster.creatureImage;
            object O = Properties.Resources.ResourceManager.GetObject(imageName); 
            creature = new Barrier(615,55);
            creature.barrier.Image = (Image)O;
            Controls.Add(creature.barrier);

            foreach (LootItem lootItem in standardMonster.LootTable)
            {
                currentMonster.LootTable.Add(lootItem);
            }
            this.BringToFront();
            GameLoop();
        }
        public static Bitmap GetImageByName(string imageName)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name +"Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);

            return (Bitmap)rm.GetObject(imageName);
            
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
                populate();
                
            }
        }
        private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousex = e.X;
            mousey = e.Y;
        }
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawString("X." + mousex + "\r\n" + "Y." + mousey, this.Font, Brushes.GreenYellow, 500, 0);
            e.Graphics.DrawRectangle(Red, new Rectangle(300, 215, 75, 20));
            e.Graphics.DrawString("Exit", this.Font, Brushes.Yellow, 315, 215);
            e.Graphics.DrawRectangle(Red, new Rectangle(300, 230, 75, 40));
            e.Graphics.DrawString("Attack", this.Font, Brushes.Yellow, 315, 235);
            e.Graphics.DrawRectangle(Red, new Rectangle(600, 45, 75,75));
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                label1.Text = "D";
            }
            if (e.KeyCode == Keys.A)
            {
                label1.Text = "A";
            }
            if (e.KeyCode == Keys.W)
            {
                label1.Text = "W";
            }
            if (e.KeyCode == Keys.S)
            {
                label1.Text = "S";
            }
        }

        private void populate()
        {
            if (tracking != 1)
            {
                label13.Text = tracking.ToString();
                player = new Player(50, 10, 20, 0, 1);
                tracking = 1;
            }
            Playergoldlabel.Text = player.Gold.ToString();
            Playerexplabel.Text = player.ExperiencePoints.ToString();
            Playerlifelabel.Text = player.CurrentHitPoint.ToString();
            Monsterlifelabel.Text = currentMonster.CurrentHitPoint.ToString();
            Monstnamelabel.Text = currentMonster.Name.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(creature.barrier);
            this.Visible = false;
        }
        private void playercombat()
        {
            int attack = 0;
            int defense = 0;

            randomNumber = random.Next(1, 100);
            Playerattrolllabel.Text = randomNumber.ToString();
            attack = randomNumber;

            randomNumber = random.Next(1, 100);
            monstdefrolllabel.Text = randomNumber.ToString();
            defense = randomNumber;
            if (attack >= defense)
            {
                int damage = 0;
                attacker = 1;
                randomNumber = random.Next(currentWeapon.MinimumDamage + 1, currentWeapon.MaximumDamage + 1);
                damage = randomNumber;
                currentMonster.CurrentHitPoint -= damage;
                Monsterlifelabel.Text = currentMonster.CurrentHitPoint.ToString();
                damagedeltlabel.Font = new Font("Arial", damagedeltlabel.Font.Size);
                damagedeltlabel.Text = "Player has hit for: " + damage + " Damage.";

                currentsize = damagedeltlabel.Font.Size;
                wordtimer.Start();
                wordtimer.Interval = 100;
                
            }
            else
            {
                damagedeltlabel.Text = "you missed.";
                creaturecombat();
            }
            
        }
        private void checkcreaturelife()
        {
            if (currentMonster.CurrentHitPoint <= 0)
            {
                Controls.Remove(creature.barrier);
                this.Visible = false;
            }
            else creaturecombat();
        }
        private void creaturecombat()
        {
            int attack = 0;
            int defense = 0;
            int damage = 0;
            randomNumber = random.Next(1, 100);
            Monstattrolllabel.Text = randomNumber.ToString();
            attack = randomNumber;

            randomNumber = random.Next(1, 100);
            Playerdefrolllabel.Text = randomNumber.ToString();
            defense = randomNumber;

            if (attack >= defense)
            {
                randomNumber = random.Next(1, 100);
                randomNumber = random.Next(currentMonster.MinimumDamage + 1, currentMonster.MaximumDamage + 1);
                damage = randomNumber;
                player.CurrentHitPoint -= damage;
                mdamagelabel.Text = "Monster hit you for:" + damage;
                Playerlifelabel.Text = player.CurrentHitPoint.ToString();
            }
            else
            {
                mdamagelabel.Text = "the Monster missed you";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            playercombat();
            
        }

        private void wordtimer_Tick_1(object sender, EventArgs e)
        {
            if (frame == 0)
            {
                currentsize += 2.0F;
                if (attacker==1)
                {
                    damagedeltlabel.Font = new Font(damagedeltlabel.Font.Name, currentsize, damagedeltlabel.Font.Style, damagedeltlabel.Font.Unit);
                }
               
                frame = 1;
            }
            else if (frame == 1)
            {
                currentsize += 2.0F;
                if (attacker == 1)
                {
                    damagedeltlabel.Font = new Font(damagedeltlabel.Font.Name, currentsize, damagedeltlabel.Font.Style, damagedeltlabel.Font.Unit);
                }
                frame = 2;
            }
            else if (frame == 2)
            {
                currentsize += 2.0F;
                if (attacker == 1)
                {
                    damagedeltlabel.Font = new Font(damagedeltlabel.Font.Name, currentsize, damagedeltlabel.Font.Style, damagedeltlabel.Font.Unit);
                }
                frame = 3;
            }
            else
            {
                currentsize += 2.0F;
                if (attacker == 1)
                {
                    damagedeltlabel.Font = new Font(damagedeltlabel.Font.Name, currentsize, damagedeltlabel.Font.Style, damagedeltlabel.Font.Unit);
                }
                frame = 0;
                currentsize -= 8.0F;
                if (attacker == 1)
                {
                    damagedeltlabel.Font = new Font(damagedeltlabel.Font.Name, currentsize, damagedeltlabel.Font.Style, damagedeltlabel.Font.Unit);
                    attacker = 0;
                }
                wordtimer.Stop();
                checkcreaturelife();
            }
        }
    }
}
