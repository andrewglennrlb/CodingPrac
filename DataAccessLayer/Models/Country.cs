using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Country
    {
            [Key]
            public Int64 CountryId { get; set; }


            public String CountryGlobalName { get; set; }


            public String CountryLocalName { get; set; }


            public String CountryISOCode { get; set; }


            public String Currency { get; set; }


            public String LanguageISO { get; set; }
     
    }
}
