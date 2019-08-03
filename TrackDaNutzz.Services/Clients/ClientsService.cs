using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackDaNutzz.Data;
using TrackDaNutzz.Data.Models;
using TrackDaNutzz.Services.Dtos.Hands;

namespace TrackDaNutzz.Services.Clients
{
    public class ClientsService : IClientsService
    {
        private readonly TrackDaNutzzDbContext context;

        public ClientsService(TrackDaNutzzDbContext context)
        {
            this.context = context;
        }

        public int AddClient(HandInfoDto handInfoDto)
        {
            Client client = this.context.Clients.SingleOrDefault(c => c.Name == handInfoDto.ClientName);
            if (client != null)
            {
                return client.Id;
            }
            client = new Client()
            {
                Name = handInfoDto.ClientName
            };
            this.context.Clients.Add(client);
            this.context.SaveChanges();
            return client.Id;
        }

        public string GetClientNameById(int clientId)
        {
            string clientName = this.context.Clients.Where(c => c.Id == clientId).Select(c => c.Name).FirstOrDefault();
            return clientName;
        }
    }
}
