using System;
using Android.Widget;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;

namespace AnimalAdjectives.Code.AndroidSpecific
{
	public class AndroidToastManager : IToastManager
	{
		public void ShowToast(String toastText) {
			Toast toast = Toast.MakeText(Android.App.Application.Context, toastText, 0);
			toast.Show();
		}
	}
}

