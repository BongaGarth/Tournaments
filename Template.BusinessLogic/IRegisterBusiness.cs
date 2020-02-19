using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data;
using Template.Model;
using Template.Model.ViewModels;

namespace Template.BusinessLogic
{
    public interface IRegisterBusiness
    {
        bool FindUser(string userName, IAuthenticationManager authenticationManager);
        Task<bool> RegisterUser(RegisterModel objRegisterModel, string rolename, IAuthenticationManager authenticationManager);
        bool AddUserToRole(string user, string role);
        bool RoleExists(string name);
        bool CreateRole(string name);
        List<RoleViewModel> GetAllRoles();
         List<UsersViewModel> Users();
        List<UsersViewModel> UsersRoles(string rolename);
    }
}
