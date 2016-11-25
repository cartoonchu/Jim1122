using System;

using UIKit;

using CoreLocation;
using CoreGraphics;
using MapKit;

namespace Jim.iOS
{
	public partial class MyMapViewController : UIViewController
	{
		public MyLocation DisplayLocation { get; set; }

		public MyMapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			// 星下點
			var mapCenter = new CLLocationCoordinate2D(DisplayLocation.Lat, DisplayLocation.Lng);

			myMapView.CenterCoordinate = mapCenter;

			//鏡頭多大
			var mapRegion = MKCoordinateRegion.FromDistance(mapCenter, 4000, 4000);

			myMapView.Region = mapRegion;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

