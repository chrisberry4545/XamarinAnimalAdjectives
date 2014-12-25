using System;
using Android.OS;
using Android.Graphics;
using Android.Widget;
using Android.Views;

namespace AnimalAdjectives.AndroidSpecific
{
	public class ImageLoader : AsyncTask
	{
		private ImageView _imageView;
		private View _spinner;

		public ImageLoader (ImageView imageView, View spinner)
		{
			_imageView = imageView;
			_spinner = spinner;
		}

		#region implemented abstract members of AsyncTask

		protected override Java.Lang.Object DoInBackground (params Java.Lang.Object[] imageSources)
		{
			string source = (string)imageSources[0];
			Bitmap firstImage = BitmapTools.GetFirstImageFromGoogleSearch (source);
			try {
				_imageView.SetImageBitmap (firstImage);
			} catch {

			}
			return null;
		}

		#endregion
	}
}

