using System;
using Android.Net;

namespace AnimalAdjectives
{
	public class ConnectionTest
	{
		public ConnectionTest ()
		{
		}

		public static bool IsNetworkAvailable() {
			Android.Content.Context context = Android.App.Application.Context;
			ConnectivityManager connectivityManager 
			= (ConnectivityManager)context.GetSystemService(Android.Content.Context.ConnectivityService);
			NetworkInfo activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
			return activeNetworkInfo != null;
		}
	}
}

