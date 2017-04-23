using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using TestFluentNHibernate.AutoMapper;

namespace TestFluentNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //step1: create session factory
            var sessionFactory = FluentSessionFactory.GetCurrentFactory();
            /*
            AutoMap.AssemblyOf<Employee>(cfg)
                .UseOverridesFromAssemblyOf<EmployeeMappingOverride>();
            //step2: create session, save or update
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    Product au = session.Get<Product>(1l);
                    if(au == null)
                    {
                        au = new Product()
                        {
                            Name = "apple",
                            Description = "this is an apple",
                            CreatedDateUTC = DateTime.Now
                        };
                    }else
                    {
                        au.Name = "red apple";
                        au.Description = "this is a red apple";
                        au.CreatedDateUTC = DateTime.Now;
                    }
                    session.SaveOrUpdate(au); //only Id is generated but not assigned ->identity(); if assigned, can only use save/update

                    trans.Commit();
                }
            }
            //step3: cascade
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var store = new Store()
                    {
                        Name = "Walmart",
                        Description = "this is an supermarket",
                        CreatedDateUTC = DateTime.Now
                    };

                    session.Save(store);
                    Product au = session.Get<Product>(1l);
                    if (au != null)
                    {
                        store.AddProduct(au);
                    }
                    Product new_prod = new Product()
                    {
                        Name = "Lemon",
                        Description= "this is a lemon",
                        CreatedDateUTC = DateTime.Now
                    };
                    store.AddProduct(new_prod);

                    
                    session.SaveOrUpdate(store); 

                    trans.Commit();
                }
            }


            //step4: create session, query
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {

                    IList<string> products_description = session.QueryOver<Product>()  
                                            .WhereRestrictionOn(x => x.Name).IsLike("%Apple%")
                                            .Select(x => x.Description)
                                          .OrderBy(x => x.CreatedDateUTC).Desc
                                          .List<string>();
                    trans.Commit();

                    if (products_description.Count > 0)
                    {
                        Console.WriteLine(products_description.FirstOrDefault());
                    }
                    else
                    {
                        Console.WriteLine("there's none found.");
                    }
                }
            }
            */
            //step5: automapper
            using (var session = sessionFactory.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    var b = new Boss()
                    {
                        Name = "kanchen"
                    };
                    session.SaveOrUpdate(b);

                    var e = new Employee()
                    {
                        EmpAlias = "dev-kanchen"
                    };
                    //e.PopulateBoss(b);
                    session.SaveOrUpdate(e);
                    trans.Commit();
                }
            }

            Console.Read();
        }
    }
}
