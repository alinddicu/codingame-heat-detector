namespace codingame.heat.detector.build
{
	using System.IO;
	using System.Linq;
	using System.Text;

	public class Program
	{
		public static void Main(string[] args)
		{
			const string folderPath = "../../../codingame.heat.detector/";
			var contents = new StringBuilder();
			AppendFilesContents(folderPath, contents);

			File.WriteAllText("../../codingame.heat.detector.txt", contents.ToString());
		}

		private static void AppendFilesContents(string root, StringBuilder contents)
		{
			foreach (var file in Directory.EnumerateFiles(root, "*.cs").Where(f => !f.EndsWith("AssemblyInfo.cs")))
			{
				contents.AppendLine(File.ReadAllText(file));
				contents.AppendLine();
			}

			foreach (var d in Directory.GetDirectories(root))
			{
				AppendFilesContents(d, contents);
			}
		}
	}
}
