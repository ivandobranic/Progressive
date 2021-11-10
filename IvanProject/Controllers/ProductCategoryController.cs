using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Common;
using Service.Common;

namespace IvanProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            ProductCategoryService = productCategoryService;
        }
        public IProductCategoryService ProductCategoryService { get; set; }

        [HttpGet]
        public async Task<IEnumerable<IProductCategory>> FindAsync()
        {
            var filter = new ProductCategoryFilter();
            var options = new OptionParameters();
            return await ProductCategoryService.FindAsync(filter, options);
        }
    }
}
