using Snake.Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Logic
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x = 1, int y = 1)
        {
            X = x;
            Y = y;
        }
    }

    public class Snake
    {
        Queue<Point> segments;
        event EventHandler snakeChange;

        public Snake(int length)
        {
            segments = new Queue<Point>();
            snakeChange = (x, y) => { };

            for(int i = 1; i <= length; i++)
                segments.Enqueue(new Point(x: i));
        }

        public IEnumerable<Point> Segments { get { return segments; } }

        public void AddSegment(Direction direction)
        {
            var newSegment = segments.Last();

            switch(direction)
            {
                case Direction.Up : newSegment.Y-- ; break;
                case Direction.Down: newSegment.Y++ ; break;
                case Direction.Left: newSegment.X-- ; break;
                case Direction.Right: newSegment.X++ ; break;
            }

            segments.Enqueue(newSegment);
            onChange(new Arg { Segment = newSegment });
        }        

        public Point DeleteSegment()
        {
            var segment = segments.Dequeue();
            onChange(new Arg { Segment = segment });
            return segment;
        }

        public class Arg : EventArgs
        {
            public Point Segment { get; set; }
        }

        public void onChange(Arg point)
        {
            snakeChange(this, point);
        }
    }
}
