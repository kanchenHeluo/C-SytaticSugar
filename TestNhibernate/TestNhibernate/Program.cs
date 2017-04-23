using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate;
using NHibernate.Cfg;

namespace TestNhibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            //step1: get program assembly
            Assembly assembly = typeof(Program).Assembly;
            //step2: configuration
            Configuration configuration = new Configuration()
                .Configure() //get hibernate.cfg.xml
                .AddAssembly(assembly) ; //get class and xml

            //step3: create sessionfactory
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();

            //step4: get 
            IList<Audit> audits = session.QueryOver<Audit>()
                                            .Where(x => x.UniqueID == "EBD57A02-DD26-434A-8CDD-A72F01656B05")
                                          .OrderBy(x => x.CreatedDateUTC).Desc
                                          .List<Audit>();

            //step5: verify
            foreach (var audit in audits)
            {
                Console.WriteLine(audit.UniqueID+"\t"+audit.Username+"\t"+audit.Description);
            }

            Console.Read();
        }
    }
}
