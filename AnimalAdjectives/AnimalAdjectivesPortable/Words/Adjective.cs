using System;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;

namespace AnimalAdjectivesPortable.Words
{
	public class Adjective : WordComponent
	{

		public static readonly String adjectivesListName = "listofadjectives.txt";

		public Adjective (IFileReader fileReader): base(adjectivesListName, fileReader)
		{
		}

		public Adjective(String text, IFileReader fileReader) : base(null, fileReader)
		{
			this.Text = text;
		}
	}
}

