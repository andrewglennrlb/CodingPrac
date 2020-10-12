using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Locale
    {
        public int LocaleId { get; set; }

        public string CultureCode { get; set; }

        public string Timezone { get; set; }

        public string CurrencyISO { get; set; }

        public string LanguageISO { get; set; }
    }
}
