using NHibernate.Mapping.ByCode.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AydinCompany.Core.Utilities.Mappings
{
    public class AutoMapperHelper
    {
        public static List<T> MapToSameTypeList<T>(List<T> list)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>(); });
            List<T> products = Mapper.Map<List<T>, List<T>>(list);
            return products;
        }

        public static T MapToSameType<T>(T list)
        {
            Mapper.Initialize(c => { c.CreateMap<T, T>(); });
            T product = Mapper.Map<T, T>(list);
            return product;
        }
    }
}
