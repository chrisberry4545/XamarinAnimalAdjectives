using System;
using System.IO;
using Android.Graphics;
using AnimalAdjectives.GoogleSearchUtils;
using Java.Net;

namespace AnimalAdjectives.AndroidSpecific
{
	public class BitmapTools
	{
		public BitmapTools ()
		{
		}

		public static Bitmap GetFirstImageFromGoogleSearch(string searchURL) 
		{
			string fullSearchURL = SearchUtils.GoogleSearchStart + searchURL + SearchUtils.GoogleSearchEnd;
			return GetBitmapFromURL(SearchUtils.GetImageSrc (fullSearchURL));
		}


		private static Bitmap GetBitmapFromURL(String src) {
			try {
				URL url = new URL(src);
				HttpURLConnection connection = (HttpURLConnection) url.OpenConnection();
				connection.DoInput = true;
				connection.Connect();
				Stream input = connection.InputStream;
				Bitmap myBitmap = BitmapFactory.DecodeStream(input);
				return myBitmap;
			} catch (IOException) {
				throw;
			}
		}
	}
}

