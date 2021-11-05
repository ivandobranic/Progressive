using Model.Common;
using System;

namespace Model
{
    public class Product: IProduct
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public decimal Price { get; set; }

        public Guid ProductCategoryId { get; set; }

        public IProductCategory ProductCategory { get; set; }

      
    }
}
