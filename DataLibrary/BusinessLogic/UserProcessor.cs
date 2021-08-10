using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class UserProcessor
    {
        public static int CreateUser(string username, string password, string email, int age)
        {
            UserDataModel data = new UserDataModel
            {
                Username = username,
                Password = password,
                Email = email,
                Age = age
            };

            string sql = @"INSERT INTO dbo.users 
                            (username, password, email, age) VALUES
                            (@Username, @Password, @Email, @Age);";

            return SqlDataAccess.CreateData(sql, data);
        }

        public static List<UserDataModel> LoadUsers()
        {
            string sql = @"SELECT 
                            id, 
                            username, 
                            password, 
                            email, 
                            age 
                        FROM 
                            dbo.users;";

            return SqlDataAccess.ReadData<UserDataModel>(sql, null);
        }

        public static UserDataModel LoadUser(int id)
        {
            UserDataModel data = new UserDataModel
            {
                Id = id
            };

            string sql = @"SELECT 
                            id, 
                            username, 
                            password, 
                            email, 
                            age
                        FROM 
                            dbo.users
                        WHERE
                            id = @id;";

            return SqlDataAccess.ReadData<UserDataModel>(sql, data).First();
        }

        public static int UpdateUser(int id, string username, string password, string email, int age)
        {
            UserDataModel data = new UserDataModel
            {
                Id = id,
                Username = username,
                Password = password,
                Email = email,
                Age = age
            };

            string sql = @"UPDATE dbo.users SET username = @Username, password = @Password, email = @Email, age = @Age WHERE id = @Id;";

            return SqlDataAccess.UpdateData(sql, data);
        }

        public static int DeleteUser(int id)
        {
            UserDataModel data = new UserDataModel
            {
                Id = id
            };

            string sql = @"DELETE FROM dbo.users WHERE id = @Id;";

            return SqlDataAccess.DeleteData(sql, data);
        }
    }
}
