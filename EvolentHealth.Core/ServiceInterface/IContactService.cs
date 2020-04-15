using EvolentHealth.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.Core.ServiceInterface
{
    public interface IContactService
    {
        Task<ResponseModel<IEnumerable<Contact>>> GetAllContactAsync();
        Task<ResponseModel<Contact>> GetContactByIdAsync(int id);

        Task<ResponseModel<Contact>> CreateContactAsync(Contact contact);
        Task<ResponseModel<Contact>> UpdatContactAsync(Contact contact);
        Task<int> DeleteContactByIdAsync(int id);

    }
}
