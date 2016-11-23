using System;
using System.Net;
using System.Threading.Tasks;

using UIKit;


using static System.Console;

namespace Jim.iOS
{
	public partial class LoginViewController : UIViewController
	{
		private WebWorker Worker { get; set; }

		public LoginViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Worker = new WebWorker();

			Worker.HtmlStringReceived += (sender, e) =>
			{
				WriteLine(e.Html);

				PerformSegue("moveToMenuSegue",this);
			};


			btnLogin.TouchUpInside += async (object sender, EventArgs e) => 
			{
				var result = await Worker.DownloadHtmlString("https://stackoverflow.com");

				WriteLine($"這是直接使用回傳結果 { result.Length }");
			
			};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class WebWorker
		{
			private WebClient MyWebClient { get; set; }

			public WebWorker()
			{
				MyWebClient = new WebClient();
			}

			public async Task<string> DownloadHtmlString(string url)
			{
				var task = MyWebClient.DownloadStringTaskAsync(url);
				var result = await task;

				EventHandler<HtmlReceivedEventArgs> handler = HtmlStringReceived;
				var args = new HtmlReceivedEventArgs { Html = result };
				if (null != handler)
				{
					handler(this, args);
				}

				return result;
			}
			public event EventHandler<HtmlReceivedEventArgs> HtmlStringReceived;
		}
		public class HtmlReceivedEventArgs : EventArgs
		{
			public string Html { get; set; }
		}
	}
}

