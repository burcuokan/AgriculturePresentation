using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Entity;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_AgriculturePresentation.Controllers
{
    [AllowAnonymous] //Kullanıcının erişebileceği sayfa olduğu için muaf tuttuk.
    public class DefaultController : Controller
    {
        private readonly IContactService _contactService;

        public DefaultController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _contactService.Insert(contact);
            return RedirectToAction("Index", "Default");
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
