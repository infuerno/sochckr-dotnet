using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sochckr.Web.Models;

namespace Sochckr.Web.Controllers
{
    public class BrokenLinksController : Controller
    {
        //private static List<BrokenLink> _brokenLinks;
        private SochckrDbContext _db = new SochckrDbContext();

        // GET: BrokenLinks
        public ActionResult Index(int statusCode = 0)
        {
            var model = _db.BrokenLinks
                .Where(bl => statusCode == 0 || bl.StatusCode == statusCode)
                .OrderByDescending(bl => bl.Post.Score).ToList();
            return View(model);
        }

        // GET: BrokenLinks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrokenLinks/Resolve/5
        public ActionResult Resolve(int id)
        {
            var brokenLink = _db.BrokenLinks.Single(bl => bl.Id == id);
            return View(brokenLink);
        }

        // POST: BrokenLinks/Resolve/5
        [HttpPost]
        public ActionResult Resolve(int id, FormCollection collection)
        {
            var brokenLink = _db.BrokenLinks.Single(bl => bl.Id == id);
            if (TryUpdateModel(brokenLink))
            {
                //
                return RedirectToAction("Index");
            }
            return View(brokenLink);
        }

        // GET: BrokenLinks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrokenLinks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult Stats()
        {
            var stats = new BrokenLinkStats()
            {
                NumberOfActiveBrokenLinks = _db.BrokenLinks.Count(bl => !bl.IsResolved)
            };
            return PartialView("_Stats", stats);
        }

        protected override void Dispose(bool disposing)
        {
            _db?.Dispose();
            base.Dispose(disposing);
        }

        //private static readonly Post _question = new Question()
        //{
        //    Id = 1,
        //    IsAnswered = false,
        //    Score = 3,
        //    BrokenLinks = _brokenLinks1
        //};

        //private static readonly Post _answer = new Answer()
        //{
        //    Id = 2,
        //    BrokenLinks = _brokenLinks2
        //};

        //private static readonly List<BrokenLink> _brokenLinks1 = new List<BrokenLink>()
        //{
        //    new BrokenLink()
        //    {
        //        Id = 1,
        //        Link = "http://www.bbc.co.uk",
        //        StatusCode = 404,
        //        Text = "My favourite site",
        //        Post = _question
        //    },
        //    new BrokenLink()
        //    {
        //        Id = 2,
        //        Link = "http://www.bbc.co.uk",
        //        StatusCode = 404,
        //        Text = "My favourite site 2",
        //        Post = _question
        //    },
        //    new BrokenLink()
        //    {
        //        Id = 3,
        //        Link = "http://www.bbc.co.uk",
        //        StatusCode = 500,
        //        Text = "My favourite site 3",
        //        Post = _question
        //    }
        //};

        //private static readonly List<BrokenLink> _brokenLinks2 = new List<BrokenLink>()
        //{
        //    new BrokenLink()
        //    {
        //        Id = 4,
        //        Link = "http://www.bbc.co.uk",
        //        StatusCode = 500,
        //        Text = "My favourite site 4",
        //        Post = _answer
        //    }
        //};

        //private static List<BrokenLink> GetAllBrokenLinks()
        //{
        //    if (_brokenLinks == null)
        //    {
        //        _brokenLinks = _brokenLinks1;
        //        _brokenLinks.AddRange(_brokenLinks2);
        //    }
        //    return _brokenLinks;
        //}

        //private static List<BrokenLink> _brokenLinks = _brokenLinks1.AddRange(_brokenLinks2);


    }
}
