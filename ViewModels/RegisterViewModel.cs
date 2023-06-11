using System;
using System.ComponentModel.DataAnnotations;

namespace RentalСenterApp.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string email { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "дана народження")]
		public DateTime birthDate { get; set; }

		[Display(Name = "Введіть ім'я")]
		[StringLength(25)]
		[Required(ErrorMessage = "Введить ім'я не менше 5 символів")]
		public string name { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		[StringLength(20, ErrorMessage = "пароль не менше 8 символів", MinimumLength = 8)]
		public string password { get; set; }

		[Required]
		[Compare("password", ErrorMessage = "паролі не спідпадають")]
		[DataType(DataType.Password)]
		[Display(Name = "Введіть пароль ще раз")]
		public string passwordConfirm { get; set; }
	}
}