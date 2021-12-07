using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class MoveEventArgs : EventArgs
    {
        public MoveEventArgs(Move move)
        {
            this.move = move;
        }
        public Move move;
    }
}
