using System;
using Android.Graphics;
using Java.Net;
using System.Xml;
using System.IO;

namespace AnimalAdjectives.GoogleSearchUtils
{
	public class SearchUtils
	{
		public static readonly string GoogleSearchStart = "https://www.google.co.uk/search?q=";
		public static readonly string GoogleSearchEnd = "&safe=off&espv=210&es_sm=93&source=lnms&tbm=isch&sa=X&ei=8qJBU7eBCc2RhQeSmoDgCA&ved=0CAgQ_AUoAQ";

		public SearchUtils ()
		{
		}

		public static Bitmap GetFirstImageFromGoogleSearch(string searchURL) 
		{
			string fullSearchURL = GoogleSearchStart + searchURL + GoogleSearchEnd;
			return GetBitmapFromURL(GetImageSrc (fullSearchURL));
		}

		public static string GetImageSrc(string url) 
		{
			//Load the html for the url and create a html document from it.
			XmlDocument doc = new XmlDocument ();
			doc.Load (url);
			return GetFirstImageFromHtml (doc);
		}

		public static String GetFirstImageFromHtml(XmlDocument doc)//HTML Doc? Alt to JSoup 
		{
			//Get all image tags
			var allImages = doc.GetElementsByTagName("img");

			//Get src of first image tag
			if (allImages != null && allImages.Count > 0) {
				var firstImage =  allImages[0];
				return firstImage.ToString();
			}
			return null;
		}

		public static Bitmap GetBitmapFromURL(String src) {
			try {
				URL url = new URL(src);
				HttpURLConnection connection = (HttpURLConnection) url.OpenConnection();
				//connection.setDoInput(true);
				connection.Connect();
				InputStream input = connection.getInputStream();
				Bitmap myBitmap = BitmapFactory.decodeStream(input);
				return myBitmap;
			} catch (IOException e) {
				throw;
			}
		}

	}
}

