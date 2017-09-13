using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess
{
    public class ClientRepository : IClientRepository
    {

        //Here there should be a real access to data such as Stored Procedures calls if we are using ADO.NET for instance. Then we will fetch our data from a database.
        public IEnumerable<Client> GetClients()
        {
            List<Client> clients = new List<Client>()
            {
                new Client(){Id = "880abb11-936a-45d0-880d-a9fb4d669086", Name = "Dotson", Email = "dotsonblankenship@quotezart.com", Role = "admin" },
                new Client(){Id = "065eb093-748e-4133-9884-0adc11e2fbfc", Name = "Marietta", Email = "mariettablankenship@quotezart.com", Role = "user" },
                new Client(){Id = "011dd3d8-2d1e-4abe-9efc-006a1a4a0399", Name = "Sherrie", Email = "sherrieblankenship@quotezart.com", Role = "user" },
                new Client(){Id = "1f00dd51-3583-40a0-8350-a2df96b505a9", Name = "Moore", Email = "mooreblankenship@quotezart.com", Role = "user" },
                new Client(){Id = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb", Name = "Manning", Email = "manningblankenship@quotezart.com", Role = "admin" }
            };

            return clients;
        }
    }
}