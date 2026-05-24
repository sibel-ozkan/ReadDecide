using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class User
    {

       
            public int UserId { get; set; }
            public string DisplayName { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public int RoleId { get; set; }
            public string RoleName { get; set; }
            public DateTime CreatedAt { get; set; }
            public bool IsActive { get; set; }

        public string Password { get; set; }
    }
}
