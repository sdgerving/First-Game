using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Engine
{
   public class TreasureChest
    {
        public int x { get; set; }
        public int y { get; set; }
        public PictureBox treasurechest = new PictureBox();

        public TreasureChest(int x,int y)
        {
            treasurechest.Size = new Size(50, 50);
            treasurechest.Location = new Point(x, y);
            treasurechest.BackColor = Color.Transparent;
        }
    }
}


