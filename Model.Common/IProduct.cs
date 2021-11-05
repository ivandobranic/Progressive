using System;

namespace Model.Common
{
    public interface IProduct
    {
        Guid Id { get; set; }

        String Name { get; set; }

        decimal Price { get; set; }

        Guid ProductCategoryId { get; set; }

        IProductCategory ProductCategory {get; set;}
        
    }
}
