using BibleVerseApplication.Models;
using BibleVerseApplication.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Services.Business
{
    public class SercurityServices
    {
        //Adds a New Bible Verse to DB through the Security DAO
        public void AddVerse(BibleVerse verse)
        {
            SecurityDAO security = new SecurityDAO();
            security.AddVerse(verse);
        }

        //Find a Verse Based on Input
        //Returns the Tuple<BibleVerse, Bool> to the Controller
        public Tuple<BibleVerse, bool> SearchVerse(BibleVerse verse)
        {
            SecurityDAO security = new SecurityDAO();

            return security.SearchVerse(verse);

        }
    }
}