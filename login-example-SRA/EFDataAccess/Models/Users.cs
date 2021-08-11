using System;
using System.ComponentModel.DataAnnotations;

namespace login_example_SRA.EFDataAccess
{
    public class Users
    {
        public int ID { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; } = 0;
    }
}