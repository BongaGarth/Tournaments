using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Model.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Enter role name")]
        [DisplayName("Name")]
        public string RoleName { get; set; }
    }
}
