using System;
using Android.Views;
using AnimalAdjectives.PlatformSpecificInterfaces;
using Android.Content;

namespace AnimalAdjectives.AndroidSpecific
{
	public class AndroidMenuHandler : IMenuHandler
	{
		public AndroidMenuHandler ()
		{

		}

		public bool HandleMenuClick(int menuItemID) {
			// Handle item selection
			switch (menuItemID) {
			case Resource.Id.favouritesMenuItem:
				OpenFavourites ();
				return true;
			case Resource.Id.settingsMenuItem:
				OpenSettings ();
				return true;
			default:
				return false;
			}
		}

		public void OpenFavourites() {
			Android.App.Application.Context.StartActivity (typeof(FavouritesFragment));
		}

		public void OpenSettings() {

		}
	}
}

