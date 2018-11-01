using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebmvcApplication22.Models;

namespace WebmvcApplication22.Controllers
{
    public class AuthController : Controller
    {



        private readonly UserManager<AppUser> userManager;

        public AuthController()
            : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Auth
        public ActionResult Login()
        {
            var model = new LogInModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //if (model.Email == "admin@admin.com" && model.Password == "password")
            //    return RedirectToAction("index", "users");
            var user = await userManager.FindAsync(model.Email, model.Password);

            if (user != null)
            {
                if(userManager.IsInRole(user.Id,"Admin"))
                //var s = userManager.GetRoles(user.Id);
                //if (s[0].ToString() == "Admin")
                //{
                   return RedirectToAction("index", "users");

                ////}
                var identity = await userManager.CreateIdentityAsync(
                    user, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identity);
                //GetAuthenticationManager().SignIn(identity);

                //return Redirect(GetRedirectUrl(model.ReturnUrl));
                return RedirectToAction("stock", "users");
            }

            // user authN failed
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }
        //[HttpPost]
        //public ActionResult LogIn(LogInModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    // Don't do this in production!
        //    if (model.Email == "admin@admin.com" && model.Password == "password")
        //    {
        //        var identity = new ClaimsIdentity(new[] {
        //        new Claim(ClaimTypes.Name, "Ben"),
        //        new Claim(ClaimTypes.Email, "a@b.com"),
        //        new Claim(ClaimTypes.Country, "England")
        //    },
        //            "ApplicationCookie");

        //        var ctx = Request.GetOwinContext();
        //        var authManager = ctx.Authentication;

        //        authManager.SignIn(identity);

        //        return Redirect(GetRedirectUrl(model.ReturnUrl));
        //    }

        //    // user authN failed
        //    ModelState.AddModelError("", "Invalid email or password");
        //    return View();
        //}

        //private string GetRedirectUrl(string returnUrl)
        //{
        //    if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
        //    {
        //        return Url.Action("index", "home");
        //    }

        //    return returnUrl;
        //}

            [HttpGet]
        [Authorize(Roles = "Admin,company,Manager")]
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppUser
            {
                UserName = model.Email,
                Country = model.Country
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }


        private async Task SignIn(AppUser user)
        {

            var identity = await userManager.CreateIdentityAsync(
       user, DefaultAuthenticationTypes.ApplicationCookie);

            identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(identity);

            //GetAuthenticationManager().SignIn(identity);
            //        var identity = await userManager.CreateIdentityAsync(
            //            user, DefaultAuthenticationTypes.ApplicationCookie);

            //GetAuthenticationManager().SignIn(identity);
        }
    }
}