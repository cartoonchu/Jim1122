using System;
using UIKit;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;

namespace Jim.iOS
{
	public partial class MenuViewController : UIViewController
	{
		public User SelectedUser { set; get;}
		public MenuViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			ShowTable();
		}

		private void ShowTable()
		{

			var list = new List<User>
			{
				new User {Name = @"Aa", Description = @"使用者 甲"},
				new User {Name = @"Bb", Description = @"使用者 乙"},
				new User {Name = @"Cc", Description = @"使用者 丙"},
				new User {Name = @"Dd", Description = @"使用者 丁"}
			};

			var tableSource = new UserTableSource(list);
			userTable.Source = tableSource;

			tableSource.UserSelected += delegate (object sender, UserSelectedEventArgs e)
			{
				SelectedUser = e.SelectedUser;
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

					destViewController.SelectedUser = SelectedUser;
				}
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public class UserTableSource : UITableViewSource
		{
			// CellView Identifier
			const string UserViewCellIdentifier = @"UserViewCell";

			// ctor. Model

			private List<User> Users { get; set; }

			public UserTableSource(IEnumerable<User> users)
			{
				Users = new List<User>();
				Users.AddRange(users);
			}

			// Model -> Controller -> View

			// Memory
			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return Users.Count;
			}

			// Controller -> View
			public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
			{

				User myClass = Users[indexPath.Row];

				UserViewCell cell = tableView.DequeueReusableCell(UserViewCellIdentifier) as UserViewCell;
				cell.UpdateUI(myClass);

				return cell;
			}


			// View -> Controller
			public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);

				User user = Users[indexPath.Row];

				EventHandler<UserSelectedEventArgs> handle = UserSelected;

				if (null != handle)
				{

					var args = new UserSelectedEventArgs { SelectedUser = user };

					handle(this, args);
				}

			}

			/// <summary>
			/// 設計事件，回傳結果給呼叫端
			/// </summary>
			public event EventHandler<UserSelectedEventArgs> UserSelected;

		}

		public class UserSelectedEventArgs : EventArgs
		{

			public User SelectedUser { get; set; }

		}
	}
}

