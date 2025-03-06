using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Project_AgriculturePresentation.Models;

namespace Project_AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View(new ServiceAddViewModel());
        }
        [HttpPost]
        public IActionResult AddService(Service p)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service()
                {
                    Title = p.Title,
                    Image = p.Image,
                    Description = p.Description
                });
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.GetById(id);
            _serviceService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service p)
        {
            _serviceService.Update(p);
            return RedirectToAction("Index");
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }
    
}
