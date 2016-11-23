using System;

using UIKit;

using static System.Console;

namespace Jim.iOS
{
	public partial class MyWebViewController : UIViewController
	{
		public MyWebViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var beginButtomConstrant = btnGoButtomConstraint.Constant;

			UIKeyboard.Notifications.ObserveWillChangeFrame((sender, e) =>
			{

				var beginRect = e.FrameBegin;
				var endRect = e.FrameEnd;

				WriteLine($"ObserveWillChangeFrame endRect:{endRect.Height}");

				InvokeOnMainThread(() =>
				{

					UIView.Animate(1, () =>
					{

						btnGoButtomConstraint.Constant = endRect.Height + 5;
						this.View.LayoutIfNeeded();

					});
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

