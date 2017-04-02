namespace codingame.heat.detector.build
{
	using System.IO;
	using common.build.submit.file;

	public class Program
	{
		public static void Main(string[] args)
		{
			var sourceFolder = new DirectoryInfo("../../../codingame.heat.detector/");
			var targetFile = new FileInfo("../../codingame.heat.detector.txt");
			new BuildSubmitFile().Build(sourceFolder, targetFile);
		}
	}
}
