using System;
namespace Jim
{
	public class Restaurant
	{
		public Restaurant()
		{
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string OpeningTime { get; set; }
		public double Lat{ get; set; }
		public double Lng { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public string ImgUrl { get; set; }

	}

	public class MyLocation
	{
		public double Lat { set; get; }
		public double Lng { set; get; }
	}
}
