using System;

namespace AnimalAdjectives.PlatformSpecificInterfaces
{
	public interface IMenuHandler
	{
		bool HandleMenuClick (int menuItemID);

		void OpenFavourites ();

		void OpenSettings ();
	}
}

