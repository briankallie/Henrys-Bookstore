using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HenrysBookstore.Models
{
    public class BrowseLocation
    {
        public string LocationSelected { get; set; }
        public IEnumerable<SelectListItem> AllLocationOptions { get; set; }
    }
}