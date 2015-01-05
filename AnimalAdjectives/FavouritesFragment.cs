using System;
using Android.App;
using Android.Widget;
using Android.Views;
using AnimalAdjectivesPortable.Words;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using Android.OS;
using AnimalAdjectivesPortable.SharedGUIHandler;
using AnimalAdjectivesPortable.Favourites;
using AnimalAdjectives.Code.AndroidSpecific;
using AnimalAdjectives;

namespace AnimalAdjectivesPortable
{
	public class FavouritesFragment : Fragment
	{
		private AnimalAdjectiveHandler handler;
		private FavouritesManager favourites;

		private View view;

		private ImageView pictureView;
		private View spinner;
		private AndroidImageLoader loader;

		private TextView fullWordText;

		private ImageView favsButton;

		private SharedGeneralGUIHandler _sharedGUIHandler;
		private SharedFavouritesGUIHandler _favouritesGUIHandler;

		public FavouritesFragment(AnimalAdjectiveHandler aaHandler, FavouritesManager favs, 
			SharedGeneralGUIHandler sharedGUIHandler, SharedFavouritesGUIHandler favouritesGUIHandler) {
			this.handler = aaHandler;
			this.favourites = favs;

			this._sharedGUIHandler = sharedGUIHandler;
			this._favouritesGUIHandler = favouritesGUIHandler;
		}

		public override View OnCreateView (LayoutInflater inflater,
			ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			this.view = inflater.Inflate (
				Resource.Layout.Favourites, container, false);

			this.pictureView = view.FindViewById<ImageView> (Resource.Id.pictureView);
			this.spinner = view.FindViewById (Resource.Id.spinner);

			// Get our button from the layout resource,
			// and attach an event to it
			View nextButton = view.FindViewById (Resource.Id.nextButton);
			View prevButton = view.FindViewById (Resource.Id.prevButton);
			this.favsButton = view.FindViewById<ImageView> (Resource.Id.favViewFavButton);

			this.fullWordText = view.FindViewById<TextView> (Resource.Id.fullWordText);

			nextButton.Click += delegate {
				HandleShowingImageResult(this._favouritesGUIHandler.
					NextFavourite(favourites, fullWordText, this.favsButton));
			};
			prevButton.Click += delegate {
				HandleShowingImageResult(this._favouritesGUIHandler.PreviousFavourite
					(favourites, fullWordText, this.favsButton));
			};
			favsButton.Click += delegate {
				_sharedGUIHandler.HandleFavouriteButtonClick
				(favsButton, this.favourites, this.favourites.GetCurrentFavourite());
			};

			HandleShowingImageResult (_favouritesGUIHandler.ShowCurrentFavourite 
				(favourites, fullWordText, this.favsButton));
			return view;

		}

		private void HandleShowingImageResult(bool result) {
			if (result) {
				ShowImage ();
			} else {
				HandleNullFav ();
			}
		}

		private void ShowImage() {
			this.loader = MainActivity.ShowImage (this.pictureView, this.spinner, this.loader, this.favourites.GetCurrentFavourite().GetImageName());
		}

		private void HandleNullFav() {
			_favouritesGUIHandler.HandleNullFav(fullWordText, this.spinner, this.pictureView);
		}
	}
}

