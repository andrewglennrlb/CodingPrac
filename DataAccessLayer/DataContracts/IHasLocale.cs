using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContracts
{
    public interface IHasLocale
    {
        int LocaleId { get; set; }
        Locale locale { get; set; }
    }
}
