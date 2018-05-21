using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class PinkBlock:Block
    {
        public override void StopAction(ref Player player)
        {
            player.Blood = player.Blood + 2000;
        }
    }
}
