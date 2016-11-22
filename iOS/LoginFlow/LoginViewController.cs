using System;

using UIKit;

using static System.Console;

namespace Jim.iOS
{
	public partial class LoginViewController : UIViewController
	{
		public LoginViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			btnLogin.TouchUpInside += (object sender, EventArgs e) => 
			{
				WriteLine($"TouchUpInside");
			
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

