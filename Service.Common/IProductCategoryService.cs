using Common;
using Common.Filters;
using Model.Common;
using System;
using System.Threading.Tasks;
using X.PagedList;

namespace Service.Common
{
    public interface IProductCategoryService
    {
        Task<IProductCategory> GetByIdAsync(int id);
        Task<int> InsertAsync(IProductCategory domainModel);
        Task<int> UpdateAsync(IProductCategory domainModel);
        Task<int> DeleteAsync(int id);
        Task<IPagedList<IProductCategory>> FindAsync(IProductCategoryFilter filter, IOptionParameters options);
    }
}
