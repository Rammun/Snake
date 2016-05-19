using Snake.Logic;
using Snake.Logic.Enums;
using Snake.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SnakeConsoleUI
{
    class Program
    {
        static Timer timer;
        static IGame game;

        static void Main(string[] args)
        {
            game = new SnakeGame();

            game.Draw = Draw;
            timer = new Timer();
            timer.Interval = 100;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(StepMethod);

            game.Initialization();
            game.Start();
            timer.Start();

            while(true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        game.Instruction(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        game.Instruction(Direction.Right);
                        break;
                    case ConsoleKey.DownArrow:
                        game.Instruction(Direction.Down);
                        break;
                    case ConsoleKey.UpArrow:
                        game.Instruction(Direction.Up);
                        break;
                    default:
                        game.Instruction(Direction.Error);
                        break;
                }                
            }
        }

        static void StepMethod(object source, ElapsedEventArgs e)
        {
            if (game.State == GameState.End)
            {
                timer.Stop();
                game.Stop();
                Console.WriteLine("GAME OVER");
            }
            game.Step();
        }

        static void Draw(Point point, Item item)
        {
            char symbol;
            switch (item)
            {
                case Item.Border: symbol = '*'; break;
                case Item.Prize: symbol = '+'; break;
                case Item.SnakeSegment: symbol = 'o'; break;
                case Item.Zerro: symbol = ' '; break;
                default: symbol = '!'; break;
            }

            Console.CursorLeft = point.X;
            Console.CursorTop = point.Y;
            Console.Write(symbol);
        }
    }
}
