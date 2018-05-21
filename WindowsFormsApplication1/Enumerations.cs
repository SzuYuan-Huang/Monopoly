using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    
        enum TurnPhase
        {
            Initial,
            Walk,
            Dice,
            End
        }

        enum PlayerState
        {
            Normal,
            Stop,
            Teleport,
            StopAttack,
            SpeedUp,
            Invisible,
            Shopping,
            Dead
        }
    
}
