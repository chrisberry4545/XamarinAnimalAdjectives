using System;
using Android.OS;
using Android.Graphics;
using Android.Widget;
using Android.Views;

namespace AnimalAdjectives.ImageHandlers
{
	public class ImageLoader : AsyncTask
	{
		public ImageLoader (ImageView imageView, View spinner)
		{

		}

		#region implemented abstract members of AsyncTask

		protected override Java.Lang.Object DoInBackground (params Java.Lang.Object[] imageSources)
		{
			string source = (string)imageSources[0];

			return null;
		}

		#endregion
	}
}

