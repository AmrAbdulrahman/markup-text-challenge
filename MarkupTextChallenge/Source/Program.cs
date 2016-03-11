using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using ITDM;

/// <summary>
/// This program reads 'input' file and 'targets' file
/// and matches all targets in the input file
/// and surround matches with <mark></mark> tags
/// I use 3rd party code to read and parse command line arguments
/// </summary>
namespace MarkupTextChallenge 
{
	class MainClass
	{
		public static void Main(string[] args) 
		{
			ITDM.ConsoleCmdLine console = new ConsoleCmdLine();
			ITDM.CmdLineString targetFile = new CmdLineString ("target", true, "The target file path");
			ITDM.CmdLineString inputFile = new CmdLineString ("input", true, "The input file path");
			console.RegisterParameter(targetFile);
			console.RegisterParameter(inputFile);
			console.Parse(args);

			List<string> targets = File.ReadAllLines(targetFile).ToList();
			string input = File.ReadAllText(inputFile);

			string result = Challenge.MarkupString(input, targets);
			Console.Write(result);
		}
	}
}
