using RentalСenterApp.Data.Interfaces;
using RentalСenterApp.Data.Models;
using RentalСenterApp.Data.Utils;
using RentalСenterApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace RentalСenterApp.Data.Controllers
{

    [Authorize]
    public class RentCartController : Controller
    {
        private readonly IPlace _placeRepository;
        private readonly RentCart _rentCart;

        public RentCartController(IPlace placeRepository, RentCart rentCart)
        {
            _placeRepository = placeRepository;
            _rentCart = rentCart;
        }

        public ViewResult Index()
        {
            var items = _rentCart.getRentItems();
            _rentCart.rentCartItems = items;
            var rentCartViewModel = new RentCartViewModel
            {
                rentCart = _rentCart,
                totalPrice = _rentCart.rentCartItems.Sum(item => CalculationUtil.getTotalForPlace(item.place, item.rentStart, item.rentEnd))
            };
            return View(rentCartViewModel);
        }

        [Route("Rent/{roomId}")]
        public IActionResult AddToCart(int roomId)
        {
            return View("Rent");
        }

        [HttpPost]
        [Route("Rent/{roomId}")]
        public IActionResult AddToCart(PlaceViewModel placeDto, int roomId)
        {
            if (!ModelState.IsValid || !validateDateRange(placeDto.rentStart, placeDto.rentEnd))
            {
                return View("Rent", placeDto);
            }

            Place availablePlace = _placeRepository.getAvailableInRoom(placeDto.rentStart, placeDto.rentEnd, roomId);

            if (availablePlace == null)
            {
                return RedirectToAction("Message", "Home", new { message = "на жаль, не має вільних місць :(" });
            }

            placeDto.place = availablePlace;
            placeDto.placeId = availablePlace.id;
            _rentCart.AddToCart(placeDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            _rentCart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        private bool validateDateRange(DateTime start, DateTime end)
        {
            return start >= DateTime.Today && start <= end;
        }

    }
}