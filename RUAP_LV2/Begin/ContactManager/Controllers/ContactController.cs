using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ContactManager.Services;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;

namespace ContactManager.Controllers
{
    public class ContactController : ApiController
    {
        // GET: Contact
        private ContactRepository contactRepository;

        public ContactController()
        {
            this.contactRepository = new ContactRepository();
        }
        public Contact[] Get()
        {
            return contactRepository.GetAllContacts();
        }
        public HttpResponseMessage Post(Contact contact)
        {
            this.contactRepository.SaveContact(contact);

            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}