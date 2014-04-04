using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Domain;

namespace ModestoPower.Core.Domain.Forms
{
    public interface IWaiverRepository
    {
        IList<Waiver> GetAll();
        Waiver GetById(string id);
        Waiver Save(Waiver waiver);
        Waiver Delete(string id);
        Waiver GetByEmail(string email);
    }
}
