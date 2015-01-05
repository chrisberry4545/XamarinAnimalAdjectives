using System;

namespace AnimalAdjectivesPortable.PlatformSpecificInterfaces
{
	public interface IStorageInterface
	{
		void SaveToPreferences(string stringToSave);

		string GetFullStringFromPreferences();
	}
}

