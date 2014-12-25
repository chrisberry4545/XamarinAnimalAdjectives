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

namespace AnimalAdjectives
{
	[Activity (Label = "AnimalAdjectives", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		private AnimalAdjectiveHandler handler = new AnimalAdjectiveHandler();
		private FavouritesManager favourites = new FavouritesManager();

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button nextButton = FindViewById<Button> (Resource.Id.nextButton);
			Button prevButton = FindViewById<Button> (Resource.Id.prevButton);

			TextView fullWordText = FindViewById<TextView> (Resource.Id.fullWordText);

			nextButton.Click += delegate {
				string nextWord = handler.GetNextWord();
				if (!String.IsNullOrEmpty(nextWord)) {
					fullWordText.Text = nextWord;
					ShowImage();
				}
			};

			prevButton.Click += delegate {
				string prevWord = handler.GetPreviousWord ();
				if (!String.IsNullOrEmpty (prevWord)) {
					fullWordText.Text = prevWord;
					ShowImage();
				}
			};

			nextButton.CallOnClick ();
		}

		private ImageLoader loader;
		private void ShowImage() {
			ImageView pictureView = FindViewById<ImageView> (Resource.Id.pictureView);
			View spinner = FindViewById (Resource.Id.spinner);

			ImageLoader.SetInvisible (pictureView);
			ImageLoader.SetVisible (spinner);

			if (loader != null && !loader.IsCancelled) {
				loader.Cancel (true);
				loader.Dispose ();
			}
			string currentImageName = handler.GetCurrentWordImageName ();
			loader = new ImageLoader (pictureView, spinner);
			loader.Execute (currentImageName);
		}
	}
}


