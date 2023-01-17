using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using HenrysBookstore.Models;

namespace HenrysBookstore.Controllers
{
    public class BrowseAuthorController : Controller
    {
        private BOOKSTOREEntities db = new BOOKSTOREEntities();

        // GET: BrowseAuthor
        public ActionResult BrowseByAuthor()
        {
            BrowseAuthor model = new BrowseAuthor();

            model.AllAuthorOptions = db.AUTHORs.OrderBy(s => s.AUTHOR_FIRST).ToList().Select(s => new SelectListItem
            {
                Text = s.AUTHOR_FIRST + " " + s.AUTHOR_LAST,
                Value = s.AUTHOR_NUM.ToString()
            });

            return PartialView("_FilterAuthor", model);
        }

        [HttpPost]
        public ActionResult BrowseByAuthor(BrowseAuthor model)
        {
            if (string.IsNullOrEmpty(model.AuthorSelected))
            {
                // Throw error pertaining to empty filter criteria
                ModelState.AddModelError("", "Please Select an Author");
            }

            model.AllAuthorOptions = db.AUTHORs.OrderBy(s => s.AUTHOR_FIRST).ToList().Select(s => new SelectListItem
            {
                Text = s.AUTHOR_FIRST + " " + s.AUTHOR_LAST,
                Value = s.AUTHOR_NUM.ToString()
            });

            return PartialView("_FilterAuthor", model);
        }
    }
}