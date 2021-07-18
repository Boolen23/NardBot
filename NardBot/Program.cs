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
            dr = Drawer.ByGame(game);
            game.NewGame();
            while (true)
            {
                dr.Invalidate();
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
        static Drawer dr;
    }
}
