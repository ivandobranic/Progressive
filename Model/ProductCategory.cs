using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProductCategory: IProductCategory
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public IEnumerable<IProduct> Products { get; set; }
    }
}
