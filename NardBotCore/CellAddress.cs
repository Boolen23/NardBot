using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public struct CellAddress
    {
        public CellAddress(int FourthNumber, int CellNumber)
        {
            this.FourthNumber = FourthNumber;   
            this.CellNumber = CellNumber;
        }
        public int FourthNumber { get; set; }
        public int CellNumber { get; set; }

    }
}
