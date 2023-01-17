using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenrysBookstore.Models;

namespace HenrysBookstore.Controllers
{
    public class BrowsePublisherController : Controller
    {
        private BOOKSTOREEntities db = new BOOKSTOREEntities();

        // GET: BrowsePublisher
        public ActionResult BrowseByPublisher()
        {
            BrowsePublisher model = new BrowsePublisher();

            model.AllPublisherOptions = db.PUBLISHERs.OrderBy(s => s.PUBLISHER_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.PUBLISHER_NAME,
                Value = s.PUBLISHER_CODE.ToString()
            });

            return PartialView("_FilterPublisher",model);
        }

        [HttpPost]
        public ActionResult BrowseByPublisher(BrowsePublisher model)
        {
            if (string.IsNullOrEmpty(model.PublisherSelected))
            {
                // Throw error pertaining to empty filter criteria
                ModelState.AddModelError("", "Please Select a Publisher");
            }

            model.AllPublisherOptions = db.PUBLISHERs.OrderBy(s => s.PUBLISHER_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.PUBLISHER_NAME,
                Value = s.PUBLISHER_CODE.ToString()
            });

            return PartialView("_FilterPublisher", model);
        }
    }
}