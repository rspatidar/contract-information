using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using EvolentHealth.Service.Service;
using Moq;
using EvolentHealth.Core.DataInterface;
using System.Threading.Tasks;
using EvolentHealth.Core.Model;

namespace EvolentHealth.Service.Test.Service
{
    [TestFixture]
    public class ContactServiceTest
    {
        private ContactService _contactService;
        private Contact contact;

        [SetUp]
        public void TestInitialize()
        {
            contact = new Contact { Id = 1, Email = "Ram" };
            var contactRepositoryMock = new Mock<IContactRepository>();
            contactRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(contact);
            contactRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<Contact>())).ReturnsAsync(contact);
            var testList = new List<Contact>();
            contactRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(testList);
            contactRepositoryMock.Setup(x => x.CreateAsync(contact)).ReturnsAsync(contact);
            contactRepositoryMock.Setup(x => x.UpdateAsync(contact)).ReturnsAsync(contact);

            _contactService = new ContactService(contactRepositoryMock.Object);



        }

        [Test]
        public void DeleteContactByIdAsync_LessThenOne_ThrowException()
        {

            var id = 0;
            var exception = Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                            () => _contactService.DeleteContactByIdAsync(id));

            Assert.AreEqual("id", exception.ParamName);



        }
        [Test]
        public async Task DeleteContactByIdAsync_ContactNotExist_ReturnZero()
        {

            var id = 2;

            var orderCreationResult = await _contactService.DeleteContactByIdAsync(id);

            Assert.AreEqual(0, orderCreationResult);


        }

        [Test]
        public async Task DeleteContactByIdAsync_ContactExist_ReturnOne()
        {

            var id = 1;

            var orderCreationResult = await _contactService.DeleteContactByIdAsync(id);

            Assert.AreEqual(1, orderCreationResult);


        }

        [Test]
        public async Task GetAllContactAsync_RestultExist_ReturnValues()
        {

            var orderCreationResult = await _contactService.GetAllContactAsync();
            Assert.IsNotNull(orderCreationResult);

        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public async Task GetContactByIdAsync_RestultExist_ReturnValues(int id)
        {

            var orderCreationResult = await _contactService.GetContactByIdAsync(id);
            Assert.IsNotNull(orderCreationResult);

        }

        [Test]
        public void CreateContactAsync_ContactNull_ThrowException()
        {
            var exception = Assert.ThrowsAsync<ArgumentNullException>(
                            () => _contactService.CreateContactAsync(null));
            Assert.AreEqual("contact", exception.ParamName);

        }

        [Test]
        public async Task CreateContactAsync_NewContact_ReturnSuccess()
        {
            var newContact = await _contactService.CreateContactAsync(contact);
            Assert.AreEqual(ResultCode.Success, newContact.ResultCode);

        }

        [Test]
        public async Task CreateContactInternalAsync_NewContact_ReturnSuccess()
        {
            var newContact = await _contactService.CreateContactInternalAsync(contact);
            Assert.AreEqual(contact, newContact);

        }

        [Test]
        public void UpdatContactAsync_ContactNull_ThrowException()
        {
            var exception = Assert.ThrowsAsync<ArgumentNullException>(
                            () => _contactService.UpdatContactAsync(null));
            Assert.AreEqual("contact", exception.ParamName);

        }

        [Test]
        public async Task UpdatContactAsync_NewContact_ReturnSuccess()
        {
            var newContact = await _contactService.UpdatContactAsync(contact);
            Assert.AreEqual(ResultCode.Success, newContact.ResultCode);

        }
    }
}
