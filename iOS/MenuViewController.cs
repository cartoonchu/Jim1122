using System;
using UIKit;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using System.Threading.Tasks;

namespace Jim.iOS
{
	public partial class MenuViewController : UIViewController
	{
		public Restaurant SelectedRestaurant { set; get;}
		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Task.Run(() =>
			{
				InvokeOnMainThread(() =>
				{
					ShowTable();
				});
			});

		}

		private void ShowTable()
		{

			var list = new List<Restaurant>
			{
				
				new Restaurant {Id="R000001", Name = @"丹丹漢堡", Phone = "07-1111111", Address = "OOO市XX路X段XX號",
					OpeningTime = "11:00 ~ 21:00", Lat = 22.6244844, Lng = 120.3290302,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=https%20%E4%B8%B9%E4%B8%B9%E6%BC%A2%E5%A0%A1", ImgUrl = "DanDan.jpg",
					Description = @"丹丹漢堡戰南北，你有吃過有麵線的漢堡嗎？快來嚐一嚐！"},
				new Restaurant {Id="R000002", Name = @"高雄婆婆冰", Phone = "07-2222222", Address = "OOO市XX路X段XX號",
					OpeningTime = "12:00 ~ 20:00", Lat = 22.6244500, Lng = 120.3290600,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=%E5%A9%86%E5%A9%86%E5%86%B0", ImgUrl = "PoPo.jpg",
					Description = @"顏色鮮豔、料多味美的婆婆冰，不但是夏日最熱門的消暑聖品，依循阿公留下來的古法秘方，古早風味的獨特口感，就連日本人都不遠千里聞風而來。！"},
				new Restaurant {Id="R000003", Name = @"阿囉哈魯味", Phone = "07-3333333", Address = "OOO市XX路X段XX號",
					OpeningTime = "16:00 ~ 21:00", Lat = 22.6244600, Lng = 120.3290302,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=%E9%98%BF%E5%9B%89%E5%93%88%E9%AD%AF%E5%91%B3", ImgUrl = "food3.jpg",
					Description = @"已有60年歷史。40多款滷味皆取中藥、冰糖、五香、辣椒等配方滷製，雖然色澤黝黑，口感卻是美味非凡，因此生意始終興隆，不到收攤時間多已售罄。"},
				new Restaurant {Id="R000004", Name = @"丹丹漢堡2號店", Phone = "07-4444444", Address = "OOO市XX路X段XX號",
					OpeningTime = "11:00 ~ 21:00", Lat = 22.6244844, Lng = 120.3290302,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=https%20%E4%B8%B9%E4%B8%B9%E6%BC%A2%E5%A0%A1", ImgUrl = "DanDan.jpg",
					Description = @"丹丹漢堡戰南北，你有吃過有麵線的漢堡嗎？快來嚐一嚐！"},
				new Restaurant {Id="R000005", Name = @"丹丹漢堡3號店", Phone = "07-5555555", Address = "OOO市XX路X段XX號",
					OpeningTime = "11:00 ~ 21:00", Lat = 22.6244844, Lng = 120.3290302,
					Url = "https://www.google.com.tw/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=https%20%E4%B8%B9%E4%B8%B9%E6%BC%A2%E5%A0%A1", ImgUrl = "DanDan.jpg",
					Description = @"丹丹漢堡戰南北，你有吃過有麵線的漢堡嗎？快來嚐一嚐！"}
			};

			var tableSource = new RestaurantTableSource(list);
			userTable.Source = tableSource;

			tableSource.UserSelected += delegate (object sender, ResturantSelectedEventArgs e)
			{
				SelectedRestaurant = e.SelectedUser;
				Debug.WriteLine(e.SelectedUser.Name);

				InvokeOnMainThread(() =>
				{
					PerformSegue("moveToDetailSegue", this);
				});
			};

			// 考試時InvokeOnMainThread 呼叫

				userTable.ReloadData();
				


		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			if("moveToDetailSegue" == segue.Identifier)
			{
				if(segue.DestinationViewController is DetailViewController)
				{
					var destViewController = segue.DestinationViewController as DetailViewController;

					destViewController.SelectedResturant = SelectedRestaurant;
				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class RestaurantTableSource : UITableViewSource
		{
			// CellView Identifier
			const string UserViewCellIdentifier = @"UserViewCell";

			// ctor. Model

			private List<Restaurant> Restaurantrs { get; set; }

			public RestaurantTableSource(IEnumerable<Restaurant> restaurant)
			{
				Restaurantrs = new List<Restaurant>();
				Restaurantrs.AddRange(restaurant);
			}

			// Model -> Controller -> View

			// Memory
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Restaurantrs.Count;
			}

			// Controller -> View
			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{

				Restaurant myClass = Restaurantrs[indexPath.Row];

				UserViewCell cell = tableView.DequeueReusableCell(UserViewCellIdentifier) as UserViewCell;
				cell.UpdateUI(myClass);

				return cell;
			}


			// View -> Controller
			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);

				Restaurant user = Restaurantrs[indexPath.Row];

				EventHandler<ResturantSelectedEventArgs> handle = UserSelected;

				if (null != handle)
				{

					var args = new ResturantSelectedEventArgs { SelectedUser = user };

					handle(this, args);
				}

			}

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<ResturantSelectedEventArgs> UserSelected;

		}

		public class ResturantSelectedEventArgs : EventArgs
		{

			public Restaurant SelectedUser { get; set; }

		}
	}
}

