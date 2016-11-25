using System;
using Foundation;
using UIKit;

using static System.Console;

namespace Jim.iOS
{
	public partial class MyWebViewController : UIViewController
	{
		public string webUrl{ get; set; }

		public MyWebViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			myWebView.LoadRequest (new NSUrlRequest (
				new NSUrl (webUrl)));


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}

