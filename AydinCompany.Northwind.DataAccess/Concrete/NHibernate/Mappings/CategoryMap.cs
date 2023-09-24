using AydinCompany.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace AydinCompany.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Products");
            LazyLoad();

            Id(x => x.CategoryId);
            
            Map(x => x.CategoryId).Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
