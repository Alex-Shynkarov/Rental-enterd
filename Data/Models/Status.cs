using System.Collections.Generic;

namespace RentalСenterApp.Data.Models
{
    public class Status
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<RentApplication> rentApplications { get; set; }
    }
}