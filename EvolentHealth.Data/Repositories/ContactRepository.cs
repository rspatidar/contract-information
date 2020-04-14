using EvolentHealth.Core.DataInterface;
using EvolentHealth.Core.Model;
using EvolentHealth.Core.Model.Enums;
using EvolentHealth.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.Data.Repositories
{
    public class ContactRepository : FileRepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository() : base(@"Contact.json")
        {
        }

        public Task<int> GetCountByStatusIdAsync(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
