using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Game
    {
        public Game()
        {
            Cells = new List<Cell>();
            for (int FourthCounter = 0; FourthCounter < 4; FourthCounter++)
                for (int CellCounter = 0; CellCounter < 6; CellCounter++)
                    Cells.Add(new Cell(FourthCounter, CellCounter));
        }
        public List<Cell> Cells;
    }
}
