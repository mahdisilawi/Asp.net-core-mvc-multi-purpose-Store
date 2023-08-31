
using Hyper_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyper_Store.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public long Id { get; set; }

        //relation with User
        public virtual User User { get; set; }
        public long UserId { get; set; }
        
        //relation with Role
        public virtual Role  Role { get; set; }
        public long RoleId { get; set; }
    }
}
