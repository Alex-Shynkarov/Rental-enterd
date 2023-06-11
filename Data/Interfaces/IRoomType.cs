using RentalСenterApp.Data.Models;
using System.Collections.Generic;

namespace RentalСenterApp.Data.Interfaces
{
	public interface IRoomType
	{
		IEnumerable<RoomType> AllRoomTypes { get; }
	}
}