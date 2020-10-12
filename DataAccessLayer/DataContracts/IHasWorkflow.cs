using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContracts
{
    public interface IHasStatus<T>
    {
        T CurrentStatus { get; set; }
    }
    public interface IHasWorkflow<T>
    {        
        List<T> NextStateTransitions { get; set; }
    }
}
