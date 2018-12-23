using System;
using System.Collections.Generic;

namespace IO.Swagger.Data
{
    public partial class Categorys
    {
        public Categorys()
        {
            Pets = new HashSet<Pets>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pets> Pets { get; set; }
    }
}
