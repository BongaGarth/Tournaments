using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Template.Model.ViewModels;

namespace Template.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        [DataType(DataType.Password)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your surname")]
        [DataType(DataType.Password)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Choose Role")]
        public string RoleId { get; set; }

        public List<RoleViewModel> Roles { get; set; }

    }
}