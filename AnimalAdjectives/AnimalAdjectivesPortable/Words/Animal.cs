using System;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;

namespace AnimalAdjectivesPortable.Words
{
	public class Animal : WordComponent
	{

		public static readonly String animalsListName = "listofanimals.txt";
		public static readonly string animalImageTerm = "%20animal";

		public Animal (IFileReader fileReader) : base(animalsListName, fileReader)
		{
			this.ImageName = this.Text + animalImageTerm;
		}

		public Animal(String text, IFileReader fileReader) : base(null, fileReader)
		{
			this.Text = text;
			this.ImageName = this.Text + animalImageTerm;
		}
	}
}

