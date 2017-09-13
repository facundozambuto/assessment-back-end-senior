using AutoMapper;
using DTO.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DTO;

namespace BusinessService
{
    public static class AutomapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClientDTO, Client>().ReverseMap();
                cfg.CreateMap<PolicyDTO, Policy>().ReverseMap();
            });
        }
    }
}
