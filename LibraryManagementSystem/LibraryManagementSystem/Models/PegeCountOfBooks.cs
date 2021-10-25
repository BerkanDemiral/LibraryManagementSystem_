using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class PegeCountOfBooks
    {
        public string bookName { get; set; }
        public int? pageCount { get; set; } // null gelebilme ihtimali olan durumlarda bunu kullanabiliyoruz.
    }
}