using AutoMapper;
using DataEntities.DTO;
using DataModel.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper.Mapping
{

    /// <summary>
    /// This class used for all mapping configuration from database object to service DTO
    /// </summary>
    public class DalToServiceMappingProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
           
            Mapper.CreateMap<HotelDTO, Hotel>().ReverseMap();         
            Mapper.AssertConfigurationIsValid();

        }
    }
}
