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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton btnGoMapView { get; set; }

		[Outlet]
		UIKit.UIButton btnGoWebView { get; set; }

		[Outlet]
		UIKit.UIImageView imgPicture { get; set; }

		[Outlet]
		UIKit.UILabel lbDescription { get; set; }

		[Outlet]
		UIKit.UILabel lbPhone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbPhone != null) {
				lbPhone.Dispose ();
				lbPhone = null;
			}

			if (lbDescription != null) {
				lbDescription.Dispose ();
				lbDescription = null;
			}

			if (imgPicture != null) {
				imgPicture.Dispose ();
				imgPicture = null;
			}

			if (btnGoMapView != null) {
				btnGoMapView.Dispose ();
				btnGoMapView = null;
			}

			if (btnGoWebView != null) {
				btnGoWebView.Dispose ();
				btnGoWebView = null;
			}
		}
	}
}
