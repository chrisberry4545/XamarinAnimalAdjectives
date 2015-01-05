using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AnimalAdjectivesPortable.Words;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using AnimalAdjectives;

namespace AnimalAdjectivesPortable
{
	[Activity (Label = "Animal Adjectives", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class SettingsFragment :  Fragment 
	{

		private PlatformSpecificHandler platformSpecificHandler = new PlatformSpecificHandler();

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


