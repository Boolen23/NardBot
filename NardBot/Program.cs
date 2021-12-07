﻿using NardBotCore;
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
            gClient = game.GetClient(MyIdent);
            gClient.ClientMoveStarted += GClient_ClientMoveStarted;
            dr = Drawer.ByGame(game);
            game.NewGame();
            Console.ReadLine();
             
        }

        private static void GClient_ClientMoveStarted(object sender, MoveEventArgs e)
        {
            dr.Invalidate();
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine($"Доступные ходы: {string.Join(", ", e.move.Moves)}, Команда: четветь ячейка кол-во очков");
            ExecuteCommand(Console.ReadLine(), e.move.Moves);
        }

        static void ExecuteCommand(string command, int[] moves)
        {
            int[] cmd = command.Split().Select(i => i.Trim()).Select(int.Parse).ToArray();
            game.AddStep(cmd[0], cmd[1], cmd[2]);
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
