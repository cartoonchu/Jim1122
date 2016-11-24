using System;
using Foundation;
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

			myWebView.LoadHtmlString(@"
			<html>
				<head>
					<title>Local String</title>
					<style type='text/css'>p{font-family : Verdana; color : purple }</style>
					<script language='JavaScript'> 
						function msg(){ 
							window.location = 'shirly://Hi'  
						}
					</script>
				</head>
				<body>
					<p>Hello World!</p><br />
					<button type='button' onclick='msg()' text='Hi'>Hi</button>
				</body>
			</html>", null);

			myWebView.ShouldStartLoad =
				delegate (UIWebView webView,
					NSUrlRequest request,
					UIWebViewNavigationType navigationType)
				{

					var requestString = request.Url.AbsoluteString;

					var components = requestString.Split(new[] { @"://" }, StringSplitOptions.None);

					if (components.Length > 1 && components[0].ToLower() == @"shirly".ToLower())
					{

						if (components[1] == @"Hi")
						{

							UIAlertController alert = UIAlertController.Create(@"Hi Title", @"當然是世界好", UIAlertControllerStyle.Alert);


							UIAlertAction okAction = UIAlertAction.Create(@"OK", UIAlertActionStyle.Default, (action) =>
							{
								Console.WriteLine(@"OK");
							});
							alert.AddAction(okAction);


							UIAlertAction cancelAction = UIAlertAction.Create(@"Cancel", UIAlertActionStyle.Default, (action) =>
							{
								Console.WriteLine(@"Cancel");
							});
							alert.AddAction(cancelAction);

							PresentViewController(alert, true, null);


							return false;
						}

					}

					return true;

				};


		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}


	}
}

