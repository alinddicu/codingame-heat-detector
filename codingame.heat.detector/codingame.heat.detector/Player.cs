﻿namespace codingame.heat.detector
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    public class Player
    {
        public enum Direction
        {
            U,
            UR,
            R,
            DR,
            D,
            DL,
            L,
            UL
        }

        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int W = int.Parse(inputs[0]); // width of the building.
            int H = int.Parse(inputs[1]); // height of the building.
            int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
            inputs = Console.ReadLine().Split(' ');
            int X0 = int.Parse(inputs[0]);
            int Y0 = int.Parse(inputs[1]);

            var building = new Building(W, H, new Window(X0, Y0));

            // game loop
            while (true)
            {
                string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                var bombDirection = (Direction)Enum.Parse(typeof(Direction), bombDir);
                Console.WriteLine(building.PredictJump(bombDirection)); // the location of the next window Batman should jump to.
            }
        }

        public class Building
        {
            private readonly int _width;
            private readonly int _height;

            private List<Window> _possibleJumps = new List<Window>();
            private Window _currentPosition;

            public Building(int width, int height, Window intialPosition)
            {
                _width = width;
                _height = height;
                _currentPosition = intialPosition;
                InitPossibleJumps();
            }

            private void InitPossibleJumps()
            {
                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        _possibleJumps.Add(new Window(x, y));
                    }   
                };

                _possibleJumps.Remove(_currentPosition);
            }

            public Window PredictJump(Direction bombDirection)
            {
                DiminishPossibleJumps(bombDirection);

                var xAbsMargin = Math.Abs(_currentPosition.X - _width);
                var yAbsMargin = Math.Abs(_currentPosition.Y - _height);
                var leastMargin = (new[] { xAbsMargin, yAbsMargin }).Min(m => m);
                var delta = (int)Math.Floor((double)leastMargin / 2);

                Window newWindow = null;
                switch (bombDirection)
                {
                    case Direction.U:
                        newWindow = new Window(_currentPosition.X, _currentPosition.Y - 1);
                        break;
                    case Direction.UR:
                        newWindow = new Window(_currentPosition.X + delta, _currentPosition.Y - delta);
                        break;
                    case Direction.R:
                        newWindow = new Window(_currentPosition.X + 1, _currentPosition.Y);
                        break;
                    case Direction.DR:
                        newWindow = new Window(_currentPosition.X + delta, _currentPosition.Y + delta);
                        break;
                    case Direction.D:
                        newWindow = new Window(_currentPosition.X, _currentPosition.Y + 1);
                        break;
                    case Direction.DL:
                        newWindow = new Window(_currentPosition.X - 1, _currentPosition.Y + 1);
                        break;
                    case Direction.L:
                        newWindow = new Window(_currentPosition.X - 1, _currentPosition.Y);
                        break;
                    case Direction.UL:
                        newWindow = new Window(_currentPosition.X - 1, _currentPosition.Y - 1);
                        break;
                    default:
                        break;
                }

                _currentPosition = Minor(newWindow, bombDirection);

                return _currentPosition;
            }

            private Window Minor(Window newWindow, Direction bombDirection)
            {
                if (_possibleJumps.Contains(newWindow))
                {
                    return newWindow;
                }

                return _possibleJumps.Single(j => j.IsInlineAndClosest(bombDirection, _currentPosition, newWindow, _possibleJumps));
            }

            private void DiminishPossibleJumps(Direction bombDirection)
            {
                IEnumerable<Window> newList = null;
                switch (bombDirection)
                {
                    case Direction.U:
                        newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y).ToList();
                        break;
                    case Direction.UR:
                        newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y && w.X > _currentPosition.X).ToList();
                        break;
                    case Direction.R:
                        newList = _possibleJumps.Where(w => w.X > _currentPosition.X).ToList();
                        break;
                    case Direction.DR:
                        newList = _possibleJumps.Where(w => w.Y > _currentPosition.Y && w.X > _currentPosition.X).ToList();
                        break;
                    case Direction.D:
                        newList = _possibleJumps.Where(w => w.Y > _currentPosition.Y).ToList();
                        break;
                    case Direction.DL:
                        newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y && w.X > _currentPosition.X).ToList();
                        break;
                    case Direction.L:
                        newList = _possibleJumps.Where(w => w.X < _currentPosition.X).ToList();
                        break;
                    case Direction.UL:
                        newList = _possibleJumps.Where(w => w.Y < _currentPosition.Y && w.X < _currentPosition.X).ToList();
                        break;
                    default:
                        break;
                }

                _possibleJumps = newList.ToList();
            }
        }

        public class Window
        {
            public Window(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int Y { get; private set; }

            public int X { get; private set; }

            public override string ToString()
            {
                return X + " " + Y;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }

                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                var other = obj as Window;
                return other != null && Equals(other);
            }

            private bool Equals(Window other)
            {
                return X == other.X && Y == other.Y;
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool IsInlineAndClosest(Direction bombDirection, Window _currentPosition, Window newWindow, List<Window> _possibleJumps)
            {
                throw new NotImplementedException();
            }
        }
    }
}
