using System;

namespace AnimalAdjectives.Favourites
{
	public interface StorageInterface
	{
		void SaveToPreferences(string stringToSave);

		string GetFullStringFromPreferences();
	}
}

