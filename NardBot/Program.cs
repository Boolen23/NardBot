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
            game = new Game(false, MyIdent);
            gClient = game.GetHumanClient();
            gClient.ClientMoveStarted += GClient_ClientMoveStarted;
            dr = Drawer.ByGame(game);
            game.NewGame();
            Console.ReadLine();
             
        }

        private static void GClient_ClientMoveStarted(object sender, MoveEventArgs e)
        {
            Move move = e.move;

            while (!move.IsEnd)
            {
                dr.Invalidate();
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                Console.WriteLine($"Доступные ходы: {string.Join(", ", e.move.Moves)}, Команда: четветь ячейка кол-во очков");
                Command command = Command.FromString(Console.ReadLine());
                game.ExecuteCommand(command);
            }
            dr.Invalidate();
        }

        static Game game;
        static Drawer dr;
        static GameClient gClient;
        static Identity GetClientIdentity()
        {
            for (; ; )
            {
                Console.Write("Выберите цвет фишек (ч/б): ");
                var input = Console.ReadKey().KeyChar.ToString();
                if (input != "ч" && input != "б")
                {
                    Console.WriteLine("Выберите только Черные или Белые фишки!");
                    continue;
                }
                else
                {
                    return input == "ч" ? Identity.Black : Identity.White;
                }
            }
        }
    }
}
