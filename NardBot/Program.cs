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
                if(cl.FourthNumber < 2)
                DrawCell(cl);
        }
        static void DrawCell(Cell c)
        {
            bool IsSecondLine = c.FourthNumber > 1;
            var t = c.FourthNumber * 24 + c.CellNumber * 4;
            //int EndPos = 48 - c.FourthNumber * 24 - c.CellNumber * 4;
            int EndPos = c.FourthNumber == 0 ? 58 - c.CellNumber * 4 :
                            c.FourthNumber == 1 ? 28 - c.CellNumber * 4 : 0;
            string ChipCountText = c.ChipCount < 10 ? $"0{c.ChipCount}" : c.ChipCount.ToString();
            DrawCellFrom(c, IsSecondLine, EndPos, ChipCountText);
        }
        static void DrawCellFrom(Cell c, bool IsSecondLine, int EndPos, string ChipCountText)
        {
            Console.SetCursorPosition(EndPos, IsSecondLine ? 2 : 0);
            Console.Write("|");
            Console.SetCursorPosition(EndPos - 1 < 0 ? 0 : EndPos - 1, IsSecondLine ? 2 : 0);
            if (c.Identity == CellIIdentity.Free) Console.Write("н");
            if (c.Identity == CellIIdentity.White) Console.Write("б");
            if (c.Identity == CellIIdentity.Black) Console.Write("ч");
            Console.SetCursorPosition(EndPos - 3 < 0 ? 0 : EndPos - 3, IsSecondLine ? 2 : 0);
            Console.Write(ChipCountText);
            Console.SetCursorPosition(EndPos - 4 < 0 ? 0 : EndPos - 4, IsSecondLine ? 2 : 0);
            Console.Write("|");
        }
    }
}
