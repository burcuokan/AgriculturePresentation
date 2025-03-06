using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Project_AgriculturePresentation.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _ımageService;

        public ImageController(IImageService ımageService)
        {
            _ımageService = ımageService;
        }

        public IActionResult Index()
        {
            var values = _ımageService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image p)
        {
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid) //Geçerli olup olmadığını kontrol etme
            {
                _ımageService.Insert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteImage(int id)
        {
            var value = _ımageService.GetById(id);
            _ımageService.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var value = _ımageService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditImage(Image p)
        {
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                _ımageService.Update(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
