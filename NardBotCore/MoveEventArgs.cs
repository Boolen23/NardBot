using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class MoveEventArgs : EventArgs
    {
        public MoveEventArgs(params int[] moves)
        {
            this.Moves = moves;
        }
        public int[] Moves;
    }
}
