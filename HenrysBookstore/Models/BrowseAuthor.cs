using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HenrysBookstore.Models
{
    public class BrowseAuthor
    {
        public string AuthorSelected { get; set; }
        public IEnumerable<SelectListItem> AllAuthorOptions { get; set; }
    }
}