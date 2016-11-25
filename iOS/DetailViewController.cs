using System;
using System.Threading.Tasks;
using UIKit;

namespace Jim.iOS
{
	public partial class DetailViewController : UIViewController
	{
		public Restaurant SelectedResturant { set; get; }
		public DetailViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = SelectedResturant.Name;

			lbPhone.Text = SelectedResturant.Phone;
			btnGoMapView.SetTitle(SelectedResturant.Address,UIControlState.Normal);
			lbDescription.Text = SelectedResturant.Description;
			imgPicture.Image = UIImage.FromFile(SelectedResturant.ImgUrl);

			btnGoWebView.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToWebViewSegue", this);

			};

			btnGoMapView.TouchUpInside += (sender, e) =>
			{
				PerformSegue("moveToMapViewSegue", this);

			};

		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if ("moveToWebViewSegue" == segue.Identifier)
			{
				if (segue.DestinationViewController is MyWebViewController)
				{
					var destViewController = segue.DestinationViewController as MyWebViewController;

					destViewController.webUrl = SelectedResturant.Url;
				}
			}

			if ("moveToMapViewSegue" == segue.Identifier)
			{
				if (segue.DestinationViewController is MyMapViewController)
				{
					var destViewController = segue.DestinationViewController as MyMapViewController;

					var loc = new MyLocation { Lat = SelectedResturant.Lat , Lng = SelectedResturant.Lng };
					destViewController.DisplayLocation = loc;
				}
			}
		}
		 
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

