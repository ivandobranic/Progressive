using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IOptionParameters
    {
        bool IsAscending { get; set; }

        int PageNumber { get; set; }

        int PageSize { get; set; }

        int TotalCount { get; set; }
    }
}
