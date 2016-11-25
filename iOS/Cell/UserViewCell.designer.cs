// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Jim.iOS
{
	[Register ("UserViewCell")]
	partial class UserViewCell
	{
		[Outlet]
		UIKit.UIImageView imgPicture { get; set; }

		[Outlet]
		UIKit.UILabel lbAddress { get; set; }

		[Outlet]
		UIKit.UILabel lbName { get; set; }

		[Outlet]
		UIKit.UILabel lbOpeningTime { get; set; }

		[Outlet]
		UIKit.UILabel lbPhone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imgPicture != null) {
				imgPicture.Dispose ();
				imgPicture = null;
			}

			if (lbAddress != null) {
				lbAddress.Dispose ();
				lbAddress = null;
			}

			if (lbName != null) {
				lbName.Dispose ();
				lbName = null;
			}

			if (lbOpeningTime != null) {
				lbOpeningTime.Dispose ();
				lbOpeningTime = null;
			}

			if (lbPhone != null) {
				lbPhone.Dispose ();
				lbPhone = null;
			}
		}
	}
}
