using AydinCompany.Northwind.DataAccess.Concrete.EntityFramework;
using AydinCompany.Northwind.DataAccess.Concrete.NHibernate;
using AydinCompany.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AydinCompany.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal nhProductDal = new NhProductDal(new SqlServerHelper());
            var result = nhProductDal.GetList();
            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal nhProductDal = new NhProductDal(new SqlServerHelper());
            var result = nhProductDal.GetList(p => p.ProductName.Contains("ab"));
            Assert.AreEqual(5, result.Count);
        }
    }
}
