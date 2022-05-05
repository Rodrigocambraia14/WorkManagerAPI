using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.CrossCutting.Enums;

namespace WM.Context.Default.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string ImageProfile { get; set; }

        public UserType UserType { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
