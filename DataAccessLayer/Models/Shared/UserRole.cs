using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }


        public string RoleName { get; set; }


        public int RoleLevel { get; set; }
    }
}
