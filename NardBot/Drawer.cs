using NardBotCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NardBot
{
    public class Drawer
    {
        public static Drawer ByGame(Game g)
        {
            Drawer dr = new Drawer();
            dr.game = g;
            return dr;
        }
        private Game game;
        public void Invalidate()
        {
            DrawGame();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        void DrawGame()
        {
            Console.Clear();
            foreach (Cell cl in game.Cells)
                DrawCell(cl);
            DrawInfo();
            DrawHistory();
        }
        void DrawInfo()
        {
            string info = game.GetInfo();
            if (string.IsNullOrEmpty(info)) return;
            Console.SetCursorPosition(10, 5);
            Console.WriteLine(info);
        }
        void DrawHistory()
        {
            for (int i = 0; i < game.HistoryList.Count; i++)
            {
                Console.SetCursorPosition(65, i);
                Console.Write($"| {game.HistoryList[i]}");
            }
        }
        static void DrawCell(Cell c)
        {
            int Pos = c.FourthNumber switch
            {
                0 => 58 - c.CellNumber * 4,
                1 => 28 - c.CellNumber * 4,
                2 => 4 + c.CellNumber * 4,
                3 => 34 + c.CellNumber * 4
            };

            Console.SetCursorPosition(c.PositionByStep(0), c.TopPadding());
            Console.Write("|");
            Console.SetCursorPosition(c.PositionByStep(c.FourthNumber < 2 ? 3 : 1), c.TopPadding());
            Console.Write(c.InnerText());
            Console.SetCursorPosition(c.PositionByStep(4), c.TopPadding());
            Console.Write("|");

        }
    }
    public static class Helper
    {
        public static int TopPadding(this Cell c) => c.FourthNumber < 2 ? 0 : 3;
        public static int PositionByStep(this Cell c, int step)
        {
            int pos = c.FourthNumber switch
            {
                0 => 58 - c.CellNumber * 4,
                1 => 28 - c.CellNumber * 4,
                2 => 4 + c.CellNumber * 4,
                3 => 34 + c.CellNumber * 4,
            };
            return c.FourthNumber < 2 ? pos - step : pos + step;
        }
        public static string InnerText(this Cell c) => string.Format("{0}{1}", (c.ChipCount < 10 ? $"0{c.ChipCount}" : c.ChipCount.ToString()),
               (c.Identity switch { Identity.Free => "н", Identity.White => "б", Identity.Black => "ч" }));

    }

}
