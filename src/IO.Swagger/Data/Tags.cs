using System;
using System.Collections.Generic;

namespace IO.Swagger.Data
{
    public partial class Tags
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? PetId { get; set; }

        public virtual Pets Pet { get; set; }
    }
}
