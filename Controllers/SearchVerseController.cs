using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApplication.Controllers
{
    public class SearchVerseController : Controller
    {
        // GET: SearchVerse
        public ActionResult Index()
        {
            return View("SearchVerse");
        }

        //Search does not require the user to input the text field. 
        public ActionResult SearchVerse(BibleVerse model)
        {

            //Valid date the user input
            if (!ModelState.IsValid)
            {
                return View();
            }

            SercurityServices security = new SercurityServices();

            //Tuple is used to hold two values, The found Bible Verse and a bool of a Successful
            Tuple<BibleVerse, bool> check = security.SearchVerse(model);

            //Check Tuple.Item2 if the bool is True or False
            if (check.Item2)
            {
                return View("Success", check.Item1);
            }
            else
            {
                return View("Failed");
            }
        }
    }
}