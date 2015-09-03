namespace DreamFactory.AddressBook.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class GroupController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}