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
using AnimalAdjectives.Code.AndroidSpecific;
using AnimalAdjectivesPortable.Favourites;
using AnimalAdjectives;

namespace AnimalAdjectivesPortable
{
	[Activity (Label = "Animal Adjectives", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity :  Activity 
	{

		private PlatformSpecificHandler platformSpecificHandler;
		private AnimalAdjectiveHandler handler;
		private FavouritesManager favourites;

		private SharedGeneralGUIHandler sharedGeneralGUIHandler;
		private SharedHomeGUIHandler sharedHomeGUIHandler;
		private SharedFavouritesGUIHandler sharedFavouriteGUIHandler;

		protected override void OnCreate (Bundle bundle)
		{
			platformSpecificHandler = new PlatformSpecificHandler();

			platformSpecificHandler.StorageInterface = new AndroidStorage ();
			platformSpecificHandler.ViewHandler = new AndroidViewHandler ();
			platformSpecificHandler.ToastManager = new AndroidToastManager ();
			platformSpecificHandler.FileReader = new AndroidFileReader ();



			handler = new AnimalAdjectiveHandler(platformSpecificHandler);
			favourites = new FavouritesManager(platformSpecificHandler);

			this.sharedGeneralGUIHandler = new SharedGeneralGUIHandler (platformSpecificHandler);
			this.sharedFavouriteGUIHandler = new SharedFavouritesGUIHandler (platformSpecificHandler, sharedGeneralGUIHandler);
			this.sharedHomeGUIHandler = new SharedHomeGUIHandler (platformSpecificHandler, sharedGeneralGUIHandler);

			base.OnCreate (bundle);

			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			this.AddTab ("", Resource.Drawable.ic_action_play, new HomeFragment (handler, favourites, sharedGeneralGUIHandler, sharedHomeGUIHandler));
			this.AddTab ("", Resource.Drawable.ic_action_favorite2, new FavouritesFragment (handler, favourites, sharedGeneralGUIHandler, sharedFavouriteGUIHandler));
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

		public static AndroidImageLoader ShowImage(ImageView pictureView, View spinner, AndroidImageLoader loader, string animalImageName) {

			AndroidViewHandler imageSetter = new AndroidViewHandler ();
			imageSetter.SetInvisible (pictureView);
			if (AndroidConnectionTest.IsNetworkAvailable ()) {
				imageSetter.SetVisible (spinner);

				if (loader != null && !loader.IsCancelled) {
					loader.Cancel (true);
					loader.Dispose ();
				}
				string currentImageName = animalImageName;
				loader = new AndroidImageLoader (pictureView, spinner);
				loader.Execute (currentImageName);
			} else {
				imageSetter.SetInvisible (spinner);
			}

			return loader;
		}

	}
}


