using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace BibleVerseApplication.Controllers
{
    public class AddVerseController : Controller
    {
        // GET: AddVerse
        public ActionResult Index()
        {
            var oldBooks = new List<string>() { "Genesis", "Exedos" };

            var newBooks = new List<string>() { "Mathew", "Mark", "Luke" };

            ViewBag.newBooks = newBooks;
            ViewBag.oldBooks = oldBooks;

            return View("AddVerse");
        }

        //POST
        [HttpPost]
        public ActionResult AddVerse(BibleVerse model)
        {
            //If the Input does NOT pass the Model Validation
            if (!ModelState.IsValid)
            {
                return View("AddVerse");
            }

            
            SercurityServices security = new SercurityServices();

            //Send the Verse to the Security service
            security.AddVerse(model);
            
            return View("Passed", model);
        }
    }
}