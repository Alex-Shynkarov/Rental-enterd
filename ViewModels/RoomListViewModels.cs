using RentalСenterApp.Data.Models;
using System.Collections.Generic;

namespace RentalСenterApp.ViewModels
{
	public class RoomListViewModels
	{
		public IEnumerable<Room> allRooms { get; set; }
		public string currentType { get; set; }
	}
}