using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class BlueBlock:Block
    {
        public override void StopAction(ref Player player)
        {
            Random randomNumber = new Random();
            int number;
            number = randomNumber.Next(3) + 1;

            if(number == 1)
            {
                player.Attack += 500;
            }
            if (number == 2)
            {
                player.Attack += 1000;
            }
            if (number == 3)
            {
                player.Attack += 1500;
            }
        }
    }
}
