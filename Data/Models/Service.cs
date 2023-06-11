using System.Collections.Generic;

namespace RentalСenterApp.Data.Models
{
    public class Service
    {
        public int id { set; get; }
        public string name { set; get; }
        public List<Room> rooms { set; get; }
    }
}