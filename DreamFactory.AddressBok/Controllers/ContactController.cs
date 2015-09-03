namespace DreamFactory.AddressBook.Controllers
{
    using System.Web.Mvc;

    [Authorize]
    public class ContactController : Controller
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

        public ActionResult Details()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}