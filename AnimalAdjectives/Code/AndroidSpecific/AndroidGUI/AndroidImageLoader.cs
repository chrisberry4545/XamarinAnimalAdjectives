using System;
using Android.OS;
using Android.Graphics;
using Android.Widget;
using Android.Views;

namespace AnimalAdjectives.Code.AndroidSpecific
{
	public class AndroidImageLoader : AsyncTask<String, String, Bitmap>
	{
		private ImageView _imageView;
		private View _spinner;

		private Bitmap foundImage;

		public AndroidImageLoader (ImageView imageView, View spinner)
		{
			_imageView = imageView;
			_spinner = spinner;
		}

		protected override Bitmap RunInBackground(params string[] strings) 
		{
				string source = strings[0];
				foundImage = AndroidBitmapTools.GetFirstImageFromGoogleSearch (source);
				return foundImage;
		}


		protected override void OnPostExecute(Bitmap result) {
			if (!this.IsCancelled && foundImage != null) {
				AndroidViewHandler imageHandler = new AndroidViewHandler ();
				imageHandler.SetVisible(_imageView);
				imageHandler.SetInvisible(_spinner);
				_imageView.SetImageBitmap (foundImage);
			}
		}
	}
}

