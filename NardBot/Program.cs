using NardBotCore;
using System;
using System.Linq;

namespace NardBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyIdent = GetClientIdentity();
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
        static GameClient gClient;
        static Identity GetClientIdentity()
        {
            for (; ; )
            {
                Console.Write("Выберите цвет фишек (ч/б): ");
                var input = Console.ReadKey().KeyChar;
                if (input != 'ч' || input != 'б')
                {
                    Console.WriteLine("Выберите только Черные или Белые фишки!");
                    continue;
                }
                else
                {
                    return input == 'ч' ? Identity.Black : Identity.White;
                }
            }
        }
    }
}
