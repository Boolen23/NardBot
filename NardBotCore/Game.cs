using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Game //TODO: сделать 2 game client внутри этого класса, из programm убрать
    {
        public Game(bool WhiteStarted)
        {
            rn = new Random();
            Cells = new List<Cell>();
            HistoryList = new List<string>();
            InfoList = new Queue<string>();
        }
        public void Step()
        {
            if (CurrentStepIdentity == Identity.White) WhiteMove?.Invoke(this, new MoveEventArgs(GetMoveKit()));
            else BlackMove?.Invoke(this, new MoveEventArgs(GetMoveKit()));
        }
        public Identity CurrentStepIdentity;
        public void NewGame()
        {
            this.WhiteStarted = DrawLots();
            CurrentStepIdentity = WhiteStarted ? Identity.White : Identity.Black;
            for (int FourthCounter = 0; FourthCounter < 4; FourthCounter++)
                for (int CellCounter = 0; CellCounter < 6; CellCounter++)
                    Cells.Add(new Cell(FourthCounter, CellCounter));

            var Whitecells = this[WhiteStarted ? 0 : 2, 0];
            Whitecells.ChipCount = 15;
            Whitecells.Identity = Identity.White;

            var BlackCells = this[WhiteStarted ? 2 : 0, 0];
            BlackCells.ChipCount = 15;
            BlackCells.Identity = Identity.Black;

            Step();
        } 
        private bool WhiteStarted;
        public List<Cell> Cells;
        public Cell this[int FourthNumber, int CellNumber] => Cells.FirstOrDefault(c => c.FourthNumber == FourthNumber && c.CellNumber == CellNumber);
        public List<string> HistoryList;
        public Queue<string> InfoList;
        public event EventHandler<MoveEventArgs> WhiteMove;
        public event EventHandler<MoveEventArgs> BlackMove;
        public static Random rn;
        public int NextNumber => rn.Next(1, 7);
        public int[] GetMoveKit()
        {
            int firstNumber = NextNumber;
            int secondNumber = NextNumber;
            if (firstNumber == secondNumber) return new int[] { firstNumber, firstNumber, firstNumber, firstNumber };
            else return new int[] { firstNumber, secondNumber };
        }
        public void AddStep(int SrcFourth, int SrcCellNumber, int cnt)
        {
            Cell c = this[SrcFourth, SrcCellNumber];
            if (c.ChipCount < 1)
            {
                HistoryList.Add($"{SrcFourth}-{SrcCellNumber}-{cnt}: В ячейке {SrcFourth}-{SrcCellNumber} нет фишек!");
                return;
            }
            int ResFourth = c.CellNumber + cnt >= 6 ? c.FourthNumber + 1 : c.FourthNumber;
            if (ResFourth > 3) ResFourth = 0;
            int ResCellNumber = ResFourth != c.FourthNumber ? (c.CellNumber + cnt - 6) : (cnt + c.CellNumber);
            Cell resCell = this[ResFourth, ResCellNumber];
            if (resCell.Identity != c.Identity && resCell.Identity != Identity.Free)
            {
                HistoryList.Add($"{SrcFourth}-{SrcCellNumber}-{cnt}: Ячейка {ResFourth}-{ResCellNumber} занята противником!");
                return;
            }
            resCell.ChipCount++;
            resCell.Identity = c.Identity;
            c.ChipCount--;

            HistoryList.Add($"{SrcFourth}-{SrcCellNumber}-{cnt}: Ok!");
            return;
        }
        public bool DrawLots()
        {
            int WhiteNumber = 0;
            int BlackNumber = 0;
            do
            {
                WhiteNumber = NextNumber;
                BlackNumber = NextNumber;
            }
            while (WhiteNumber == BlackNumber);
            InfoList.Enqueue($"Белые: {WhiteNumber} Черные: {BlackNumber}  {(WhiteNumber >= BlackNumber ? "Белые ходят!" : "Черные ходят!")}");
            return WhiteNumber >= BlackNumber;
        }
        public string GetInfo() => InfoList.Count == 0 ? null : InfoList.Dequeue();
    }
}
