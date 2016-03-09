using AutoMapper;
using DataEntities.DTO;
using DataModel.EntityModel;
using DataModel.UnityOfWork;
using Service.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Service.Implementation
{
    /// <summary>
    /// Offers services for hotel specific CRUD operations
    /// </summary>
    public class HotelRepository : IHotelRepository
    {
        private readonly IUnityOfWork _unityOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public HotelRepository(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }


        /// <summary>
        /// Fetches Hotel details by search string
        /// </summary>
        /// <param name="search_text"></param>
        /// <returns></returns>
        public IEnumerable<HotelDTO> GetHotels(string search_text)
        {

            //Here we are seraching the hotels on the bases of search text, searching the text into two columns Hotel_Name and Description
            var hotels = _unityOfWork.HotelRepository.GetMany(hotel => 
            search_text.Contains(hotel.Hotel_Name) || 
            search_text.Contains(hotel.Description)
            ).ToList();

            if (hotels != null)
            {               
                var hotelModel = Mapper.Map<List<Hotel>, List<HotelDTO>>(hotels);
                return hotelModel;
            }
            return null;
        }
    }
}
