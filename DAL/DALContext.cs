using Microsoft.EntityFrameworkCore;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DALContext : DbContext
    {
        public DbSet<IProduct> Product
    }
}
