using RentalСenterApp.Data.Interfaces;
using RentalСenterApp.Data.Models;
using System.Collections.Generic;

namespace RentalСenterApp.Data.Repository
{
	public class RoomTypeRepository : IRoomType
	{
		private readonly AppDbContent appDbContent;

		public RoomTypeRepository(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

		public IEnumerable<RoomType> AllRoomTypes => appDbContent.RoomType;
	}
}