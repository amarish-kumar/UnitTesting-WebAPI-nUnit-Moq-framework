using DataModel.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Text.TestHelper
{
    //This will be used for all the test data initilizer;
    public class DataInitializer
    {
        /// <summary>
        /// Dummy hotels
        /// </summary>
        /// <returns></returns>
        public static List<Hotel> GetAllHotels()
        {
            var hotels = new List<Hotel>
                               {
                                   new Hotel() {Hotel_Name = "Travel Lodge"},
                                   new Hotel() {Hotel_Name = "Holiday Inn"},
                                   new Hotel() {Hotel_Name = "Hilton"},
                                   new Hotel() {Hotel_Name = "Ibis"},
                               };
            return hotels;
        }
    }
}
