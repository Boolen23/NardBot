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
            this.cAddress = new CellAddress(FourthNumber, CellNumber);
            ChipCount = 0;
            Identity = Identity.Free;
        }
        public CellAddress cAddress { get; set; }
        public int FourthNumber => cAddress.FourthNumber;
        public int CellNumber => cAddress.CellNumber;
        public Identity Identity { get; set; }
        public int ChipCount { get; set; }
        public override string ToString()
        {
            return $"{FourthNumber}-{CellNumber}";
        }
        public static CellAddress operator + (Cell SourceCell, int move)
        {
            int ResFourth = SourceCell.CellNumber + move >= 6 ? SourceCell.FourthNumber + 1 : SourceCell.FourthNumber;
            if (ResFourth > 3) ResFourth = 0;
            int ResCellNumber = ResFourth != SourceCell.FourthNumber ? (SourceCell.CellNumber + move - 6) : (move + SourceCell.CellNumber);
            return new CellAddress(ResFourth, ResCellNumber);
        }
    }
}
