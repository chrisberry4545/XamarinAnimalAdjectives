using System;
using AnimalAdjectives.Words;
using System.Collections.Generic;
using AnimalAdjectives.AndroidSpecific;

namespace AnimalAdjectives.Favourites
{
	public class FavouritesManager
	{
		private int currentFavouriteIndex = 0;
		private StorageInterface storage = new AndroidStorage();
		private List<CombinedAnimalAdjective> favourites;

		public static readonly char seperator = '|';
		public static readonly char animalToAdjectiveSeperator = '=';

		public FavouritesManager ()
		{
			favourites = this.GetStoredString ();
		}

		public string GetNextFavourite() {
			if (currentFavouriteIndex + 1 < favourites.Count) {
				currentFavouriteIndex++;
				return GetCurrentFavourite ().FullWord;
			}
			return null;
		}

		public string GetPreviousFavourite() {
			if (favourites.Count > 0 && currentFavouriteIndex - 1 > -1) {
				currentFavouriteIndex--;
				return GetCurrentFavourite ().FullWord;
			}
			return null;
		}

		public void AddToFavourites(CombinedAnimalAdjective combinedAnimalAdjective) {
			this.favourites.Add (combinedAnimalAdjective);
			this.CommitString (favourites);
		}

		public void RemoveFromFavourites(string combinedAnimalAdjective) {
			this.favourites.RemoveAt (GetMatchingFavouriteIndex (combinedAnimalAdjective));
			this.CommitString (favourites);
		}

		public CombinedAnimalAdjective GetCurrentFavourite() {
			return favourites [currentFavouriteIndex];
		}

		private int GetMatchingFavouriteIndex(string combinedAnimalAdjective) {
			for (int i = 0; i < favourites.Count; i++) {
				if (favourites[i].FullWord.Equals(combinedAnimalAdjective)) {
					return i;
				}
			}
			return  -1;
		}


		private List<CombinedAnimalAdjective> GetStoredString() {
			string fullString = storage.GetFullStringFromPreferences ();
			string[] splitString = fullString.Split (seperator);
			List<CombinedAnimalAdjective> allStoredAAs = new List<CombinedAnimalAdjective> ();
			foreach (string s in splitString) {
				if (!String.IsNullOrEmpty (s)) {
					string[] splitS = s.Split (animalToAdjectiveSeperator);
					Animal animal = new Animal (splitS[0]);
					Adjective adjective = new Adjective (splitS[1]);
					WordComponent[] wordComponents = new WordComponent[2];
					wordComponents [0] = animal;
					wordComponents [1] = adjective;
					CombinedAnimalAdjective combined = new CombinedAnimalAdjective (wordComponents);
					allStoredAAs.Add (combined);
				}
			}
			return allStoredAAs;
		}

		private void CommitString(List<CombinedAnimalAdjective> animalAdjectives) {
			string stringToCommit = "";
			foreach (var aa in animalAdjectives) {
				string combinedAA = aa.WordComponents [0].Text + animalToAdjectiveSeperator + aa.WordComponents [1].Text;
				stringToCommit = combinedAA + seperator;
			}

			if (!String.IsNullOrEmpty(stringToCommit) && stringToCommit.Length > 2) {
				string stringToSave = stringToCommit.Substring (0, stringToCommit.Length - 2);
				storage.SaveToPreferences (stringToSave);
			}
		}
	}
}

