using System;
using System.Collections.Generic;

namespace IO.Swagger.Data
{
    public partial class Pets
    {
        public Pets()
        {
            Tags = new HashSet<Tags>();
        }

        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public string[] PhotoUrls { get; set; }
        public int? Status { get; set; }

        public virtual Categorys Category { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
    }
}
