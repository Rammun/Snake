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

        public Snake(int length)
        {
            segments = new Queue<Point>();
            for(int i = 1; i <= length; i++)
            {
                segments.Enqueue(new Point(x: i));
            }
        }

        public IEnumerable<Point> Segments { get { return segments; } }

        public void AddSegment(Direction direction)
        {
            Point newSegment = segments.Last();

            switch(direction)
            {
                case Direction.Up : newSegment.Y -= 1; break;
                case Direction.Down: newSegment.Y += 1; break;
                case Direction.Left: newSegment.X -= 1; break;
                case Direction.Right: newSegment.X += 1; break;
            }

            segments.Enqueue(newSegment);
        }

        public bool EqualsNewSegment(Point point)
        {
            return point.Equals(segments.Last());
        }

        public bool IsSegment()
        {
            return segments.Any(s => s.Equals(segments.Last()));
        }

        public Point GetNewSegment()
        {
            return segments.Last();
        }

        public bool IsRegion(int size_x, int size_y)
        {
            var segment = segments.Last();
            return !(segment.X < 0 || segment.X >= size_x || segment.Y < 0 || segment.Y >= size_y);
        }

        public Point DeleteSegment()
        {
            return segments.Dequeue();
        }
    }
}
