using DataEntities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{

    /// <summary>
    /// Hotel Service Contract
    /// </summary>
    public interface IHotelRepository
    {
        IEnumerable<HotelDTO> GetHotels(string search_text);
    }
}
