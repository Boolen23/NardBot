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
            IsWhiteСhip = false;
        }
        public int FourthNumber { get; set; }
        public int CellNumber { get; set; }
        public bool IsWhiteСhip { get; set; }
        public int ChipCount { get; set; }
    }
}
