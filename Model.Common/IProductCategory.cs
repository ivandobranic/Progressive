using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface IProductCategory
    {
        Guid Id { get; set; }

        String Name { get; set; }

        IEnumerable<IProduct> Products { get; set; }

    }
}
