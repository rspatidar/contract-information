using EvolentHealth.Core.DataInterface.Base;
using EvolentHealth.Core.Model;
using EvolentHealth.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.Core.DataInterface
{
    public interface IContactRepository:IRepository<Contact>
    {
        Task<int> GetCountByStatusIdAsync(Status status);

    }
}
