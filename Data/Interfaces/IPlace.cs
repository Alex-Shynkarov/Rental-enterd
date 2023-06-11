using RentalСenterApp.Data.Models;
using System;
using System.Collections.Generic;

namespace RentalСenterApp.Data.Interfaces
{
	public interface IPlace
	{
		IEnumerable<Place> AllPlaces { get; }
		Place getById(int id);
		Place getAvailableInRoom(DateTime rentStart, DateTime rentEnd, int roomId);
	}
}