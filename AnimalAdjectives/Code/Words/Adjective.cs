using System;

namespace AnimalAdjectives.Words
{
	public class Adjective : WordComponent
	{

		public static readonly String adjectivesListName = "listofadjectives.txt";

		public Adjective (): base(adjectivesListName)
		{
		}
	}
}

