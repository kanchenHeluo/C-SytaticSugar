using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using System.Collections.Generic;

namespace TestFluentNHibernate.AutoMapper
{
    public class Boss
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Employee> Employees { get; set; }

        public virtual void AddEmployees(Employee emp)
        {
            if(Employees == null)
            {
                Employees = new List<Employee>();
            }
            Employees.Add(emp);
        }
    }
/*
    public class BossMappingOverride : IAutoMappingOverride<Boss>
    {
        public void Override(AutoMapping<Boss> mapping)
        {
            mapping.Id(u => u.Id);
        }
    }*/
}
