using RentalСenterApp.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentalСenterApp.ViewModels
{
    public class PlaceViewModel
    {
        [BindNever]
        public int placeId { get; set; }
        [BindNever]
        public Place place { get; set; }
        [Display(Name = "початок оренди кімнати")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Помилка")]
        public DateTime rentStart { get; set; }
        [Display(Name = "кінець оренди кімнати")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Помилка")]
        public DateTime rentEnd { get; set; }
    }
}