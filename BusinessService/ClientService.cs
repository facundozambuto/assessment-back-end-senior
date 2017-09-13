using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using WebApi.DTO;
using DataAccess.Contracts;
using AutoMapper;

namespace BusinessService
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        IEnumerable<ClientDTO> IClientService.GetClients()
        {
            var clients = _clientRepository.GetClients();
            return Mapper.Map<List<ClientDTO>>(clients);
        }
    }
}