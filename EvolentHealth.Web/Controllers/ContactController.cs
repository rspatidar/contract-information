using EvolentHealth.Core.DataInterface;
using EvolentHealth.Core.Model;
using EvolentHealth.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHealth.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactService _contactService;
        public ContactController(IContactRepository contactRepository, IContactService contactService)
        {
            _contactService = contactService;
            _contactRepository = contactRepository;
        }


        [Route("GetAllContact"), HttpGet]
        public async Task<ResponseModel<IEnumerable< Contact>>> GetAllContact()
        {
            return await _contactService.GetAllContactAsync();
        }
        [Route("GetContact/{id}"), HttpGet]
        public async Task<ResponseModel<Contact>> GetContact(int id)
        {
            return await _contactService.GetContactByIdAsync(id);
        }

        [Route("AddContact"), HttpPost]
        public async Task<ResponseModel<Contact>> AddContact(Contact contact)
        {
            return await _contactService.CreateContactAsync(contact);
        }
        [Route("UpdateContact"), HttpPut]
        public async Task<ResponseModel<Contact>> UpdateContact(Contact contact)
        {
            return await _contactService.UpdatContactAsync(contact);
        }
        [Route("DeleteContact/{id}"), HttpDelete]
        public async Task<int> DeleteContact(int id)
        {
            return await _contactService.DeleteContactByIdAsync(id);
        }
    }
}
