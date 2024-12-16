using System;
using System.Collections.Generic;
using GameBib.Data.Classes;

namespace GameBib.Data.Lists
{
    internal class UserList
    {
        public List<User> users = new List<User>()
        {
            new User {Id = 1, Name = "Michel", UserName = "Miesvors", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 0, LastFailedLogin = DateTime.Now.AddDays(-1), RememberToken = User.GenerateRandomToken()},
            new User {Id = 2, Name = "Laura", UserName = "LauSky", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 1, LastFailedLogin = DateTime.Now.AddHours(-5), RememberToken = User.GenerateRandomToken()},
            new User {Id = 3, Name = "Tom", UserName = "Tomster", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 0, LastFailedLogin = DateTime.Now.AddDays(-2), RememberToken = User.GenerateRandomToken()},
            new User {Id = 4, Name = "Emma", UserName = "EmStar", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 2, LastFailedLogin = DateTime.Now.AddMinutes(-30), RememberToken = User.GenerateRandomToken()},
            new User {Id = 5, Name = "James", UserName = "JimmyBoy", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 0, LastFailedLogin = DateTime.Now.AddHours(-10), RememberToken = User.GenerateRandomToken()},
            new User {Id = 6, Name = "Sophia", UserName = "Sophs", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 3, LastFailedLogin = DateTime.Now.AddDays(-3), RememberToken = User.GenerateRandomToken()},
            new User {Id = 7, Name = "Liam", UserName = "Liamster", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 0, LastFailedLogin = DateTime.Now.AddHours(-8), RememberToken = User.GenerateRandomToken()},
            new User {Id = 8, Name = "Olivia", UserName = "Livvy", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 1, LastFailedLogin = DateTime.Now.AddDays(-7), RememberToken = User.GenerateRandomToken()},
            new User {Id = 9, Name = "Ethan", UserName = "Ethanator", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 0, LastFailedLogin = DateTime.Now.AddDays(-14), RememberToken = User.GenerateRandomToken()},
            new User {Id = 10, Name = "Ava", UserName = "AvaQueen", HashedPassword = SecureHasher.Hash("123"), FailedLoginAttempts = 2, LastFailedLogin = DateTime.Now.AddDays(-1).AddHours(-3), RememberToken = User.GenerateRandomToken()}
        };

        public List<User> GetUserList()
        {
            return users;
        }
    }
}
