using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Game
    {
        public Game(bool WhiteStarted)
        {
            this.WhiteStarted = WhiteStarted;
            Cells = new List<Cell>();
            for (int FourthCounter = 0; FourthCounter < 4; FourthCounter++)
                for (int CellCounter = 0; CellCounter < 6; CellCounter++)
                    Cells.Add(new Cell(FourthCounter, CellCounter));

            var Whitecells = this[WhiteStarted ? 0 : 2, 0];
            Whitecells.ChipCount = 15;
            Whitecells.Identity = Identity.White;

            var BlackCells = this[WhiteStarted ? 2 : 0, 0];
            BlackCells.ChipCount = 15;
            BlackCells.Identity = Identity.Black;

            InfoList = new List<string>();
        }
        private bool WhiteStarted;
        public List<Cell> Cells;
        public Cell this[int FourthNumber, int CellNumber] => Cells.FirstOrDefault(c => c.FourthNumber == FourthNumber && c.CellNumber == CellNumber);
        public List<string> InfoList;
        public event EventHandler<MoveEventArgs> WhiteMove;
        public event EventHandler<MoveEventArgs> BlackMove;
        public void AddStep(int SrcFourth, int SrcCellNumber, int cnt)
        {
            Cell c = this[SrcFourth, SrcCellNumber];
            if (c.ChipCount < 1)
            {
                InfoList.Add($"{SrcFourth}-{SrcCellNumber}-{cnt}: В ячейке {SrcFourth}-{SrcCellNumber} нет фишек!");
                return;
            }
            int ResFourth = c.CellNumber + cnt >= 6 ? c.FourthNumber + 1 : c.FourthNumber;
            if (ResFourth > 3) ResFourth = 0;
            int ResCellNumber = ResFourth != c.FourthNumber ? (c.CellNumber + cnt - 6) : (cnt + c.CellNumber);
            Cell resCell = this[ResFourth, ResCellNumber];
            if(resCell.Identity != c.Identity && resCell.Identity != Identity.Free)
            {
                InfoList.Add($"{SrcFourth}-{SrcCellNumber}-{cnt}: Ячейка {ResFourth}-{ResCellNumber} занята противником!");
                return;
            }
            resCell.ChipCount++;
            resCell.Identity = c.Identity;
            c.ChipCount--;

            InfoList.Add($"{SrcFourth}-{SrcCellNumber}-{cnt}: Ok!");
            return;
        }
    }
}
