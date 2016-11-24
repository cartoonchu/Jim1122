using System;
using System.Threading.Tasks;
using UIKit;

namespace Jim.iOS
{
	public partial class DetailViewController : UIViewController
	{
		public User SelectedUser { set; get; }
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = SelectedUser.Name;

			btnGoWebView.TouchUpInside += (object sender, EventArgs e) =>
			{
				PerformSegue("moveToWebViewSegue", this);

			};


		}
		 
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

