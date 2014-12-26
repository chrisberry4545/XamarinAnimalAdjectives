using System;
using Android.OS;
using Android.Graphics;
using Android.Widget;
using Android.Views;

namespace AnimalAdjectives.AndroidSpecific
{
	public class ImageLoader : AsyncTask<String, String, Bitmap>
	{
		private ImageView _imageView;
		private View _spinner;

		private Bitmap foundImage;

		public ImageLoader (ImageView imageView, View spinner)
		{
			_imageView = imageView;
			_spinner = spinner;
		}

		protected override Bitmap RunInBackground(params string[] strings) 
		{
				string source = strings[0];
				foundImage = BitmapTools.GetFirstImageFromGoogleSearch (source);
				return foundImage;
		}


		protected override void OnPostExecute(Bitmap result) {
			if (!this.IsCancelled && foundImage != null) {
				SetVisible(_imageView);
				SetInvisible(_spinner);
				_imageView.SetImageBitmap (foundImage);
			}
		}

		public static void SetInvisible(View view) {
			view.Visibility = ViewStates.Gone;
		}

		public static void SetVisible(View view) {
			view.Visibility = ViewStates.Visible;
		}
	}
}

