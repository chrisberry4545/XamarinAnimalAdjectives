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
	public class MainActivity :  Activity 
	{

		private AnimalAdjectiveHandler handler = new AnimalAdjectiveHandler();
		private FavouritesManager favourites = new FavouritesManager();

		private readonly static int platformID = PlatformSpecificHandler.Android;
		private PlatformSpecificHandler platformSpecificHandler = new PlatformSpecificHandler(platformID);

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			this.AddTab ("", Resource.Drawable.ic_action_play, new HomeFragment ());
			this.AddTab ("", Resource.Drawable.ic_action_favorite2, new FavouritesFragment ());
			this.AddTab ("", Resource.Drawable.ic_action_settings, new SettingsFragment ());

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


		}

		private void AddTab (string tabText, int iconResourceId, Fragment view)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);
			tab.SetIcon (iconResourceId);

			// must set event handler before adding tab
			tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e)
			{
				var fragment = this.FragmentManager.FindFragmentById(Resource.Id.mainLayout);
				if (fragment != null)
					e.FragmentTransaction.Remove(fragment);         
				e.FragmentTransaction.Add (Resource.Id.mainLayout, view);
			};
			tab.TabUnselected += delegate(object sender, ActionBar.TabEventArgs e) {
				e.FragmentTransaction.Remove(view);
			};

			this.ActionBar.AddTab (tab);
		}

		public static AndroidImageLoader ShowImage(ImageView pictureView, View spinner, AndroidImageLoader loader, AnimalAdjectiveHandler handler) {

			AndroidImageLoader.SetInvisible (pictureView);
			if (AndroidConnectionTest.IsNetworkAvailable ()) {
				AndroidImageLoader.SetVisible (spinner);

				if (loader != null && !loader.IsCancelled) {
					loader.Cancel (true);
					loader.Dispose ();
				}
				string currentImageName = handler.GetCurrentWordImageName ();
				loader = new AndroidImageLoader (pictureView, spinner);
				loader.Execute (currentImageName);
			} else {
				AndroidImageLoader.SetInvisible (spinner);
			}

			return loader;
		}

	}
}


