
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Jim.Droid
{
	[Activity(Label = "MenuActivity")]
	public class MenuActivity : Activity
	{
		private ListView userTable;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.menuview);
			// Create your application here
			userTable = FindViewById<ListView>(Resource.Id.menuview_usertable);

			LoadData();
		}

		private void LoadData()
		{

			var list = new List<User>
			{
				new User {Name = @"Aa", Description = @"使用者 甲"},
				new User {Name = @"Bb", Description = @"使用者 乙"},
				new User {Name = @"Cc", Description = @"使用者 丙"},
				new User {Name = @"Dd", Description = @"使用者 丁"}
			};

			RunOnUiThread(() =>
			{

				userTable.Adapter = new UserListAdapter(list, this);

				userTable.ItemClick += (sender, args) =>
				{
					User user = list[args.Position];

					Intent nextActivity = new Intent(this, typeof(DetailActivity));
					nextActivity.PutExtra("selectedUser", Newtonsoft.Json.JsonConvert.SerializeObject(user));
					StartActivity(nextActivity);
				};

			});

		}

		/// <summary>
		/// 請複製整個類別後，更改資料以及
		/// </summary>
		public class UserListAdapter : BaseAdapter<User>
		{
			private Activity context;

			private List<User> Users { get; set; }

			/// <summary>
			/// Initializes a new instance of the <see cref="T:XamarinTableView.Droid.MainActivity.UserListAdapter"/> class.
			/// 傳入資料以及負責繪圖的 Context
			/// </summary>
			/// <param name="users">Users.</param>
			/// <param name="context">Context.</param>
			public UserListAdapter(IEnumerable<User> users, Activity context)
			{
				this.context = context;

				Users = new List<User>();
				Users.AddRange(users);
			}

			/// <summary>
			/// 讓作業系統了解需要準備多少記憶體
			/// </summary>
			/// <value>資料筆數</value>
			public override int Count => Users.Count;

			/// <summary>
			/// 在資料列順序與顯示順序不同時，這邊要做處理。
			/// 
			/// </summary>
			/// <returns>The item identifier.</returns>
			/// <param name="position">Position.</param>
			public override long GetItemId(int position)
			{
				return position;
			}

			/// <summary>
			/// 回傳 UI 
			/// </summary>
			/// <returns>The view.</returns>
			/// <param name="position">Position.</param>
			/// <param name="convertView">Convert view.</param>
			/// <param name="parent">Parent.</param>
			public override View GetView(int position, View convertView, ViewGroup parent)
			{


				// UI Binding
				var view = convertView;

				if (null == view)
				{
					view = context.LayoutInflater.Inflate(Resource.Layout.menuview_userview, parent, false);

				}

				// Data Binding
				User user = Users[position];

				view.FindViewById<TextView>(Resource.Id.menuview_userview_lbName).Text = user.Name;
				view.FindViewById<TextView>(Resource.Id.menuview_userview_lbDescription).Text = user.Description;

				return view;
			}


			/// <summary>
			/// Gets the <see cref="T:XamarinTableView.Droid.MainActivity.UserListAdapter"/> with the specified position.
			/// </summary>
			/// <param name="position">Position.</param>
			public override User this[int position] => Users[position];
		}
	}
}
