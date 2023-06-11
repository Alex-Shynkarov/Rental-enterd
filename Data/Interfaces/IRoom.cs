using RentalСenterApp.Data.Models;
using System.Collections.Generic;

namespace RentalСenterApp.Data.Interfaces
{
	public interface IRoom
	{
		IEnumerable<Room> AllRooms { get; }
		IEnumerable<Room> FavouriteRooms { get; }
		Room getById(int id);
		IEnumerable<Room> getByRoomType(string roomTypeName);
	}
}