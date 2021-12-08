using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Cell
    {
        public Cell(int FourthNumber, int CellNumber)
        {
            this.FourthNumber = FourthNumber;
            this.CellNumber = CellNumber;
            ChipCount = 0;
            Identity = Identity.Free;
        }
        public int FourthNumber { get; set; }
        public int CellNumber { get; set; }
        public Identity Identity { get; set; }
        public int ChipCount { get; set; }
        public override string ToString()
        {
            return $"{FourthNumber}-{CellNumber}";
        }
    }
}
