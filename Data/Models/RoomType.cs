using System.Collections.Generic;

namespace RentalСenterApp.Data.Models
{
	public class RoomType
	{
		public int id { set; get; }
		public string name { set; get; }
		public string description { set; get; }
		public List<Room> rooms { set; get; }
	}
}
