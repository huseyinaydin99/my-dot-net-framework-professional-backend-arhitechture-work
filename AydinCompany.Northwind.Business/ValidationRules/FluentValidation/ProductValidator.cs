using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AydinCompany.Northwind.Entities.ComplexType;
using FluentValidation;

namespace AydinCompany.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductId).NotNull().NotEmpty().WithMessage("Boş geçilemez.");
            RuleFor(p => p.ProductName).NotNull().NotEmpty();
            RuleFor(p => p.ProductId).NotNull().NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(p => p.QuantityPerUnit).NotNull().NotEmpty();
            RuleFor(p => p.ProductName).Length(2, 20); //min 2 max 20 karakter olabilir. 2 ila 20 arası olmak zorundadır.
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.ProductId == 1); //ürün id'si 1 girildiğinde UnitPrice'i 20'nin üstünde girmek zorundadır diye kural koyduk.
            RuleFor(p => p.ProductName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
