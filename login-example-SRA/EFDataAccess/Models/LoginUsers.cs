using System;
using System.ComponentModel.DataAnnotations;

namespace login_example_SRA.EFDataAccess
{
    /* 
        This model is not used since logging in has been done with the Identity package, 
        but I have left it here for reference along with the manual registering and login
        functions in AuthenticationController
    */
    public class LoginUsers
    {
        public int ID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}