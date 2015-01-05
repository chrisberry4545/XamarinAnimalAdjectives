using System;
using AnimalAdjectives.PlatformSpecificInterfaces;
using Android.Views;
using Android.Widget;

namespace AnimalAdjectives
{
	public class AndroidPictureAndSpinner : IPictureAndSpinner
	{
		public AndroidPictureAndSpinner ()
		{

		}

		public View Spinner {get;set;}

		public ImageView Image { get; set;}
	}
}

