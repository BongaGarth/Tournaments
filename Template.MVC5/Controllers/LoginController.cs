using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Template.BusinessLogic;
using Template.Model;

namespace Template.MVC5.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private readonly LoginBusiness _loginbusiness;
        public LoginController(LoginBusiness loginbusiness)
        {
            _loginbusiness = loginbusiness;
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            var loginview = new LoginModel();
            return View(loginview);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(LoginModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _loginbusiness.LogUserIn(model, AuthenticationManager);
                if (result)       
                    return RedirectToLocal(ReturnUrl);
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
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
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}