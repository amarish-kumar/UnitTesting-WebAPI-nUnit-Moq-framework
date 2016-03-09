using BookingTek.API.ErrorHelper;
using BookingTek.API.Filters;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingTek.API.Controllers
{
    public class HotelsController : ApiController
    {

        #region Private variable.

        private readonly IHotelRepository _hotelServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize hotel service instance
        /// </summary>
        public HotelsController(IHotelRepository hotelServices)
        {
            _hotelServices = hotelServices;
        }
        #endregion

        
       /// <summary>
       /// Get Hotels
       /// </summary>
       /// <param name="search_text"></param>
       /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetHotels(string search_text)
        {

           
                if (!string.IsNullOrEmpty(search_text))
                {
                    var hotels = _hotelServices.GetHotels(search_text);
                    if (hotels != null)
                        return Request.CreateResponse(HttpStatusCode.OK, hotels);

                    throw new ApiDataException(1001, "No hotel found for this search.", HttpStatusCode.NotFound);
                }
                throw new ApiException() { ErrorCode = (int)HttpStatusCode.BadRequest, ErrorDescription = "Bad Request..." };
         
           
        }

      

    }
}
