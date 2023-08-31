
using Hyper_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string? Password { get; set; }


        //relation with UserInRole
        public ICollection<UserInRole> UserInRoles { get; set; }

    }
}
