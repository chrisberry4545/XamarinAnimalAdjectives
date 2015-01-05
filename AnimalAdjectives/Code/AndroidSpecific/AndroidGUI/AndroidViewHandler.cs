using System;
using AnimalAdjectivesPortable.PlatformSpecificInterfaces;
using Android.Widget;
using Android.Views;

namespace AnimalAdjectives.Code.AndroidSpecific
{
	public class AndroidViewHandler : IViewHandler
	{
		public AndroidViewHandler ()
		{
		}

		public void SetFavouriteSelectedImage(bool isFavouriteSelected, object favouriteButton) 
		{
			ImageView favsButton = (ImageView)favouriteButton;

			if (isFavouriteSelected) {
				favsButton.SetImageResource (Resource.Drawable.ic_action_favorite_selected2);
			} else {
				favsButton.SetImageResource (Resource.Drawable.ic_action_favorite2);
			}

		}

		public void SetInvisible(object viewObj) {
			View view = (View)viewObj;
			view.Visibility = ViewStates.Gone;
		}

		public void SetVisible(object viewObj) {
			View view = (View)viewObj;
			view.Visibility = ViewStates.Visible;
		}

		public void ChangeTextOfView(object textView, String newText) {
			TextView convertedTextView = (TextView)textView;
			convertedTextView.SetTextKeepState (newText);
			//convertedTextView.SetText (newText);
		}

		public void DisplayToast(String toastText) {

		}


	}
}

