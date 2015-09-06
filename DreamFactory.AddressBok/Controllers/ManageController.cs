namespace DreamFactory.AddressBook.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Models;

    [Authorize]
    public class ManageController : Controller
    {
        public ManageController()
        {
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            ViewBag.StatusMessage = "Your password has been changed.";
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            if (claims.Any(x => x.Type == ClaimTypes.Role && x.Value == DreamFactoryConfig.Roles.SysAdmin))
            {
                //systemApi.ChangePasswordAdminAsync();
            }
            else
            {
                //userApi.ChangePasswordAsync();
            }

            return View(model);
        }

    }
}