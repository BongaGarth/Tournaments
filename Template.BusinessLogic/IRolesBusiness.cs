using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.BusinessLogic
{
    public interface IRolesBusiness
    {
        bool RoleExists(string name);
        bool CreateRole(string name);
    }
}
