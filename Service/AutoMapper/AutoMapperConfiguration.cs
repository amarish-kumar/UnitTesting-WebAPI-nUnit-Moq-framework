using AutoMapper;
using Service.AutoMapper.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{

    /// <summary>
    /// This class used for all mapping configuration Initilazier
    /// </summary>
    public class AutoMapperConfiguration
    {

        public static void Configure()
        {
            
            Mapper.Initialize(x =>
            {
                x.AddProfile<DalToServiceMappingProfile>();
            });

        }
    }
}
