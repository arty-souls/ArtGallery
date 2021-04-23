using ArtGallery.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly UserContext _auc;

        public RegistrationController(UserContext auc)
        {
            _auc = auc;
        }

        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(User uc)
        {

            _auc.Add(uc);
            _auc.SaveChanges();
            ViewBag.message = "Hi " + uc.Username + " ,Your message is received we will revert back soon ! ";
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
