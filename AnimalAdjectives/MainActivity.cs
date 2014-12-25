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
			Button button = FindViewById<Button> (Resource.Id.myButton);
			Button prevButton = FindViewById<Button> (Resource.Id.prevButton);

			TextView fullWordText = FindViewById<TextView> (Resource.Id.fullWordText);

			button.Click += delegate {
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
		}

		private void ShowImage() {
			ImageView pictureView = FindViewById<ImageView> (Resource.Id.pictureView);
			string currentImageName = handler.GetCurrentWordImageName ();
			ImageLoader loader = new ImageLoader (pictureView, null);
			loader.Execute (currentImageName);
		}
	}
}


