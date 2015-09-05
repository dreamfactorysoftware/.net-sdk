namespace DreamFactory.AddressBook.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DreamFactory.AddressBook.Models;
    using DreamFactory.Api;
    using DreamFactory.Model.User;

    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserApi _userApi;
        private readonly ISystemApi _systemApi;

        public AccountController(IUserApi userApi, ISystemApi systemApi)
        {
            _userApi = userApi;
            _systemApi = systemApi;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Session session = new Session();

            try
            {
                session = await _userApi.LoginAsync(model.Email, model.Password);
            }
            catch (Exception)
            {
                try
                {
                    session = await _systemApi.LoginAdminAsync(model.Email, model.Password);
                }
                catch
                {;}
            }

            if (string.IsNullOrEmpty(session.SessionId))
            {


                Session["sessionId"] = session.SessionId;
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            return RedirectToLocal(returnUrl);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Register register = new Register
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Name = model.Name,
                    NewPassword = model.Password
                };

                bool result = await _userApi.RegisterAsync(register);

                if (result)
                {
                    Session session = await _userApi.LoginAsync(model.Email, model.Password);

                    if (string.IsNullOrEmpty(session.SessionId))
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return RedirectToAction("Login", "Account");
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "There has been an error registering your account.");
                }
            }
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _userApi.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}