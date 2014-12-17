using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AnimalAdjectives.Words;

namespace AnimalAdjectives
{
	[Activity (Label = "AnimalAdjectives", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

			TextView fullWordText = FindViewById<TextView> (Resource.Id.fullWordText);

			button.Click += delegate {
				CombinedAnimalAdjective aa = new CombinedAnimalAdjective();
				fullWordText.Text = aa.FullWord;
			};
		}
	}
}


