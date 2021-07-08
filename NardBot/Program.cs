using NardBotCore;
using System;

namespace NardBot
{
    class Program
    {
        static void Main(string[] args)
        {
            game = new Game(false);
            DrawGame();
            Console.ReadLine();

        }
        static Game game;
        static void DrawGame()
        {
            Console.Clear();
            foreach (Cell cl in game.Cells)
                DrawCell(cl);
        }
        static void DrawCell(Cell c)
        {
            bool IsSecondLine = c.FourthNumber > 1;
            var t = c.FourthNumber * 24 + c.CellNumber * 4;
            //int EndPos = 48 - c.FourthNumber * 24 - c.CellNumber * 4;
            int Pos = c.FourthNumber == 0 ? 58 - c.CellNumber * 4 :
                            c.FourthNumber == 1 ? 28 - c.CellNumber * 4 :
                            c.FourthNumber == 2 ? 4 + c.CellNumber * 4 :
                            c.FourthNumber == 3 ? 34 + c.CellNumber * 4 : 0;
            string ChipCountText = c.ChipCount < 10 ? $"0{c.ChipCount}" : c.ChipCount.ToString();
            DrawCellFrom(c, IsSecondLine, Pos, ChipCountText);
        }
        static void DrawCellFrom(Cell c, bool IsSecondLine, int Pos, string ChipCountText)
        {
            if (c.FourthNumber < 2)
            {
                Console.SetCursorPosition(Pos, 0);
                Console.Write("|");
                Console.SetCursorPosition(Pos - 1 < 0 ? 0 : Pos - 1, 0);
                if (c.Identity == CellIIdentity.Free) Console.Write("н");
                if (c.Identity == CellIIdentity.White) Console.Write("б");
                if (c.Identity == CellIIdentity.Black) Console.Write("ч");
                Console.SetCursorPosition(Pos - 3 < 0 ? 0 : Pos - 3, 0);
                Console.Write(ChipCountText);
                Console.SetCursorPosition(Pos - 4 < 0 ? 0 : Pos - 4, 0);
                Console.Write("|");
            }
            else
            {
                Console.SetCursorPosition(Pos, 2);
                Console.Write("|");
                Console.SetCursorPosition(Pos + 1, 2);
                Console.Write(ChipCountText);
                Console.SetCursorPosition(Pos + 3, 2);
                if (c.Identity == CellIIdentity.Free) Console.Write("н");
                if (c.Identity == CellIIdentity.White) Console.Write("б");
                if (c.Identity == CellIIdentity.Black) Console.Write("ч");
                Console.SetCursorPosition(Pos + 4, 2);
                Console.Write("|");
            }
        }
    }
}
