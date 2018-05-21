using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class GreenBlock:Block
    {
        public override void StopAction(ref Player player)
        {
            Random randomNumber = new Random();
            int number;
            number = randomNumber.Next(401) - 200;

            if(player.Blood + number < 0)
            {
                player.Blood = 0;
            }
            else
            {
                player.Blood = player.Blood + number;
            }
        }
    }
}
