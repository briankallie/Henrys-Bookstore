using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenrysBookstore.Models;

namespace HenrysBookstore.Controllers
{
    public class BrowseLocationController : Controller
    {
        private BOOKSTOREEntities db = new BOOKSTOREEntities();

        // GET: BrowseLocation
        public ActionResult BrowseByLocation()
        {
            BrowseLocation model = new BrowseLocation();

            model.AllLocationOptions = db.BRANCHes.OrderBy(s => s.BRANCH_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.BRANCH_NAME,
                Value = s.BRANCH_NUM.ToString()
            });

            return PartialView("_FilterLocation",model);
        }

        [HttpPost]
        public ActionResult BrowseByLocation(BrowseLocation model)
        {
            if (string.IsNullOrEmpty(model.LocationSelected))
            {
                // Throw error pertaining to empty filter criteria
                ModelState.AddModelError("", "Please Select a Location");
            }

            model.AllLocationOptions = db.BRANCHes.OrderBy(s => s.BRANCH_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.BRANCH_NAME,
                Value = s.BRANCH_NUM.ToString()
            });

            return PartialView("_FilterLocation", model);
        }
    }
}