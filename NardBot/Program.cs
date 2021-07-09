using NardBotCore;
using System;
using System.Linq;

namespace NardBot
{
    class Program
    {
        static void Main(string[] args)
        {
            game = new Game(false);
            while (true)
            {
                DrawGame();
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                Console.WriteLine("Команда: четветь ячейка кол-во очков");
                ExecuteCommand(Console.ReadLine());
            }
            Console.ReadLine();
             
        }
        static void ExecuteCommand(string command)
        {
            int[] cmd = command.Split().Select(i => i.Trim()).Select(int.Parse).ToArray();
            game.AddStep(cmd[0], cmd[1], cmd[2]);
        }
        static Game game;
        static void DrawGame()
        {
            Console.Clear();
            foreach (Cell cl in game.Cells)
                DrawCell(cl);
            DrawHistory();
        }
        static void DrawHistory()
        {
            for (int i = 0; i < game.InfoList.Count; i++)
            {
                Console.SetCursorPosition(65, i);
                Console.Write($"| {game.InfoList[i]}");
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
