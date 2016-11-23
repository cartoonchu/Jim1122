using System;
using System.Threading.Tasks;
using UIKit;

namespace Jim.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Task.Run(() =>
			{
				Task.Delay(2000);

				InvokeOnMainThread(() =>
				{
					PerformSegue("moveToLoginViewSegue", this);
				});
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
