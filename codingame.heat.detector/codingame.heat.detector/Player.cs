namespace codingame.heat.detector
{
    using System;

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

            private Window _currentPosition;

            public Building(int width, int height, Window intialPosition)
            {
                _width = width;
                _height = height;
                _currentPosition = intialPosition;
            }

            public Window PredictJump(Direction bombDirection)
            {
                throw new NotImplementedException();
            }
        }

        public class Window
        {
            private readonly int _y;
            private readonly int _x;

            public Window(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public override string ToString()
            {
                return _x + " " + _y;
            }
        }
    }
}
