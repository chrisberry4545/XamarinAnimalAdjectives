using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AnimalAdjectivesPortable.Words;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using AnimalAdjectivesPortable.SharedGUIHandler;
using AnimalAdjectivesPortable.Favourites;
using AnimalAdjectives;
using AnimalAdjectives.Code.AndroidSpecific;

namespace AnimalAdjectivesPortable
{
	[Activity (Label = "Animal Adjectives", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class HomeFragment :  Fragment 
	{

		private AnimalAdjectiveHandler handler;
		private FavouritesManager favourites;

		private PlatformSpecificHandler platformSpecificHandler = new PlatformSpecificHandler();

		private View view;

		private ImageView pictureView;
		private View spinner;

		private ImageView favsButton;
		private AndroidImageLoader loader;

		private SharedGeneralGUIHandler _sharedGUIHandler;
		private SharedHomeGUIHandler _sharedHomeGUIHandler;

		public HomeFragment(AnimalAdjectiveHandler aaHandler, FavouritesManager favs, 
			SharedGeneralGUIHandler sharedGUIHandler, SharedHomeGUIHandler sharedHomeGUIHandler) {
			this.handler = aaHandler;
			this.favourites = favs;

			this._sharedGUIHandler = sharedGUIHandler;
			this._sharedHomeGUIHandler = sharedHomeGUIHandler;
		}

		public override View OnCreateView (LayoutInflater inflater,
			ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			this.view = inflater.Inflate (
				Resource.Layout.Home, container, false);

			this.pictureView = view.FindViewById<ImageView> (Resource.Id.pictureView);
			this.spinner = view.FindViewById (Resource.Id.spinner);

			// Get our button from the layout resource,
			// and attach an event to it
			View nextButton = view.FindViewById (Resource.Id.nextButton);
			View prevButton = view.FindViewById (Resource.Id.prevButton);
			this.favsButton = view.FindViewById<ImageView> (Resource.Id.favImageButton);

			TextView fullWordText = view.FindViewById<TextView> (Resource.Id.fullWordText);

			nextButton.Click += delegate {
				HandleClickResult(_sharedHomeGUIHandler.NextWord(handler, fullWordText, favsButton, favourites));
			};
			prevButton.Click += delegate {
				HandleClickResult(_sharedHomeGUIHandler.PreviousWord(handler, fullWordText, favsButton, favourites));
			};
			favsButton.Click += delegate {
				_sharedGUIHandler.HandleFavouriteButtonClick(favsButton, this.favourites, handler.CurrentAnimalAdjective);
			};

			nextButton.CallOnClick ();

			return this.view;
		}

		public void HandleClickResult(bool result) {
			if (result) {
				this.ShowImage ();
			}
		}

		private void ShowImage() {
			this.loader = MainActivity.ShowImage (this.pictureView, this.spinner, this.loader, this.handler.GetCurrentWordImageName());
		}


	}
}


