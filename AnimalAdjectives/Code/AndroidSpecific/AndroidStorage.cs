using System;
using AnimalAdjectivesPortable.Words;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using System.Collections.Generic;
using Android.Content;
using Android.Preferences;

namespace AnimalAdjectives.Code.AndroidSpecific
{
	public class AndroidStorage : IStorageInterface
	{
		private static readonly string favouritesStorageName = "animaladjectives";

		public AndroidStorage ()
		{
		}

		public void SaveToPreferences(string stringToSave) 
		{
			ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
			ISharedPreferencesEditor editor = preferences.Edit();
			editor.PutString(favouritesStorageName, stringToSave);
			editor.Commit();
		}

		public string GetFullStringFromPreferences() 
		{
			ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
			return preferences.GetString (favouritesStorageName, string.Empty);
		}
	}
}

