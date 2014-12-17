using System;

namespace AnimalAdjectives.Words
{
	public class Animal : WordComponent
	{

		public static readonly String animalsListName = "listofanimals.txt";
		public static readonly string animalImageTerm = "%20animal";

		public Animal () : base(animalsListName)
		{
			this.ImageName = this.Text + animalImageTerm;
		}
	}
}

