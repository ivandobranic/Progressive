using Autofac;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Repository;

namespace Service
{
    public class DIModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>();
            builder.RegisterModule(new Repository.DIModule());
        }
    }
}
