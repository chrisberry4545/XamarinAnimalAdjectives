using System;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;

namespace AnimalAdjectivesPortable.Words
{
	public class CombinedAnimalAdjective
	{
		private WordComponent[] _wordComponents;
		public WordComponent[] WordComponents 
		{
			get {
				return _wordComponents;
			}
		}

		public String FullWord {
			get {
				string _fullWord = "";
				foreach (WordComponent w in _wordComponents) {
					if (_fullWord != "") {
						_fullWord += " ";
					}
					_fullWord += w.Text;
				}
				return _fullWord;
			}
		}

		public string GetImageName() {
			foreach (WordComponent wComp in WordComponents) {
				string imageSearchURL = wComp.GetImageSearchURL ();
				if (!String.IsNullOrEmpty(imageSearchURL)) {
					return imageSearchURL;
				}
			}
			return null;
		}

		public CombinedAnimalAdjective (PlatformSpecificHandler platformInterface)
		{
			_wordComponents = new WordComponent[2];
			_wordComponents [0] = new Adjective (platformInterface.FileReader);
			_wordComponents [1] = new Animal (platformInterface.FileReader);
		}

		public CombinedAnimalAdjective(WordComponent[] wordComponents) {
			this._wordComponents = wordComponents;
		}
	}
}

