
using Dapper.Contrib.Extensions;

namespace DAL.Models
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }


        public string ProvinceGlobalName { get; set; }


        public string ProvinceLocalName { get; set; }


        public string Country { get; set; }


        public string Bounds { get; set; }

    }
}
