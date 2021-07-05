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

            var Whitecells = Cells.First(c => c.FourthNumber == (WhiteStarted ? 0 : 3) && c.CellNumber == 0);
            Whitecells.ChipCount = 15;
            Whitecells.IsWhiteСhip = WhiteStarted;

            var BlackCells = Cells.First(c => c.FourthNumber == (WhiteStarted ? 3 : 0) && c.CellNumber == 0);
            BlackCells.ChipCount = 15;
            BlackCells.IsWhiteСhip = !WhiteStarted;
        }
        private bool WhiteStarted;
        public List<Cell> Cells;
    }
}
