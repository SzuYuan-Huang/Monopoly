using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ArmorBlock : Block
    {
        public override void StopAction(ref Player player)
        {
            player.Armor = player.Armor + 2000;
        }
    }
}
