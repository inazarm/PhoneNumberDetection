using Microsoft.AspNetCore.Mvc;
using PhoneNumberDetection.Models;
using PhoneNumberDetection.services;
using System.Diagnostics;

namespace PhoneNumberDetection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhoneNumberDetector _phoneNumberDetector;

        public HomeController(IPhoneNumberDetector phoneNumberDetector)
        {
            _phoneNumberDetector = phoneNumberDetector;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckPhoneNumber(string inputText)
        {
            if (_phoneNumberDetector.ContainsPhoneNumber(inputText))
            {
                ModelState.AddModelError(string.Empty, "Input contains a phone number, which is not allowed.");
            }
            else
            {
                ViewBag.Message = "Input is valid.";
            }

            return View("Index");
        }
    }
}