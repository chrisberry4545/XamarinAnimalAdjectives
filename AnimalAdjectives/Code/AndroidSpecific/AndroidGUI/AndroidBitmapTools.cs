using System;
using System.IO;
using Android.Graphics;
using AnimalAdjectivesPortable.GoogleSearchUtils;
using Java.Net;
using System.Net;

namespace AnimalAdjectives.Code.AndroidSpecific
{
	public class AndroidBitmapTools
	{
		public AndroidBitmapTools ()
		{
		}

		public static Bitmap GetFirstImageFromGoogleSearch(string searchURL) 
		{
			string fullSearchURL = SearchUtils.GoogleSearchStart + searchURL + SearchUtils.GoogleSearchEnd;
			String html;
			using (var client = new WebClient ()) {
				html = client.DownloadString (fullSearchURL);
			}

			if (html != null) {
				return GetBitmapFromURL (SearchUtils.GetImageSrc (html));
			} else {
				return null;
			}
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
				return null;
			}
		}
	}
}

