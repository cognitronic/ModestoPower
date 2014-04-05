using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModestoPower.Core.Domain.Client
{
    public interface IClientRepository
    {
        IList<Client> GetAll();
        Client GetById(string id);
        Client Save(Client client);
    }
}
