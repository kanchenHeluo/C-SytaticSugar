using System;

namespace TestNhibernate
{
    public class Audit
    {
        public virtual long ID { get; set; }

        public virtual string Type { get; set; }

        public virtual string UniqueID { get; set; }

        public virtual string Username { get; set; }

        public virtual string Message { get; set; }

        public virtual string Description { get; set; }
        public virtual DateTime CreatedDateUTC { get; set; }
    }
}
