using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibleVerseApplication.Models
{
    public class BibleVerse
    {

        [DisplayName("Testiment")]
        public string Testiment { get; set; }
       
        [Required]
        [DisplayName("Book")]
        public string Book { get; set; }

        [Required]
        [DisplayName("Chapter")]
        public int Chapter { get; set; }


        [Required]
        [DisplayName("Verse")]
        public int Verse { get; set; }
       

        [DisplayName("Text")]
        public string Text { get; set; }

        public BibleVerse() { }
        
        
        override public string ToString() {

            return string.Format("Testiment: {0} Book: {1} {2}:{3}/n Text{4}", Testiment, Book, Chapter.ToString(), Verse.ToString(), Text);
        }
        
    }
}