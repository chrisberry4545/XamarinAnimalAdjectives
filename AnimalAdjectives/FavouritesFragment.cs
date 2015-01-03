using System;
using Android.App;
using Android.Widget;
using Android.Views;
using AnimalAdjectives.Words;
using AnimalAdjectives.Favourites;
using Android.OS;
using AnimalAdjectives.AndroidSpecific;

namespace AnimalAdjectives
{
	public class FavouritesFragment : Fragment
	{
		private AnimalAdjectiveHandler handler;
		private FavouritesManager favourites;

		private View view;

		private ImageView pictureView;
		private View spinner;
		private AndroidImageLoader loader;

		private ImageView favsButton;

		public FavouritesFragment(AnimalAdjectiveHandler aaHandler, FavouritesManager favs) {
			this.handler = aaHandler;
			this.favourites = favs;
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

			TextView fullWordText = view.FindViewById<TextView> (Resource.Id.fullWordText);

			nextButton.Click += delegate {
				SetNewFavourite(favourites.GetNextFavourite(), fullWordText);
			};
			prevButton.Click += delegate {
				SetNewFavourite(favourites.GetPreviousFavourite(), fullWordText);
			};
			favsButton.Click += delegate {
				MainActivity.HandleFavouriteButtonClick(favsButton, this.favourites, this.favourites.GetCurrentFavourite());
			};


			SetNewFavourite (favourites.GetCurrentFavourite ().FullWord, fullWordText);

			return view;

		}

		private void SetNewFavourite(String text, TextView fullWordText) {
			if (!String.IsNullOrEmpty(text)) {
				fullWordText.Text = text;
				ShowImage();
				MainActivity.CheckIfFavourite (favsButton, this.favourites, this.favourites.GetCurrentFavourite());
			} else {
				HandleNullFav(fullWordText);
			}
		}

		private void HandleNullFav(TextView fullWordText) {
			fullWordText.Text = "You currently have no favourites selected.";
			AndroidImageLoader.SetInvisible (this.spinner);
			AndroidImageLoader.SetInvisible (this.pictureView);
		}

		private void ShowImage() {
			this.loader = MainActivity.ShowImage (this.pictureView, this.spinner, this.loader, this.favourites.GetCurrentFavourite().GetImageName());
		}
	}
}

