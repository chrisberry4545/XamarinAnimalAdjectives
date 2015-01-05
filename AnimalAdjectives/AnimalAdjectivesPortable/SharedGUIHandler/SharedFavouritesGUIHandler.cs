using System;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using AnimalAdjectivesPortable.Favourites;

namespace AnimalAdjectivesPortable.SharedGUIHandler
{
	public class SharedFavouritesGUIHandler
	{
		private PlatformSpecificHandler platformHandler;
		private SharedGeneralGUIHandler _generalGUIHandler;

		public SharedFavouritesGUIHandler (PlatformSpecificHandler handler, SharedGeneralGUIHandler generalGUIHandler)
		{
			platformHandler = handler;
			this._generalGUIHandler = generalGUIHandler;
		}

		public void HandleNullFav(object fullWordTextView, object spinner, object pictureView) {
			platformHandler.ViewHandler.SetInvisible (pictureView);
			platformHandler.ViewHandler.SetInvisible (spinner);
			platformHandler.ViewHandler.ChangeTextOfView (fullWordTextView, "You currently have no favourites selected.");
		}

		public void SetNewText(object textView, String newText) {
			platformHandler.ViewHandler.ChangeTextOfView (textView, newText);
		}

		public bool NextFavourite(FavouritesManager favsManager, object textView, object favsButton) {
			return this.SetNewFavourite (favsManager.GetNextFavourite (), textView, favsButton, favsManager);
		}

		public bool PreviousFavourite(FavouritesManager favsManager, object textView, object favsButton) {
			return this.SetNewFavourite (favsManager.GetPreviousFavourite (), textView, favsButton, favsManager);
		}

		public bool ShowCurrentFavourite(FavouritesManager favsManager, object textView, object favsButton) {
			return this.SetNewFavourite (favsManager.GetCurrentFavourite ().FullWord, textView, favsButton, favsManager);
		}

		private bool SetNewFavourite(String text, object textView, object favsButton, FavouritesManager favsManager) {
			if (!String.IsNullOrEmpty(text)) {
				this.platformHandler.ViewHandler.ChangeTextOfView (textView, text);
				this._generalGUIHandler.CheckIfFavourite (favsButton, favsManager, favsManager.GetCurrentFavourite());
				return true;
			} else {
				return false;
			}
		}
	}
}

