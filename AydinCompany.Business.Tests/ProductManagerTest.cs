using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AydinCompany.Northwind.Business.Concrete.Manager;
using Moq;
using AydinCompany.Northwind.DataAccess.Abstract;
using AydinCompany.Northwind.Entities.ComplexType;
using FluentValidation;

namespace AydinCompany.Business.Tests
{
    [TestClass]
    public class ProductManagerTest
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            //Bir testing birim testi(Unit Test) olabilmesi için tek bir katmanın yani ünitenin test edilmesi gereklidir.
            //Bundan dolayı diğer katmanları dahil etmemek adına Mock nesnesi kullanıyoruz.
            //Mock(sahte) nesnesi ile sahte bir DataAccess Layer yaratıyoruz ve ilgili Business sınıfına yani ProductManager'a sahte DataAccess katmanını enjekte ediyoruz ki hiç gerçek dataaccess devreye girmesin. Böylelikle Unit Test olmuş olur.
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}
