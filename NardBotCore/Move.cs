using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Move
    {
        public GameClient GameClient { get; set; } 
        public List<int> Moves;
        public bool CanTakeFromStartCell { get; set; }
        public bool IsEnd => Moves.Count == 0;
        public (bool IsValid, Cell Source, Cell Target, string BadInfo) Validate(Game game, Command cmd)
        {
            if (IsEnd)
                return (false, null, null, $"Движение уже закончено!");

            if (Moves.IndexOf(cmd.MoveCount) == -1)
                return (false, null, null, $"Движение не содержит {cmd.MoveCount}!");

            Cell Source = game[cmd.SourceFourth, cmd.SourceCellNumber];
            if (Source.ChipCount < 1)
                return (false, Source, null, $"{cmd}: В ячейке {Source} нет фишек!");

            if(Source == GameClient.StartCell && !CanTakeFromStartCell)
                return (false, Source, null, $"{cmd}: Вы уже брали из стартовой ячейки!");


            if (game.CurrentStepIdentity != Source.Identity)
                return (false, Source, null, $"{cmd}: Сейчас ход {game.CurrentStepIdentity}, а в запрошенной ячейке {Source.Identity}!");

            int ResFourth = Source.CellNumber + cmd.MoveCount >= 6 ? Source.FourthNumber + 1 : Source.FourthNumber;
            if (ResFourth > 3) ResFourth = 0;
            int ResCellNumber = ResFourth != Source.FourthNumber ? (Source.CellNumber + cmd.MoveCount - 6) : (cmd.MoveCount + Source.CellNumber);
            Cell resCell = game[ResFourth, ResCellNumber];

            if (resCell.Identity != Source.Identity && resCell.Identity != Identity.Free)
                return (false, Source, resCell, $"{cmd}: Ячейка {resCell} занята противником!");

            Moves.RemoveAt(Moves.IndexOf(cmd.MoveCount));
            if (Source == GameClient.StartCell)
                CanTakeFromStartCell = false;
            return (true, Source, resCell, null);
        }
        public static Move Generate(GameClient gameClient)
        {
            if (rn is null) rn = new Random();
            Move m = new Move() { GameClient = gameClient, CanTakeFromStartCell = true };    

            int firstNumber = NextNumber;
            int secondNumber = NextNumber;
            if (firstNumber == secondNumber) m.Moves = new List<int>() { firstNumber, firstNumber, firstNumber, firstNumber };
            else m.Moves = new List<int>() { firstNumber, secondNumber };

            return m;
        }
        private static int NextNumber => rn.Next(1, 7);

        private static Random rn;
        public static bool DrawLots(out string info)
        {
            if (rn is null) rn = new Random();

            int WhiteNumber = 0;
            int BlackNumber = 0;
            do
            {
                WhiteNumber = NextNumber;
                BlackNumber = NextNumber;
            }
            while (WhiteNumber == BlackNumber);
            info = $"Белые: {WhiteNumber} Черные: {BlackNumber}  {(WhiteNumber >= BlackNumber ? "Белые ходят!" : "Черные ходят!")}";
            return WhiteNumber >= BlackNumber;
        }

    }
}
