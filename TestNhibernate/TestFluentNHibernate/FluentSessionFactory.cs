
using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using TestFluentNHibernate.AutoMapper;

namespace TestFluentNHibernate
{
    public class FluentSessionFactory
    {
        private static ISessionFactory SessionFactory { get; set; }
        public static ISessionFactory GetCurrentFactory()
        {
            if (SessionFactory == null)
            {
                SessionFactory = CreateSessionFactory();
            }
            return SessionFactory;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var bossModel = AutoMap.AssemblyOf<Boss>(t => t.Namespace.StartsWith(typeof(Boss).Namespace));
            //var employeeModel = AutoMap.AssemblyOf<Employee>(t => t.Namespace.StartsWith(typeof(Employee).Namespace));

            var employeeModel = AutoMap.AssemblyOf<Employee>(t => t.Namespace == (typeof(Employee).Namespace))
                .UseOverridesFromAssemblyOf<EmployeeMappingOverride>();
            /*
                .Override<Employee>(map => 
                {
                    map.Map(x => x.EmpAlias, "Name");
                });
              */
              
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=.;Initial Catalog=LocalDemo;User ID=DemoUser;Password=1qaz@WSX")
                )
                .Mappings((m => {
                    m.FluentMappings.AddFromAssemblyOf<Program>();
                    m.AutoMappings.Add(employeeModel);
                    m.AutoMappings.Add(bossModel);
                    }))
                //.Mappings(m =>
                //  m.AutoMappings.Add(
                //  AutoMap.AssemblyOf<Employee>()))
                .BuildSessionFactory();

        }
    }
}
