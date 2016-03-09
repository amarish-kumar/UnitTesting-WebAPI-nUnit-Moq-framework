using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntities.DTO
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string Hotel_Name { get; set; }
        public string ImagePath { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }
    }
}
