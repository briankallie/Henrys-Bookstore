using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HenrysBookstore.Models;
using Microsoft.Ajax.Utilities;

namespace HenrysBookstore.Controllers
{
    public class HomeController : Controller
    {
        private BOOKSTOREEntities db = new BOOKSTOREEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrowseInventory()
        {
            var allInventory = db.BOOKs.OrderBy(x=>x.TITLE).ToList();
            List<INVENTORY> result = new List<INVENTORY>();

            foreach (var item in allInventory)
            {
                INVENTORY model = new INVENTORY();
                model.BOOK_CODE = item.BOOK_CODE;
                result.Add(model);
            }
            
            return View(result);
        }

        public ActionResult BrowseByAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BrowseByAuthor(BrowseAuthor author)
        {
            var uAuthor = author.AuthorSelected;

            var allAuthors = db.AUTHORs.Where(x => x.AUTHOR_NUM.ToString() == uAuthor).ToList();
            List<AUTHOR> result = new List<AUTHOR>();

            foreach (var auth in allAuthors)
            {
                AUTHOR model = new AUTHOR();
                model.AUTHOR_NUM = auth.AUTHOR_NUM;
                model.AUTHOR_FIRST = auth.AUTHOR_FIRST;
                model.AUTHOR_LAST = auth.AUTHOR_LAST;

                var allAuthorBooks = from x in db.WROTEs
                    join y in db.AUTHORs on x.AUTHOR_NUM equals y.AUTHOR_NUM
                    join z in db.BOOKs on x.BOOK_CODE equals z.BOOK_CODE
                    join a in db.PUBLISHERs on z.PUBLISHER_CODE equals a.PUBLISHER_CODE
                    where string.IsNullOrEmpty(uAuthor) || x.AUTHOR_NUM.ToString() == uAuthor
                    select x;

                model.WROTEs = allAuthorBooks.ToList();
                result.Add(model);
            }

            return View(result);
        }

        public ActionResult BrowseByPublisher()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BrowseByPublisher(BrowsePublisher publisher)
        {
            var uPublisher = publisher.PublisherSelected;

            var allPublishers = db.PUBLISHERs.Where(x => x.PUBLISHER_CODE.ToString() == uPublisher).ToList();
            List<PUBLISHER> result = new List<PUBLISHER>();

            foreach (var pub in allPublishers)
            {
                PUBLISHER model = new PUBLISHER();
                model.PUBLISHER_CODE = pub.PUBLISHER_CODE;
                model.PUBLISHER_NAME = pub.PUBLISHER_NAME;

                var allPublisherBooks = from s in db.BOOKs
                    where s.PUBLISHER_CODE == pub.PUBLISHER_CODE
                    where string.IsNullOrEmpty(uPublisher) || s.PUBLISHER_CODE.ToString() == uPublisher
                    select s;

                model.BOOKs = allPublisherBooks.ToList();
                result.Add(model);
            }

            return View(result);
        }

        public ActionResult BrowseByLocation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BrowseByLocation(BrowseLocation branch)
        {
            var uBranch = branch.LocationSelected;

            var allBranches = db.BRANCHes.Where(x=>x.BRANCH_NUM.ToString() == uBranch).ToList();
            List<BRANCH> result = new List<BRANCH>();

            foreach (var loc in allBranches)
            {
                BRANCH model = new BRANCH();
                model.BRANCH_NUM = loc.BRANCH_NUM;
                model.BRANCH_NAME = loc.BRANCH_NAME;
                model.BRANCH_LOCATION = loc.BRANCH_LOCATION;
                model.NUM_EMPLOYEES = loc.NUM_EMPLOYEES;

                var allBranchInfo = from s in db.INVENTORies
                    join t in db.BRANCHes on s.BRANCH_NUM equals t.BRANCH_NUM
                    join u in db.BOOKs on s.BOOK_CODE equals u.BOOK_CODE
                    where string.IsNullOrEmpty(uBranch) || s.BRANCH_NUM.ToString() == uBranch
                    select s;

                model.INVENTORies = allBranchInfo.ToList();
                result.Add(model);
            }

            return View(result);
        }

        public ActionResult ContactManagement(Feedback model)
        {
            ModelState.Clear();

            model.AllBranchOptions = db.BRANCHes.OrderBy(s => s.BRANCH_NAME).ToList().Select(s => new SelectListItem
            {
                Text = s.BRANCH_NAME,
                Value = s.BRANCH_NAME.ToString()
            });

            return View(model);
        }

        [HttpPost]
        public JsonResult Feedback(Feedback model)
        {
            ViewBag.Title = "Feedback sent";

            return Json(model);
        }
    }
}