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
	public class SettingsFragment :  Fragment 
	{

		private readonly static int platformID = PlatformSpecificHandler.Android;
		private PlatformSpecificHandler platformSpecificHandler = new PlatformSpecificHandler(platformID);

		private View view;

		public override View OnCreateView (LayoutInflater inflater,
			ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			this.view = inflater.Inflate (
				Resource.Layout.Settings, container, false);

			return this.view;
		}
	}
}


