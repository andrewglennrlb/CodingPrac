using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public Byte[] Password { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? PrimaryOrgGroup { get; set; }

        public int PrimaryRole { get; set; }

        [Computed]
        public IEnumerable<UserRole> Roles { get; set; }

        [Computed]
        public OrgGroup OrganisationGroup { get; set; }
    }
}
