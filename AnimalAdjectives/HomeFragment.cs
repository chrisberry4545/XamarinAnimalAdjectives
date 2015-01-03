using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AnimalAdjectives.Words;
using AnimalAdjectives.Favourites;
using AnimalAdjectives.AndroidSpecific;
using AnimalAdjectives.PlatformSpecificInterfaces;

namespace AnimalAdjectives
{
	[Activity (Label = "Animal Adjectives", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class HomeFragment :  Fragment 
	{

		private AnimalAdjectiveHandler handler;
		private FavouritesManager favourites;

		private readonly static int platformID = PlatformSpecificHandler.Android;
		private PlatformSpecificHandler platformSpecificHandler = new PlatformSpecificHandler(platformID);

		private View view;

		private ImageView pictureView;
		private View spinner;

		private ImageView favsButton;


		private AndroidImageLoader loader;

		public HomeFragment(AnimalAdjectiveHandler aaHandler, FavouritesManager favs) {
			this.handler = aaHandler;
			this.favourites = favs;
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
				SetWord(handler.GetNextWord (), fullWordText);
			};
			prevButton.Click += delegate {
				SetWord(handler.GetPreviousWord (), fullWordText);
			};
			favsButton.Click += delegate {
				MainActivity.HandleFavouriteButtonClick(favsButton, this.favourites, handler.CurrentAnimalAdjective);
			};

			nextButton.CallOnClick ();

			return this.view;
		}

		private void SetWord(String text, TextView fullWordText) {
			if (!String.IsNullOrEmpty (text)) {
				fullWordText.Text = text;
				ShowImage();
				MainActivity.CheckIfFavourite (favsButton, this.favourites, this.handler.CurrentAnimalAdjective);
			}
		}

		private void ShowImage() {
			this.loader = MainActivity.ShowImage (this.pictureView, this.spinner, this.loader, this.handler.GetCurrentWordImageName());
		}


	}
}


