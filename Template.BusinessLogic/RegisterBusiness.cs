using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Template.Data;
using Template.Model;
using Template.Model.ViewModels;

namespace Template.BusinessLogic
{
    public class RegisterBusiness : IRegisterBusiness
    {
        public UserManager<ApplicationUser> UserManager { get; set; }
        public RoleManager<ApplicationRole> RoleManager { get; set; }

        public RegisterBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));

            RoleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new DataContext()));
        }

        public bool FindUser(string userName, IAuthenticationManager authenticationManager)
        {
            var user = UserManager.FindByName(userName);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> RegisterUser(RegisterModel objRegisterModel,string rolename, IAuthenticationManager authenticationManager)
        {
            var newuser = new ApplicationUser()
            {
                UserName = objRegisterModel.UserName,
                Email = objRegisterModel.UserName,
                PasswordHash = UserManager.PasswordHasher.HashPassword(objRegisterModel.Password),
                Name= objRegisterModel.Name,
                Surname= objRegisterModel.Surname,
                IsActive=true
            };

            var result = await UserManager.CreateAsync(
               newuser, objRegisterModel.Password);



            if (result.Succeeded)
            {
                var putput = UserManager.AddToRole(newuser.Id, rolename);
                return true;
            }
            return false;
        }

        public bool AddUserToRole(string user, string role)
        {
            var result = UserManager.AddToRole(user, role);

            return result.Succeeded;
        }
        public bool RoleExists(string name)
        {
            return RoleManager.RoleExists(name);
        }
        public bool CreateRole(string name)
        {
            var result = RoleManager.Create(new ApplicationRole(name));
            return result.Succeeded;
        }

        public List<RoleViewModel>GetAllRoles()
        {
            var list = new List<RoleViewModel>();
            foreach(var role in RoleManager.Roles.Where(p=>p.Name !="Client"))
            {
                list.Add(new RoleViewModel
                {
                    ID=role.Id,
                    Name=role.Name,
                });
            }

            return list;
        }
        public  List<UsersViewModel> Users()
        {
            var list = new List<UsersViewModel>();
            foreach (var user in UserManager.Users)
            {
                var rolelist = UserManager.GetRoles(user.Id).ToList();
                list.Add(new UsersViewModel
                {
                    Id=user.Id,
                    UserName = user.UserName,
                    Email = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    RoleName=  rolelist.FirstOrDefault(),
                    IsActive=user.IsActive
                });
            }
            return list;
        }
        public List<UsersViewModel> UsersRoles(string rolename)
        {
            var list = new List<UsersViewModel>();
            foreach (var user in UserManager.Users)
            {
                var rolelist = UserManager.GetRoles(user.Id).ToList();
                var userrole = new UsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.UserName,
                    Name = user.Name,
                    Surname = user.Surname,
                    RoleName = rolelist.FirstOrDefault(),
                    IsActive = user.IsActive
                };
                if (userrole.RoleName.Equals(rolename))
                {
                    list.Add(userrole);
                }
            }
            return list;
        }
    }
}
