using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBotCore
{
    public class Move
    {
        public int[] Moves;
        public static Move Generate()
        {
            if (rn is null) rn = new Random();
            Move m = new Move();

            int firstNumber = NextNumber;
            int secondNumber = NextNumber;
            if (firstNumber == secondNumber) m.Moves = new int[] { firstNumber, firstNumber, firstNumber, firstNumber };
            else m.Moves = new int[] { firstNumber, secondNumber };

            return m;
        }
        private static int NextNumber => rn.Next(1, 7);

        private static Random rn;
        public static bool DrawLots(out string info)
        {
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
