using RentalСenterApp.Data.Interfaces;
using RentalСenterApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentalСenterApp.Data.Mocks
{
	public class MockRoom : IRoom
	{
		private readonly IRoomType _roomType = new MockRoomType();
		public IEnumerable<Room> AllRooms
		{
			get
			{
				return new List<Room>
			{
				new Room
				{
					id = 1,
					name = "Luna",
					area = 43,
					maxPlaces = 15,
					price = 140,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("open space")).First(),
					imageUrl = "/img/open_space_new.jpg",
					isFavourite = false,
					services = new List<Service> {
						new Service {name = "Швидкісне wi-fi з'єднання" },
						new Service {name = "Незакріплене робоче місце" },
						new Service {name = "Доступ до кухні" },
						new Service {name = "Електронна перепустка" },
						new Service {name = "Доступ до зони відпочинку" },
						new Service {name = "Доступ до спортзалу" },
					},
				},
				new Room
				{
					id = 2,
					name = "Fox Den",
					area = 40,
					maxPlaces = 20,
					price = 80,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("lounge zone")).First(),
					isFavourite = true,
					services = new List<Service> {
						new Service {name = "Швидкісне wi-fi з'єднання" },
						new Service {name = "Доступ до зони відпочинку" },
                        new Service {name = "Гостьовий візит" },
                        new Service {name = "Доступ до спортзалу" }
					},
					imageUrl = "/img/lounge_zone_new.jpg",
				},
				new Room
				{
					id = 3,
					name = "Firefly",
					area = 100,
					maxPlaces = 20,
					price = 500,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("business suite")).First(),
					imageUrl = "/img/business_suite_new.jpg",
					isFavourite = false,
					services = new List<Service> { 
						new Service {name = "Швидкісне wi-fi з'єднання" },
						new Service {name = "Гостьовий візит" },
						new Service {name = "Доступ до спортзалу" },
						new Service {name = "Незакріплене робоче місце" },
						new Service {name = "Локер" },
						new Service {name = "Технічна підтримка" },
						new Service {name = "Доступ до зони відпочинку" },
						new Service {name = "Доступ до кухні" }
					},
				},
				new Room
				{
					id = 4,
					name = "Rome",
					area = 20,
					maxPlaces = 4,
					price = 300,
					roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("private office")).First(),
					imageUrl = "/img/private_office_new.jpg",
					isFavourite = true,
					services = new List<Service> {
						new Service {name = "Швидкісне wi-fi з'єднання" },
						new Service {name = "Локер" },
						new Service {name = "Технічна підтримка" },
						new Service {name = "Доступ до зони відпочинку" },
						new Service {name = "Незакріплене робоче місце" },
						new Service {name = "Доступ до спортзалу" },
						new Service {name = "Доступ до кухні" }
					}
				},
				 new Room
				{
					id = 5,
                    name = "Dawn",
                    area = 4,
                    maxPlaces = 1,
                    price = 120,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("skype room")).First(),
                    imageUrl = "/img/skype_room_new.jpg",
                    isFavourite = true,
                    services = new List<Service> {
                        new Service {name = "Швидкісне wi-fi з'єднання" },
                        new Service {name = "Доступ до зони відпочинку" },
                        new Service {name = "Технічна підтримка" }
					},
				},
				  new Room
				{
                   id = 6,
                   name = "Sunrise",
                    area = 15,
                    maxPlaces = 15,
                    roomType = _roomType.AllRoomTypes.Where(type => type.name.Equals("meeting room")).First(),
                    price = 210,
                    imageUrl = "/img/meeting_room_new.jpg",
                    isFavourite = false,
                    services = new List<Service> {
                        new Service {name = "Швидкісне wi-fi з'єднання" },
                        new Service {name = "Локер" },
                        new Service {name = "Технічна підтримка" },
                        new Service {name = "Доступ до зони відпочинку" },
                        new Service {name = "Доступ до спортзалу" }
                    },
				}
			};
			}
		}

        public IEnumerable<Room> FavouriteRooms { get; }

        public Room getById(int id)
		{
            foreach (var element in AllRooms)
            {
				if(element.id == id)
				{
                    return element;
                }
            }
			throw new System.NotImplementedException();
		}

		public IEnumerable<Room> getByRoomType(string roomTypeName)
		{
			throw new System.NotImplementedException();
		}
	}
}