using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class ShortCutBlock:Block
    {
        public override void StopAction(ref Player player)
        {
            player.State = PlayerState.Teleport;
            if(player.BlockIndex==21)
            {
                player.BlockIndex = 44;
                player.Location = new Point(144,692);
                return;
            }
        }
    }
}
