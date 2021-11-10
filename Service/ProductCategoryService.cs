using Common;
using Common.Filters;
using Model.Common;
using Repository.Common;
using Service.Common;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace Service
{
    public class ProductCategoryService : IProductCategoryService
    {

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            ProductCategoryRepository = productCategoryRepository;
        }

        public IProductCategoryRepository ProductCategoryRepository{ get; set; }

        public async Task<IProductCategory> GetByIdAsync(int id)
        {
            return await ProductCategoryRepository.GetByIdAsync(id);
        }

        public async Task<int> InsertAsync(IProductCategory domainModel)
        {
            return await ProductCategoryRepository.InsertAsync(domainModel);
        }

        public async Task<int> UpdateAsync(IProductCategory domainModel)
        {
            return await ProductCategoryRepository.UpdateAsync(domainModel);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await ProductCategoryRepository.DeleteAsync(id);
        }
        public async Task<IPagedList<IProductCategory>> FindAsync(IProductCategoryFilter filter, IOptionParameters options)
        {
            return await ProductCategoryRepository.FindAsync(filter, options);

        }
    }
}
