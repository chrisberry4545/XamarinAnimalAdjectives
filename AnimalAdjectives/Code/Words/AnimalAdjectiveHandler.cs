using System;
using System.Collections.Generic;

namespace AnimalAdjectives.Words
{
	public class AnimalAdjectiveHandler
	{
		private List<CombinedAnimalAdjective> animalAdjectives;
		private int currentListIndex = -1;

		public AnimalAdjectiveHandler() 
		{
			animalAdjectives = new List<CombinedAnimalAdjective>();
		}

		public string GetNextWord() 
		{
			currentListIndex++;
			if (currentListIndex > animalAdjectives.Count - 1) {
				//Create a new animal adjective
				CombinedAnimalAdjective aa = new CombinedAnimalAdjective();
				animalAdjectives.Add(aa);
				return aa.FullWord;
			}

			if (animalAdjectives.Count == 21) {
				animalAdjectives.RemoveAt (0);
				currentListIndex = 19;
			}

			return animalAdjectives [currentListIndex].FullWord;
		}

		public string GetCurrentWordImageName() {
			return animalAdjectives [currentListIndex].GetImageName ();
		}

		public string GetPreviousWord() {
			if (currentListIndex - 1 < 0) {
				return null;
			} else {
				currentListIndex--;
				return animalAdjectives [currentListIndex].FullWord;
			}
		}
	}
}

