

using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace TestFluentNHibernate.AutoMapper
{
    public class Employee
    {
        public virtual long Id { get; set; }
        public virtual string EmpAlias { get; set; }

        /*
        public virtual Boss Boss { get; set; }

        public virtual void PopulateBoss(Boss boss)
        {
            Boss = boss;
        }*/
    }
    
    public class EmployeeMappingOverride : IAutoMappingOverride<Employee>
    {
        public void Override(AutoMapping<Employee> mapping)
        {
            mapping.Table("dbo.Employee");
            mapping.Id(x => x.Id);
            mapping.Map(x=>x.EmpAlias, "Name");
        }
    }
}
