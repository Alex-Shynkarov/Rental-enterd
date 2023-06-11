using RentalСenterApp.Data.Interfaces;
using RentalСenterApp.Data.Models;
using System.Collections.Generic;

namespace RentalСenterApp.Data.Mocks
{
	public class MockRoomType : IRoomType
	{
		public IEnumerable<RoomType> AllRoomTypes
		{
			get
			{
				return new List<RoomType>
			{
				new RoomType {name = "private office", description = "Невеликий приватний простір від 2 осіб"},
                new RoomType {name = "skype room", description = "Приватна кімната на одного для дзвінків"},
                new RoomType {name = "business suite", description = "Великий приватний простіp для великих команд"},
                new RoomType {name = "open space", description = "Відкрита зона з повною робочою комплектацією"},
                new RoomType {name = "meeting room", description = "Кімната для проведення зустрічей із усім необхідним обладнанням"},
				new RoomType {name = "lounge zone", description = "Робочий простір із м'якими диванами та релаксуючою атмосферою"},
			};
			}
		}
	}
}