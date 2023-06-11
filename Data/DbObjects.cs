using RentalСenterApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalСenterApp.Data
{
    public class DbObjects
    {
        private static Dictionary<string, RoomType> roomType;
        private static Dictionary<string, Service> service;
        private static Dictionary<string, Room> room;
        private static Dictionary<string, IdentityRole> role;
        private static Dictionary<User, IdentityRole> user;
        private static Dictionary<string, string> userCred;
        private static Dictionary<string, Status> status;

        public static void Initial(AppDbContent content)
        {
            if (!content.Status.Any())
            {
                content.Status.AddRange(Statuses.Select(r => r.Value));
            }

            if (!content.RoomType.Any())
            {
                content.RoomType.AddRange(RoomTypes.Select(rt => rt.Value));
            }

            if (!content.Service.Any())
            {
                content.Service.AddRange(Services.Select(s => s.Value));
            }

            if (!content.Room.Any())
            {
                content.Room.AddRange(Rooms.Select(r => r.Value));
            }

            if (!content.Place.Any())
            {
                int idCounter = 1;
                content.Place.AddRange(Rooms.SelectMany(item => Enumerable.Range(1, item.Value.maxPlaces)
                                .Select(i => new Place
                                {
                                    id = idCounter++,
                                    code = item.Value.id + "/" + i,
                                    roomId = item.Value.id,
                                    room = item.Value
                                })));
            }

            content.SaveChanges();
        }

        public static async Task InitialAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                foreach (var roleEl in Roles.Values)
                {
                    await roleManager.CreateAsync(roleEl);
                }
            }

            if (!userManager.Users.Any())
            {

                foreach (var userEl in Users.Keys)
                {
                    IdentityResult result = await userManager.CreateAsync(userEl, userCred[userEl.Email]);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(userEl, Users[userEl].Name);
                    }
                }
            }
        }

        public static Dictionary<string, IdentityRole> Roles
        {
            get
            {
                if (role == null)
                {
                    var roleList = new List<IdentityRole>
                    {
                        new IdentityRole {Name = "Admin",},
                        new IdentityRole {Name = "User",},
                    };
                    role = new Dictionary<string, IdentityRole>();
                    roleList.ForEach(el => role.Add(el.Name, el));
                }
                return role;
            }
        }

        public static Dictionary<User, IdentityRole> Users
        {
            get
            {
                if (user == null)
                {
                    user = new Dictionary<User, IdentityRole>();
                    userCred = new Dictionary<string, string>();

                    var simpleUser = new User
                    {
                        Email = "testUser@mail.com",
                        UserName = "testUser@mail.com",
                        name = "Alex",
                        birthDate = DateTime.Parse("17/03/2003"),
                    };
                    user.Add(simpleUser, Roles["User"]);
                    userCred.Add(simpleUser.Email, "userPass1!");

                    var admin = new User
                    {
                        Email = "testAdmin@mail.com",
                        UserName = "testAdmin@mail.com",
                        name = "Admin",
                        birthDate = DateTime.Parse("01/01/2000"),
                    };
                    user.Add(admin, Roles["Admin"]);
                    userCred.Add(admin.Email, "adminPass1!");
                }
                return user;
            }
        }

        public static Dictionary<string, Status> Statuses
        {
            get
            {
                if (status == null)
                {
                    var statusList = new List<Status>
                    {
                        new Status {name = "Нова",},
                        new Status {name = "Підтверджено",},
                        new Status {name = "Відхилено",},
                        new Status {name = "Скасовано",}
                    };
                    status = new Dictionary<string, Status>();
                    statusList.ForEach(el => status.Add(el.name, el));
                }
                return status;
            }
        }

        public static Dictionary<string, RoomType> RoomTypes
        {
            get
            {
                if (roomType == null)
                {
                    var roomTypeList = new List<RoomType>
                    {
                        new RoomType {name = "private office", description = "Невеликий приватний простір від 2 осіб"},
                        new RoomType {name = "skype room", description = "Приватна кімната на одного для дзвінків"},
                        new RoomType {name = "business suite", description = "Великий приватний простіp для великих команд"},
                        new RoomType {name = "open space", description = "Відкрита зона з повною робочою комплектацією"},
                        new RoomType {name = "meeting room", description = "Кімната для проведення зустрічей із усім необхідним обладнанням"},
                        new RoomType {name = "lounge zone", description = "Робочий простір із м'якими диванами та релаксуючою атмосферою"},
                    };
                    roomType = new Dictionary<string, RoomType>();
                    roomTypeList.ForEach(el => roomType.Add(el.name, el));
                }
                return roomType;
            }
        }

        public static Dictionary<string, Service> Services
        {
            get
            {
                if (service == null)
                {
                    var serviceList = new List<Service>
                    {
                        new Service {id = 1, name = "Швидкісне wi-fi з'єднання" },
                        new Service {id = 2, name = "Незакріплене робоче місце" },
                        new Service {id = 3, name = "Доступ до кухні" },
                        new Service {id = 4, name = "Електронна перепустка" },
                        new Service {id = 5, name = "Доступ до зони відпочинку" },
                        new Service {id = 6, name = "Доступ до спортзалу" },
                        new Service {id = 7, name = "Закріплене робоче місце" },
                        new Service {id = 8, name = "Послуги юриста" },
                        new Service {id = 9, name = "Гостьовий візит" },
                        new Service {id = 10, name = "Технічна підтримка" },
                        new Service {id = 11, name = "Локер" },
                        new Service {id = 12, name = "Фліпчарт" },
                        new Service {id = 13, name = "Принтер/Сканер" },
                        new Service {id = 14, name = "Технічне забезпечення" },
                    };
                    service = new Dictionary<string, Service>();
                    serviceList.ForEach(el => service.Add(el.name, el));
                }
                return service;
            }
        }

        public static Dictionary<string, Room> Rooms
        {
            get
            {
                if (room == null)
                {
                    var roomList = new List<Room>
                    {
                        new Room
                        {
                            id = 1,
                            name = "Luna",
                            area = 43,
                            maxPlaces = 15,
                            price = 140,
                            roomType = RoomTypes["open space"],
                            isFavourite = false,
                            imageUrl = "/img/open_space_new.jpg",
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
                            roomType =  RoomTypes["lounge zone"],
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Доступ до зони відпочинку"],
                                Services["Гостьовий візит"]
                            },
                            imageUrl = "/img/lounge_zone_new.jpg",
                            isFavourite = true,
                        },
                        new Room
                        {
                            id = 3,
                            name = "Firefly",
                            area = 100,
                            maxPlaces = 20,
                            price = 500,
                            roomType =  RoomTypes["business suite"],
                            imageUrl = "/img/business_suite_new.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Технічна підтримка"],
                                Services["Доступ до зони відпочинку"],
                                Services["Доступ до кухні"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 4,
                            name = "Rome",
                            area = 20,
                            maxPlaces = 4,
                            price = 300,
                            roomType = RoomTypes["private office"],
                            imageUrl = "/img/private_office_new.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            }
                        },
                        new Room
                        {
                            id = 5,
                            name = "Sunrise",
                            area = 10,
                            maxPlaces = 1,
                            roomType =  RoomTypes["meeting room"],
                            price = 210,
                            imageUrl = "/img/meeting_room_new.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Технічна підтримка"],
                            },
                        },
                        new Room
                        {
                            id = 6,
                            name = "Dawn",
                            area = 3,
                            maxPlaces = 1,
                            price = 150,
                            roomType =  RoomTypes["skype room"],
                            imageUrl = "/img/skype_room_new.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                            },
                        },
                        new Room
                        {
                            id = 7,
                            name = "Helsinki",
                            area = 25,
                            maxPlaces = 10,
                            price = 100,
                            roomType =  RoomTypes["open space"],
                            imageUrl = "/img/open_space_helsinki.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                            },
                        },
                        new Room
                        {
                            id = 8,
                            name = "Marseille",
                            area = 30,
                            maxPlaces = 8,
                            price = 100,
                            roomType =  RoomTypes["lounge zone"],
                            imageUrl = "/img/lounge_zone_boho.jpeg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                            },
                        },
                        new Room
                        {
                            id = 9,
                            name = "Lyon",
                            area = 50,
                            maxPlaces = 10,
                            price = 300,
                            roomType = RoomTypes["business suite"],
                            imageUrl = "/img/business_suite_lyon.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 10,
                            name = "Madrid",
                            area = 60,
                            maxPlaces = 10,
                            price = 400,
                            roomType = RoomTypes["private office"],
                            imageUrl = "/img/private_office_green.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            }
                        },
                        new Room
                        {
                            id = 11,
                            name = "Seul",
                            area = 6,
                            maxPlaces = 1,
                            roomType =  RoomTypes["meeting room"],
                            price = 180,
                            imageUrl = "/img/small_meeting_room.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 12,
                            name = "Ansan",
                            area = 2,
                            maxPlaces = 1,
                            price = 120,
                            roomType =  RoomTypes["skype room"],
                            imageUrl = "/img/skype_room_ansan.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 13,
                            name = "Prague",
                            area = 80,
                            maxPlaces = 30,
                            price = 180,
                            roomType =  RoomTypes["open space"],
                            imageUrl = "/img/open_space_big.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 14,
                            name = "Bern",
                            area = 40,
                            maxPlaces = 10,
                            price = 150,
                            roomType =  RoomTypes["lounge zone"],
                            imageUrl = "/img/lounge_zone_circle.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 15,
                            name = "Chicago",
                            area = 40,
                            maxPlaces = 8,
                            price = 450,
                            roomType = RoomTypes["business suite"],
                            imageUrl = "/img/business_suite_tech.png",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 16,
                            name = "Atlanta",
                            area = 8,
                            maxPlaces = 2,
                            price = 300,
                            roomType = RoomTypes["private office"],
                            imageUrl = "/img/private_office_two_people.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Технічна підтримка"],
                            }
                        },
                        new Room
                        {
                            id = 17,
                            name = "Las Vegas",
                            area = 20,
                            maxPlaces = 1,
                            roomType =  RoomTypes["meeting room"],
                            price = 250,
                            imageUrl = "/img/meeting_room_open.jpg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Доступ до спортзалу"],
                                Services["Незакріплене робоче місце"],
                                Services["Електронна перепустка"]

                            },
                        },
                        new Room
                        {
                            id = 18,
                            name = "Toronto",
                            area = 3,
                            maxPlaces = 1,
                            price = 80,
                            roomType =  RoomTypes["skype room"],
                            imageUrl = "/img/skype_room_new.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 19,
                            name = "Dublin",
                            area = 40,
                            maxPlaces = 10,
                            price = 120,
                            roomType =  RoomTypes["open space"],
                            imageUrl = "/img/open_space_industrial.jpeg",
                            isFavourite = false,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Незакріплене робоче місце"],
                                Services["Локер"],
                                Services["Електронна перепустка"]
                            },
                        },
                        new Room
                        {
                            id = 20,
                            name = "Oxford",
                            area = 15,
                            maxPlaces = 1,
                            roomType =  RoomTypes["meeting room"],
                            price = 300,
                            imageUrl = "/img/meeting_room_big.jpg",
                            isFavourite = true,
                            services = new List<Service> {
                                Services["Швидкісне wi-fi з'єднання"],
                                Services["Гостьовий візит"],
                                Services["Технічна підтримка"],
                                Services["Фліпчарт"],
                                Services["Електронна перепустка"]
                            },
                        },
                    };
                    room = new Dictionary<string, Room>();
                    roomList.ForEach(el => room.Add(el.name, el));
                }
                return room;
            }
        }
    }
}