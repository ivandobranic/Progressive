using Common;
using Common.Filters;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {

        public ProductCategoryRepository(IGenericRepository<IProductCategory> genericGenericRepository)
        {
            GenericRepository = genericGenericRepository;
        }

        public IGenericRepository<IProductCategory> GenericRepository { get; set; }

        public async Task<IProductCategory> GetByIdAsync(int id)
        {
            return await GenericRepository.GetByIdAsync(id);

        }

        public async Task<int> InsertAsync(IProductCategory domainModel)
        {
            return await GenericRepository.InsertAsync(domainModel);

        }

        public async Task<int> UpdateAsync(IProductCategory domainModel)
        {
            return await GenericRepository.UpdateAsync(domainModel);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await GenericRepository.DeleteAsync(id);
        }
        public async Task<IPagedList<IProductCategory>> FindAsync(IProductCategoryFilter filter, IOptionParameters options)
        {
            var query = GenericRepository.Get();

            query = options.IsAscending == false ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);
            if (!string.IsNullOrEmpty(filter.Search))
            {
                options.TotalCount = await query.Where(x => x.Name == filter.Search).CountAsync();
                query = query.Where(x => x.Name == filter.Search).Skip((options.PageNumber - 1) * options.PageSize).Take(options.PageSize);
            }
            else
            {
                options.TotalCount = await query.CountAsync();
                query = query.Skip((options.PageNumber - 1) * options.PageSize).Take(options.PageSize);
            }
            var enumerableQuery = query.AsEnumerable();
            return new StaticPagedList<IProductCategory>(enumerableQuery, options.PageNumber, options.PageSize, options.TotalCount);
        }
    }
}
