using System;
using System.Collections.Generic;

namespace IO.Swagger.Data
{
    public partial class Users
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int? UserStatus { get; set; }
    }
}
