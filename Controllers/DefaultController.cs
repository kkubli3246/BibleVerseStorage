using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibleVerseApplication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        //Menu option to add Bible Verse
        public ActionResult Add()
        {
            return RedirectToAction("Index","AddVerse");
        }

        //Menu Option to Seach for Bible Verse
        public ActionResult Search()
        {
            return RedirectToAction("Index", "SearchVerse");
        }
    }
}