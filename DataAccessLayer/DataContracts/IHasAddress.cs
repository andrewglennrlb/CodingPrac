using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContracts
{
    public interface IHasAddress
    {
        int AddressId { get; set; }

        Address Address { get; set; }
    }
}
