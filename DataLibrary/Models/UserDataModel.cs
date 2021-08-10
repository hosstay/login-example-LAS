using System;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; } = 0;
    }
}