using System;
using Java.IO;
using Android.App;
using System.Collections.Generic;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;

namespace AnimalAdjectives.Code.AndroidSpecific
{
	public class AndroidFileReader : IFileReader
	{

		public List<String> ReadAllFileLines(string listFileName) 
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

