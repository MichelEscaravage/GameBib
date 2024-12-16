using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameBib.Data.Classes
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public static User LoggedInUser { get; set; }
        public string HashedPassword { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime LastFailedLogin { get; set; }

        public string RememberToken { get; set; }
        public int RoleId { get; set; }
        public ICollection<UserGames> UserGames { get; set; }

        public User()
        {
            RoleId = Role.User;
        }

        public static string GenerateRandomToken()
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = 10;
            char[] randomChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomChars[i] = characters[RandomNumberGenerator.GetInt32(0, characters.Length)];
            }

            return new string(randomChars);
        }
    }
}
    