using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data;
using Template.Model;

namespace Template.BusinessLogic
{
    public interface ILoginBusiness
    {
      Task<bool> LogUserIn(LoginModel objLoginModel, IAuthenticationManager authenticationManager);

      Task SignInAsync(ApplicationUser user, bool isPersistent, IAuthenticationManager authenticationManager);

    }
}
