using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class FunderContact
    {
        [Key]
        public Int64 FunderContactId { get; set; }

        public Int64? UserId { get; set; }


        public String Title { get; set; }


        public String ContactPhone { get; set; }


        public String ContactOther { get; set; }


        public String Position { get; set; }


        public Int64 FunderId { get; set; }
    }
}
