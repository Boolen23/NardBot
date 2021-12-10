using NardBotCore.NardBotAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Game
    {
        public Game(bool WhiteStarted, Identity HumanIdentity)
        {
            this.HumanIdentity = HumanIdentity;

            Cells = new List<Cell>();
            HistoryList = new List<string>();
            InfoList = new Queue<string>();

            if (HumanIdentity == Identity.White)
            {
                HistoryList.Add("Вы играете за белых!");
                WhiteClient = new GameClient(Identity.White, this);
                BlackClient = new AIBot(Identity.Black, this);
            }
            else
            {
                HistoryList.Add("Вы играете за черных!");
                WhiteClient = new AIBot(Identity.White, this);
                BlackClient = new GameClient(Identity.Black, this);
            }
        }
        private GameClient WhiteClient;
        private GameClient BlackClient;
        private Identity HumanIdentity;
        public Identity CurrentStepIdentity;
        private Move CurrentMove;

        public GameClient GetHumanClient() => HumanIdentity == Identity.White ? WhiteClient : BlackClient;

        public void Step()
        {
            HistoryList.Add($"{DateTime.Now.ToShortTimeString()}: {(HumanIdentity == CurrentStepIdentity ? "Ваш ход" : "Ход врага")}!");
            CurrentMove = Move.Generate(CurrentStepIdentity == Identity.White ? WhiteClient : BlackClient);
            if (CurrentStepIdentity == Identity.White)
                WhiteClient.MoveStarted(WhiteClient, new MoveEventArgs(CurrentMove));
            else
                BlackClient.MoveStarted(BlackClient, new MoveEventArgs(CurrentMove));
            CurrentStepIdentity = CurrentStepIdentity == Identity.White ? Identity.Black : Identity.White;
            Step();
        }
        public void NewGame()
        {
            string DrawLotsInfo = string.Empty;
            this.WhiteStarted = Move.DrawLots(out DrawLotsInfo);
            InfoList.Enqueue(DrawLotsInfo);

            CurrentStepIdentity = WhiteStarted ? Identity.White : Identity.Black;
            for (int FourthCounter = 0; FourthCounter < 4; FourthCounter++)
                for (int CellCounter = 0; CellCounter < 6; CellCounter++)
                    Cells.Add(new Cell(FourthCounter, CellCounter));

            var Whitecells = this[WhiteStarted ? 0 : 2, 0];
            Whitecells.ChipCount = 15;
            Whitecells.Identity = Identity.White;
            WhiteClient.StartCell = Whitecells;

            var BlackCells = this[WhiteStarted ? 2 : 0, 0];
            BlackCells.ChipCount = 15;
            BlackCells.Identity = Identity.Black;
            BlackClient.StartCell = BlackCells;

            Step();
        }
        private bool WhiteStarted;
        public List<Cell> Cells;
        public Cell this[int FourthNumber, int CellNumber] => Cells.FirstOrDefault(c => c.FourthNumber == FourthNumber && c.CellNumber == CellNumber);
        public Cell this[CellAddress address] => Cells.FirstOrDefault(c => c.FourthNumber == address.FourthNumber && c.CellNumber == address.CellNumber);
        public List<string> HistoryList;
        public Queue<string> InfoList;

        private bool WhiteHasMove = false;
        private bool BlackHasMove = false;
        private bool WhiteHasExtraMove = false;
        private bool BlackHasExtraMove = false;

        public bool CurrentIdentityHasMove => CurrentStepIdentity == Identity.White ? WhiteHasMove : BlackHasMove;
        public bool CurrentIdentityHasExtraMove => CurrentStepIdentity == Identity.White ? WhiteHasExtraMove : BlackHasExtraMove;

        public void CurrentIdentityGetExtraMove()
        {
            if (CurrentStepIdentity == Identity.White)
                WhiteHasExtraMove = true; 
            else BlackHasExtraMove = true;
        }
        public bool CurrentIdentityHaveFreeMove
        {
            get
            {
                foreach (var srcCell in Cells.Where(i => i.Identity == CurrentStepIdentity))
                    foreach (int move in CurrentMove.Moves)
                    {
                        Cell target = this[srcCell + move];
                        if (target.Identity == CurrentStepIdentity || target.Identity == Identity.Free)
                            return true;
                    }
                return false;
            }
        }
        public void ExecuteCommand(Command cmd)
        {
            var ValidateResult = CurrentMove.Validate(this, cmd);
            if (!ValidateResult.IsValid)
            {
                InfoList.Enqueue(ValidateResult.BadInfo);
                return;
            }
            ValidateResult.Target.Identity = ValidateResult.Source.Identity;
            ValidateResult.Target.ChipCount++;
            ValidateResult.Source.ChipCount--;

            if (CurrentMove.IsEnd)
            {
                if (CurrentStepIdentity == Identity.White && !WhiteHasMove) WhiteHasMove = true;
                if (CurrentStepIdentity == Identity.Black && !BlackHasMove) BlackHasMove = true;
            }

            HistoryList.Add($"{CurrentStepIdentity}: {cmd}: Ok!");
            return;
        }
        public string GetInfo() => InfoList.Count == 0 ? null : InfoList.Dequeue();
    }
}
