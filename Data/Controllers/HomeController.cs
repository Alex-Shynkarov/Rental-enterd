using RentalСenterApp.Data.Interfaces;
using RentalСenterApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentalСenterApp.Data.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private readonly IRoom _roomRepository;

		public HomeController(IRoom roomRepository)
		{
			_roomRepository = roomRepository;
		}

		[Route("")]
		public ViewResult Index()
		{
			var homeRooms = new HomeViewModel
			{
				favouriteRooms = _roomRepository.FavouriteRooms
			};
			return View(homeRooms);
		}
		public IActionResult Message(string message)
		{
			ViewBag.Message = message;
			return View();
		}
	}
}