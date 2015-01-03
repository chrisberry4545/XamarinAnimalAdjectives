using System;
using AnimalAdjectives.AndroidSpecific;

namespace AnimalAdjectives.PlatformSpecificInterfaces
{
	public class PlatformSpecificHandler
	{
		private int _platformID;
		public const int IOS = 0;
		public const int Android = 1;

		public IMenuHandler MenuHandler {get;set;}

		public PlatformSpecificHandler (int platformID)
		{
			this._platformID = platformID;

			switch (platformID) {
			case IOS:
				SetUpIOS ();
				break;
			case Android:
				SetUpAndroid ();
				break;
			}
		}

		private void SetUpAndroid() {
			this.MenuHandler = new AndroidMenuHandler ();
		}

		private void SetUpIOS() {

		}
	}
}

