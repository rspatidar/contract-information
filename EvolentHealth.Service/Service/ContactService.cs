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
            // TODO: Throw ArgumentOutOfRangeException if number of ordered cups is less than 1

            Contact contact = await _contactRepository.GetByIdAsync(id);

            // TODO: Return StockExceeded result code if not enough cups in stock

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
                ResultCode = OrderCreationResultCode.Success,
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
                ResultCode = OrderCreationResultCode.Success,
            };
            return result;


        }

        public async Task<ResponseModel<Contact>> CreateContactAsync(Contact contact)
        {
            // TODO: Throw ArgumentOutOfRangeException if number of ordered cups is less than 1

            ResponseModel<Contact> result;

            // TODO: Return StockExceeded result code if not enough cups in stock

            Contact createdContact = await CreateContactInternalAsync(contact);

            result = new ResponseModel<Contact>
            {
                ResultCode = OrderCreationResultCode.Success,
                Result = createdContact
            };
            return result;
        }
        private async Task<Contact> CreateContactInternalAsync(Contact contact)
        {

            var savedContact = await _contactRepository.CreateAsync(contact);


            return savedContact;
        }

        public async Task<ResponseModel<Contact>> UpdatContactAsync(Contact contact)
        {
            // TODO: Throw ArgumentOutOfRangeException if number of ordered cups is less than 1

            ResponseModel<Contact> result;

            // TODO: Return StockExceeded result code if not enough cups in stock

            Contact createdContact = await _contactRepository.UpdateAsync(contact);

            result = new ResponseModel<Contact>
            {
                ResultCode = OrderCreationResultCode.Success,
                Result = createdContact
            };
            return result;
        }

       
    }
}
