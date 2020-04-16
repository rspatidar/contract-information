using EvolentHealth.Core.DataInterface;
using EvolentHealth.Core.Model;
using EvolentHealth.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentHealth.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
            _logger = logger;
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
