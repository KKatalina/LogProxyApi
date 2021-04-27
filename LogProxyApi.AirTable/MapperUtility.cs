using AutoMapper;
using LogProxyApi.AirTable.Models;
using LogProxyApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogProxyApi.AirTable
{
    public static class MapperUtility
    {
        public static IMapper Mapper { get; set; }
        static MapperUtility()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Fields, Message>()
                .ForMember(dest=>dest.Text, opt=>opt.MapFrom(src=>src.Message))
                .ForMember(dest=>dest.Title, opt=>opt.MapFrom(src=>src.Summary));
            });

#if DEBUG
            config.AssertConfigurationIsValid();
#endif

            Mapper = config.CreateMapper();
        }

        public static Message MapEx(this Fields record)
        {
            return Mapper.Map<Message>(record);
        }
    }
}
