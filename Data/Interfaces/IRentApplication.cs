using RentalСenterApp.Data.Models;
using System.Collections.Generic;

namespace RentalСenterApp.Data.Interfaces
{
    public interface IRentApplication
    {
        void createRentApplication(RentApplication rentApplication);
        void updateRentApplication(RentApplication rentApplication, string newStatus);
        IEnumerable<RentApplication> AllRentApplications { get; }
        IEnumerable<RentApplication> getByUserId(string userId);
        RentApplication getById(int id);
    }
}
