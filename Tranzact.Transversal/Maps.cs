using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tranzact.Domain.DTO;
using Tranzact.Infrastructure.Models;

namespace Tranzact.Transversal
{
    public static class Maps
    {
        public static IMapper InitMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<Contact, ContactDTO>()
                    .ReverseMap(); 

            });

            return config.CreateMapper();
        }
    }
}
