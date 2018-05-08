using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sochckr.Web.Filters;

namespace Sochckr.Web.Controllers
{
    //[Log]
    public class SitesController : Controller
    {
        public ActionResult Search(string site = "stackoverflow")
        {
            var message = Server.HtmlEncode(site);
            return Content(message);
        }
    }
}