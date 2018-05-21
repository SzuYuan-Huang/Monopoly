using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Block
    {
        private Point location;

        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                if (value.X < 0)
                    value.X = 0;
                if (value.Y < 0)
                    value.Y = 0;

                location = value;
            }
        }

        public Block()
        {
            Location = new Point(0, 0);
        }

        public Block(Point p)
        {
            Location = p;
        }

        public virtual void StopAction(ref Player player)
        {
          
        }

        public virtual void PassAction(ref Player player)
        {
           
        }
    }
}
