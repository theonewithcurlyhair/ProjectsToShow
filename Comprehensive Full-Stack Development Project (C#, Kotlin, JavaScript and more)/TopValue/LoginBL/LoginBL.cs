using Model.Entities;
using SQLLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoginBL
    {
        public DataTable Authenticate(string login, string password)
        {
            if(ValidateAuthentication(login, password))
            {
                LoginDB loginDB = new LoginDB();
                var data = Encoding.ASCII.GetBytes(password);
                var md5 = new MD5CryptoServiceProvider();
                var hashedPassword = md5.ComputeHash(data);
                string hashString = BitConverter.ToString(hashedPassword).Replace("-", String.Empty).ToLower();
                return loginDB.RetrieveLevelAccess(login, hashString);
            }
            return new DataTable();
        }

        public bool ValidateAuthentication(string login, string password)
        {
            int n = 0;
            int.TryParse(login, out n);
            if (n <= 0 || String.IsNullOrEmpty(password))
            {
                return false;
            }
            return true;
        }

        private LoginDB loginRepo = new LoginDB();

        public bool LoginSuccessful(User user)
        {
            if (Valid(user))
            {
                var data = Encoding.ASCII.GetBytes(user.Password);
                var md5 = new MD5CryptoServiceProvider();
                var hashedPassword = md5.ComputeHash(data);
                user.Password = BitConverter.ToString(hashedPassword).Replace("-", String.Empty).ToLower();
                user = loginRepo.Login(user);
            }

            return user.Errors.Count == 0 ? true : false;
        }

        private Boolean Valid(User user)
        {
            int? id = user.ID;
            if (id == null || id < 1) user.AddError(new Error("Employee ID is required"));
            if (user.Password == "" || user.Password == null) user.AddError(new Error("Password is required"));

            return user.Errors.Count == 0;
        }
    }
}

