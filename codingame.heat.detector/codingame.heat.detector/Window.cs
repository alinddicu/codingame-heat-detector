namespace codingame.heat.detector
{
	public class Window
	{
		public Window(string readLine)
		{
			var inputs = readLine.Split(' ');
			X = int.Parse(inputs[0]);
			Y = int.Parse(inputs[1]);
		}

		public Window(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int Y { get; }

		public int X { get; }

		public override string ToString()
		{
			return X + " " + Y;
		}
	}
}