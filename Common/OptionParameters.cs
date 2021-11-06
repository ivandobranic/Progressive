using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class OptionParameters: IOptionParameters
    {
        public bool IsAscending { get; set; }


        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }
    }
}
