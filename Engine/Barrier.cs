using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Engine
{
    public class Barrier
    {
        public int x { get; set; }
        public int y { get; set; }
        public PictureBox barrier = new PictureBox();

        public Barrier(int x, int y)
        {

            barrier.Size = new Size(50, 50);
            barrier.Location = new Point(x, y);
            barrier.BackColor = Color.Transparent;
        }
    }
}
