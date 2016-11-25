using System;

using Foundation;
using UIKit;

namespace Jim.iOS
{
	public partial class UserViewCell : UITableViewCell
	{
		protected UserViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUI(Restaurant restaurant){
			lbName.Text = restaurant.Name;
			lbPhone.Text = restaurant.Phone;
			lbAddress.Text = restaurant.Address;
			lbOpeningTime.Text = restaurant.OpeningTime;
			imgPicture.Image = UIImage.FromFile(restaurant.ImgUrl);
		}
	}
}
