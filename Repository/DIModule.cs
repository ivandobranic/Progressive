using Autofac;
using Repository;
using Model.Common;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Repository
{
    public class DIModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GenericRepository<IProductCategory>>().As<IGenericRepository<IProductCategory>>();
            builder.RegisterType<GenericRepository<IProduct>>().As<IGenericRepository<IProduct>>();
            builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            // var profiles =
            //from t in typeof(MappingProfile).Assembly.GetTypes()
            //where typeof(Profile).IsAssignableFrom(t)
            //select (Profile)Activator.CreateInstance(t);

            //builder.Register(c => new MapperConfiguration(cfg =>
            //{
            //    foreach (var profile in profiles)
            //    {
            //        cfg.AddProfile(profile);
            //    }
            //}));

            //builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();

        }
    }
}
