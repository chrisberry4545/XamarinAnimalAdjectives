using System;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Net;


namespace AnimalAdjectivesPortable.GoogleSearchUtils
{
	public class SearchUtils
	{
		public static readonly string GoogleSearchStart = "https://www.google.co.uk/search?q=";
		public static readonly string GoogleSearchEnd = "&safe=off&espv=210&es_sm=93&source=lnms&tbm=isch&sa=X&ei=8qJBU7eBCc2RhQeSmoDgCA&ved=0CAgQ_AUoAQ";

		public SearchUtils ()
		{
		}

		public static string GetImageSrc(string html) 
		{
			/*I had to use this method to parse the HTML as you can't include
			3rd party libraries in Xamarin free version.*/

				int indexOfFirstImg = html.IndexOf("<img");
				html = html.Substring (indexOfFirstImg);

				int indexOfImgSrc = html.IndexOf ("src=");

				html = html.Substring (indexOfImgSrc + 5);

				//Find first double quote
				int indexOfEndOfImgSrc = html.IndexOf ("\"");
				html = html.Substring (0, indexOfEndOfImgSrc);

				return html;
		}


	}
}

