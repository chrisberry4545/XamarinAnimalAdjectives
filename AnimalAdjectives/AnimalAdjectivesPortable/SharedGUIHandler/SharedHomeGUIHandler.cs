using System;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using AnimalAdjectivesPortable.Words;
using AnimalAdjectivesPortable.Favourites;

namespace AnimalAdjectivesPortable.SharedGUIHandler
{
	public class SharedHomeGUIHandler
	{
		private PlatformSpecificHandler platformHandler;
		private SharedGeneralGUIHandler _sharedGUIHandler;

		public SharedHomeGUIHandler (PlatformSpecificHandler handler, SharedGeneralGUIHandler sharedGUIHandler)
		{
			platformHandler = handler;
			_sharedGUIHandler = sharedGUIHandler;
		}


		public bool NextWord(AnimalAdjectiveHandler handler, object textView, object favsButton, FavouritesManager favsManager) {
			return this.ShowNextWord (handler.GetNextWord(), textView, favsButton, handler, favsManager);
		}

		public bool PreviousWord(AnimalAdjectiveHandler handler, object textView, object favsButton, FavouritesManager favsManager) {
			return this.ShowNextWord (handler.GetPreviousWord(), textView, favsButton, handler, favsManager);
		}

		private bool ShowNextWord(String text, object textView, object favsButton, AnimalAdjectiveHandler handler, FavouritesManager favsManager) {
			if (!String.IsNullOrEmpty(text)) {
				this.platformHandler.ViewHandler.ChangeTextOfView (textView, text);
				this._sharedGUIHandler.CheckIfFavourite (favsButton, favsManager, handler.CurrentAnimalAdjective);
				return true;
			} else {
				return false;
			}
		}
	}
}

