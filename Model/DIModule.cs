using Autofac;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Model
{
    public class DIModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ProductCategory>().As<IProductCategory>();
            builder.RegisterType<Product>().As<IProduct>();

        }
    }
}
