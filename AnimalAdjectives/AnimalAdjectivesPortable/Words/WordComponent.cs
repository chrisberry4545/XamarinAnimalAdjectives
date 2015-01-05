using System;
using System.Collections.Generic;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;


namespace AnimalAdjectivesPortable.Words
{
	public abstract class WordComponent
	{
		public string Text { get; set; }

		protected string ImageName{ get; set; }

		public WordComponent (String listFileName, IFileReader reader)
		{
			if (!String.IsNullOrEmpty (listFileName)) {
				this.Text = GenerateText (listFileName, reader);
			}
		}

		public string GetImageSearchURL() {
			return ImageName;
		}

		private String GenerateText( string listFileName, IFileReader reader) 
		{
			List<String> fullFileLines = reader.ReadAllFileLines (listFileName);

			if (fullFileLines != null && fullFileLines.Count > 0) 
			{
				Random random = new Random ();
				int lineToUse = random.Next (0, fullFileLines.Count);
				return fullFileLines [lineToUse];
			}
			return null;
		}
	
	}
}

