using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Template.BusinessLogic;
using Template.Model;

namespace Template.MVC5.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegisterController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: Register
        public ActionResult Index()
        {
            var registerbusiness = new RegisterBusiness();

            var newuser = new RegisterModel
            {
                Roles = registerbusiness.GetAllRoles()
            };
            return View(newuser);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Index(RegisterModel objRegisterModel)
        {
            var registerbusiness = new RegisterBusiness();

            if (registerbusiness.FindUser(objRegisterModel.UserName, AuthenticationManager))
            {
                ModelState.AddModelError("", "User already exists");
                return View(objRegisterModel);
            }

            var result = await registerbusiness.RegisterUser(objRegisterModel,objRegisterModel.RoleId, AuthenticationManager);

            if (result)
            {
                return RedirectToAction("Index", "Material");
            }
            else
            {
                ModelState.AddModelError("", result.ToString());
            }

            return View(objRegisterModel);
        }


    }
}