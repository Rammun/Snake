using Snake.Logic.Enums;
using Snake.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public class SnakeGame : IGame
    {
        static Random rnd = new Random();
        const int SIZE_X = 50;
        const int SIZE_Y = 22;
        const int SNAKE_LENGTH = 4;

        Snake snake;
        Point currentPrize;
        Direction currentDirection;
        int countPrize;
        GameState gameState;

        public Action<Point, Item> Draw { get; set; }

        public SnakeGame()
        {
            snake = new Snake(SNAKE_LENGTH);
            currentPrize = PrizeFactory();
            currentDirection = Direction.Right;
            countPrize = 0;
            Draw = (x,y) => { };
        }

        public void Initialization()
        {
            BorderDraw();
            Draw(currentPrize, Item.Prize);
            SnakeDraw();
            
            gameState = GameState.Begin;
        }
        
        public void Start()
        {
            gameState = GameState.Process;
        }

        public void Step()
        {
            snake.AddSegment(currentDirection);
            Draw(snake.Segments.Last(), Item.SnakeSegment);

            if(snake.EqualsNewSegment(currentPrize))
            {
                countPrize++;
                currentPrize = PrizeFactory();
                Draw(currentPrize, Item.Prize);
                return;
            }
            //else if(snake.IsSegment() || snake.IsRegion(SIZE_X, SIZE_Y))
            //{
            //    Stop();
            //}

            Draw(snake.Segments.First(), Item.Zerro);
            snake.DeleteSegment();
        }

        public void Stop()
        {
            gameState = GameState.End;
        }
        
        public void Instruction(Direction direction)
        {
            if(direction == Direction.Error)
            {
                Stop();
                return;
            }

            currentDirection = direction;
        }

        public GameState State
        {
            get { return gameState; }
        }

        private Point PrizeFactory()
        {
            return new Point { X = rnd.Next(1, SIZE_X), Y = rnd.Next(1, SIZE_Y) };
        }

        private void BorderDraw()
        {
            for (int x = 0; x <= SIZE_X; x++)
            {
                Draw(new Point(x, 0), Item.Border);
                Draw(new Point(x, SIZE_Y), Item.Border);
            }

            for (int y = 1; y < SIZE_Y; y++)
            {
                Draw(new Point(0, y), Item.Border);
                Draw(new Point(SIZE_X, y), Item.Border);
            }                
        }

        private void SnakeDraw()
        {
            foreach (var point in snake.Segments)
            {
                Draw(point, Item.SnakeSegment);
            }
        }

    }
}
