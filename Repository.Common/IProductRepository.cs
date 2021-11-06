using Common;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Repository.Common
{
    public interface IProductRepository
    {
        Task<IProduct> GetByIdAsync(int id);
        Task<int> InsertAsync(IProduct domainModel);
        Task<int> UpdateAsync(IProduct domainModel);
        Task<int> DeleteAsync(int id);
        Task<IPagedList<IProduct>> FindAsync(IProductFilter filter, IOptionParameters options);
    }
}
