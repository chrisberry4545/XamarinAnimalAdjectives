using System;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using AnimalAdjectivesPortable.Words;
using AnimalAdjectivesPortable.Favourites;

namespace AnimalAdjectivesPortable.SharedGUIHandler
{
	public class SharedGeneralGUIHandler
	{
		private PlatformSpecificHandler platformHandler;

		public SharedGeneralGUIHandler (PlatformSpecificHandler handler)
		{
			platformHandler = handler;
		}

		public void HandleFavouriteButtonClick(object favouriteButton, FavouritesManager favouritesManager, CombinedAnimalAdjective animalAdjective) {
			if (favouritesManager.IsFavourite (animalAdjective)) {
				platformHandler.ViewHandler.SetFavouriteSelectedImage (false, favouriteButton);
				favouritesManager.RemoveFromFavourites (animalAdjective);
				this.platformHandler.ToastManager.ShowToast(animalAdjective.FullWord + " added to favourites.");
			} else {
				platformHandler.ViewHandler.SetFavouriteSelectedImage (true, favouriteButton);
				favouritesManager.AddToFavourites (animalAdjective);
				this.platformHandler.ToastManager.ShowToast(animalAdjective.FullWord + " removed from favourites.");
			}
		}

		public void CheckIfFavourite(object favouriteButton, FavouritesManager favouritesManager, CombinedAnimalAdjective animalAdjective) {
			if (favouritesManager.IsFavourite (animalAdjective)) {
				platformHandler.ViewHandler.SetFavouriteSelectedImage (true, favouriteButton);
			} else {
				platformHandler.ViewHandler.SetFavouriteSelectedImage (false, favouriteButton);
			}
		}
	}
}

