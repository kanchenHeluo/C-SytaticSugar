using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFluentNHibernate
{
    public class Store
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDateUTC { get; set; }
        public virtual IList<Product> Products { get; set; }

        public virtual void AddProduct(Product prod)
        {
            if(Products == null)
                Products = new List<Product>();
            Products.Add(prod);
        }
    }

    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Table("dbo.Store");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description, "Interpretation").Nullable();
            Map(x => x.CreatedDateUTC).Nullable();
            HasManyToMany(x => x.Products)
                .Cascade.SaveUpdate() //cascade: All, Delete, SaveOrUpdate
                .Inverse()
                .Table("dbo.Product");
        }
    }
}
