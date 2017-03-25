namespace codingame.heat.detector.build
{
	using common.build.submit.file;

	public class Program
	{
		public static void Main(string[] args)
		{
			const string sourceFolderPath = "../../../codingame.heat.detector/";
			const string targetFilePath = "../../codingame.heat.detector.txt";
			new BuildSubmitFile().Build(sourceFolderPath, targetFilePath);
		}
	}
}
