using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContracts
{
    public interface IReportable
    {
        int ReportingPeriodId { get; set; }
    }
}
