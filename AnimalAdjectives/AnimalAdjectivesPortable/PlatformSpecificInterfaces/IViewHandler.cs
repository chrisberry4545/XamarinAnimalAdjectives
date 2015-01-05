using System;

namespace AnimalAdjectivesPortable.PlatformSpecificInterfaces
{
	public interface IViewHandler
	{
		void SetFavouriteSelectedImage(bool imageSelected, object favouriteButton);

		void SetInvisible(object viewObj);

		void SetVisible(object viewObj);

		void ChangeTextOfView(object textView, String newText);

	}
}

