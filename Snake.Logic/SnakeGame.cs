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
        const int SIZE_X = 30;
        const int SIZE_Y = 40;
        const int SNAKE_LENGTH = 4;

        Snake snake;
        Point currentPrize;
        Direction currentDirection;
        int countPrize;
        GameState gameState;

        public SnakeGame()
        {
            Initialization(SIZE_X, SIZE_Y);
        }
        public void Initialization(int x, int y)
        {
            currentPrize = GetNewPrize();
            snake = new Snake(SNAKE_LENGTH);
            currentDirection = Direction.Right;
            countPrize = 0;
        }
        
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Step()
        {
            snake.AddSegment(currentDirection);
            if(snake.EqualsNewSegment(currentPrize))
            {
                countPrize++;
                currentPrize = GetNewPrize();
            }
            else if(snake.IsSegment() || snake.IsRegion(SIZE_X, SIZE_Y))
            {
                Stop();
            }
            else
            {
                snake.DeleteSegment();
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }


        public void Intstruction(Direction direction)
        {
            currentDirection = direction;
        }

        public GameState State
        {
            get { return gameState; }
        }

        private Point GetNewPrize()
        {
            return new Point { X = rnd.Next(0, SIZE_X), Y = rnd.Next(0, SIZE_Y) };
        }
    }
}
