using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogProxyApi.Web
{
    public static class MapperUtility
    {
        public static IMapper Mapper { get; set; }
        static MapperUtility()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Common.Models.Message, Models.Message>();
            });

#if DEBUG
            config.AssertConfigurationIsValid();
#endif

            Mapper = config.CreateMapper();
        }

        public static Models.Message MapEx(this Common.Models.Message message)
        {
            return Mapper.Map<Models.Message>(message);
        }
    }
}
