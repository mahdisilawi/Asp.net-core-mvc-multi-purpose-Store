
using Hyper_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        
        public string Name { get; set; }

        //relation with UserInRole
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
