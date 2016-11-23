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
	[Register ("MyWebViewController")]
	partial class MyWebViewController
	{
		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.NSLayoutConstraint btnGoButtomConstraint { get; set; }

		[Outlet]
		UIKit.UIWebView myWebView { get; set; }

		[Outlet]
		UIKit.UITextField txtUrl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (txtUrl != null) {
				txtUrl.Dispose ();
				txtUrl = null;
			}

			if (myWebView != null) {
				myWebView.Dispose ();
				myWebView = null;
			}

			if (btnGoButtomConstraint != null) {
				btnGoButtomConstraint.Dispose ();
				btnGoButtomConstraint = null;
			}
		}
	}
}
