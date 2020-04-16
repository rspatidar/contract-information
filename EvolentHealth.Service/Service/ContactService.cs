using EvolentHealth.Core.DataInterface;
using EvolentHealth.Core.Model;
using EvolentHealth.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.Service.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository =
              contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));

        }

        public async Task<int> DeleteContactByIdAsync(int id)
        {
            if (id < 1)
                throw new ArgumentOutOfRangeException(nameof(id), $"{nameof(id)} must be greater then zero");

            Contact contact = await _contactRepository.GetByIdAsync(id);

            if (contact == null || contact.Id != id)
                return 0;
            else
                await _contactRepository.DeleteAsync(contact);


            return 1;
        }

        public async Task<ResponseModel<IEnumerable<Contact>>> GetAllContactAsync()
        {
            ResponseModel<IEnumerable<Contact>> result;

            IEnumerable<Contact> contactList = await _contactRepository.GetAllAsync();

            result = new ResponseModel<IEnumerable<Contact>>()
            {
                Result = contactList,
                ResultCode = ResultCode.Success,
            };
            return result;


        }

        public async Task<ResponseModel<Contact>> GetContactByIdAsync(int id)
        {
            ResponseModel<Contact> result;

            Contact contact = await _contactRepository.GetByIdAsync(id);

            result = new ResponseModel<Contact>()
            {
                Result = contact,
                ResultCode = ResultCode.Success,
            };
            return result;


        }

        public async Task<ResponseModel<Contact>> CreateContactAsync(Contact contact)
        {

            ResponseModel<Contact> result;

            if (contact==null)
                throw new ArgumentNullException(nameof(contact), $"{nameof(contact)} should not be null");

            Contact createdContact = await CreateContactInternalAsync(contact);

            result = new ResponseModel<Contact>
            {
                ResultCode = ResultCode.Success,
                Result = createdContact
            };
            return result;
        }
        internal async Task<Contact> CreateContactInternalAsync(Contact contact)
        {

            var savedContact = await _contactRepository.CreateAsync(contact);


            return savedContact;
        }

        public async Task<ResponseModel<Contact>> UpdatContactAsync(Contact contact)
        {

            ResponseModel<Contact> result;
            if (contact == null)
                throw new ArgumentNullException(nameof(contact), $"{nameof(contact)} should not be null");
            Contact createdContact = await _contactRepository.UpdateAsync(contact);

            result = new ResponseModel<Contact>
            {
                ResultCode = ResultCode.Success,
                Result = createdContact
            };
            return result;
        }

       
    }
}
