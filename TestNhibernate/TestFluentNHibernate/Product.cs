using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace TestFluentNHibernate
{
    public class Product
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDateUTC { get; set; }
    }

    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("dbo.Product");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Description, "Interpretation");
            Map(x => x.CreatedDateUTC);
        }
    }
}
