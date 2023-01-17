using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HenrysBookstore.Models
{
    public class BrowsePublisher
    {
        public string PublisherSelected { get; set; }
        public IEnumerable<SelectListItem> AllPublisherOptions { get; set; }
    }
}