using System;
using Java.IO;
using Android.Content.Res;
using System.Collections.Generic;
using Android.App;

namespace AnimalAdjectives.Words
{
	public abstract class WordComponent
	{
		public string Text { get; set; }

		protected string ImageName{ get; set; }

		public WordComponent (String listFileName)
		{
			this.Text = GenerateText (listFileName);
		}

		public string GetImageSearchURL() {
			return ImageName;
		}

		private static String GenerateText( string listFileName) 
		{
			List<String> fullFileLines = ReadAllFileLines (listFileName);

			if (fullFileLines != null && fullFileLines.Count > 0) 
			{
				Random random = new Random ();
				int lineToUse = random.Next (0, fullFileLines.Count);
				return fullFileLines [lineToUse];
			}
			return null;
		}

		private static List<String> ReadAllFileLines(string listFileName) 
		{
			InputStreamReader input = new InputStreamReader(Application.Context.Assets.Open (listFileName));
			BufferedReader bufferedReader = new BufferedReader (input);
			List<String> allLines = new List<String> ();
			string line = bufferedReader.ReadLine();
			while (line != null) 
			{
				allLines.Add (line);
				line = bufferedReader.ReadLine ();
			}
			bufferedReader.Close ();
			return allLines;
		}
	
	}
}

