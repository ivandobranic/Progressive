using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.Common;
using X.PagedList;
using Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository
{
    public class ProductRepository : IProductRepository
    {

        public ProductRepository(IGenericRepository<IProduct> genericGenericRepository)
        {
            GenericRepository = genericGenericRepository;

        }

        public IGenericRepository<IProduct> GenericRepository { get; set; }

        public async Task<IProduct> GetByIdAsync(int id)
        {
          return await GenericRepository.GetByIdAsync(id);

        }

        public async Task<int> InsertAsync(IProduct domainModel)
        {
            return await GenericRepository.InsertAsync(domainModel);

        }

        public async Task<int> UpdateAsync(IProduct domainModel)
        {
            return await GenericRepository.UpdateAsync(domainModel);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await GenericRepository.DeleteAsync(id);
        }
        public async Task<IPagedList<IProduct>> FindAsync(IProductFilter filter, IOptionParameters options)
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
            return new StaticPagedList<IProduct>(enumerableQuery, options.PageNumber, options.PageSize, options.TotalCount);
        }
    }
}
