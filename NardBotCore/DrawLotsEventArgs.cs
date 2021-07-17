using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class DrawLotsEventArgs : EventArgs
    {
        public DrawLotsEventArgs(int WhiteNumber, int BlackNumber)
        {
            this.WhiteNumber = WhiteNumber;
            this.BlackNumber = BlackNumber;
        }
        public int WhiteNumber { get; set; }
        public int BlackNumber { get; set; }
        public string ResultString => $"Белые: {WhiteNumber} Черные: {BlackNumber}  {(WhiteNumber >= BlackNumber ? "Белые ходят!" : "Черные ходят!")}";
    }
}
