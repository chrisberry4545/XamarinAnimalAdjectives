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

		public bool AnyFavourites() {
			if (favourites.Count > 0) {
				return true;
			}
			return false;
		}

		public string GetNextFavourite() {
			if (!AnyFavourites ()) {
				return null;
			}


			if (currentFavouriteIndex + 1 < favourites.Count) {
				currentFavouriteIndex++;
			} else {
				currentFavouriteIndex = 0;
			}
			return GetCurrentFavourite ().FullWord;
		}

		public string GetPreviousFavourite() {
			if (!AnyFavourites ()) {
				return null;
			}

			if (currentFavouriteIndex - 1 > -1) {
				currentFavouriteIndex--;
			} else {
				currentFavouriteIndex = favourites.Count - 1;
			}
			return GetCurrentFavourite ().FullWord;
		}

		public void AddToFavourites(CombinedAnimalAdjective combinedAnimalAdjective) {
			this.favourites.Add (combinedAnimalAdjective);
			this.CommitString (favourites);
		}

		public void RemoveFromFavourites(CombinedAnimalAdjective combinedAnimalAdjective) {
			RemoveFromFavourites (combinedAnimalAdjective.FullWord);
		}

		public void RemoveFromFavourites(string combinedAnimalAdjective) {
			this.favourites.RemoveAt (GetMatchingFavouriteIndex (combinedAnimalAdjective));
			this.CommitString (favourites);
		}

		public CombinedAnimalAdjective GetCurrentFavourite() {
			return favourites [currentFavouriteIndex];
		}

		public bool IsFavourite(CombinedAnimalAdjective combinedAnimalAdjective) {
			return IsFavourite (combinedAnimalAdjective.FullWord);
		}

		public bool IsFavourite(string combinedAnimalAdjective) {
			if (GetMatchingFavouriteIndex (combinedAnimalAdjective) != -1) {
				return true;
			}
			return false;
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
					Adjective adjective = new Adjective (splitS[0]);
					Animal animal = new Animal (splitS[1]);
					WordComponent[] wordComponents = new WordComponent[2];
					wordComponents [0] = adjective;
					wordComponents [1] = animal;
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
				stringToCommit += combinedAA + seperator;
			}

			if (!String.IsNullOrEmpty(stringToCommit) && stringToCommit.Length > 1) {
				string stringToSave = stringToCommit.Substring (0, stringToCommit.Length - 1);
				storage.SaveToPreferences (stringToSave);
			}
		}
	}
}

