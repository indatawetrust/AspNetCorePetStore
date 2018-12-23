using System;
using System.Collections.Generic;

namespace IO.Swagger.Data
{
    public partial class Orders
    {
        public long Id { get; set; }
        public long? PetId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? Status { get; set; }
        public bool? Complete { get; set; }
    }
}
