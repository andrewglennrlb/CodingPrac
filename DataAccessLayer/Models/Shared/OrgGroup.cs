using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class OrgGroup
    {
        [Key]
        public int OrgGroupId { get; set; }


        public string OrgGroupName { get; set; }


        public int OrgGroupParentId { get; set; }


        public int OrgGroupAddressId { get; set; }


        public int OrgGroupLocaleId { get; set; }


        public string OrgGroupCurrency { get; set; }
    }
}
