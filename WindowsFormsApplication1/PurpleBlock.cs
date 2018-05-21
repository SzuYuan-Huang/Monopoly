using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class PurpleBlock:Block
    {
        public override void StopAction(ref Player player)
        {
            player.State = PlayerState.Stop;
        }
    }
}
