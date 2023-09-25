using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Business.ValidationRules.FluentValidation;
using AydinCompany.Northwind.Entities.ComplexType;
using FluentValidation;
using Ninject.Modules;

namespace AydinCompany.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>();
        }
    }
}
