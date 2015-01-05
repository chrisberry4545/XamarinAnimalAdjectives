using System;

namespace AnimalAdjectivesPortable.PlatformSpecificInterfaces
{
	public interface IMenuHandler
	{
		bool HandleMenuClick (int menuItemID);

		void OpenFavourites ();

		void OpenSettings ();
	}
}

