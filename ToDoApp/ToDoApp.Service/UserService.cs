﻿using System.Security.Cryptography;
using System.Text;
using ToDoApp.Model;
using ToDoApp.Repository;

namespace ToDoApp.Service
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<bool> Login(string username, string password)
        {
            var user = await userRepository.GetByUsername(username);

            bool shouldLogged = user != null && user.Password == GenerateHashPass(password);

            if (shouldLogged)
            {
                await SecureStorage.SetAsync("logged_user", username);
                return true;
            }

            return false;
        }

        public async Task Register(string username, string password)
        {

            bool doesExists = await userRepository.ExistsByUsername(username);

            if (doesExists)
            {
                return;
            }

            var user = new User
            {
                Username = username,
                Password = GenerateHashPass(password)
            };

            await userRepository.Save(user);
        }

        private string GenerateHashPass(string notHashedPass)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(notHashedPass);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (var byteValue in hashBytes)
                {
                    hashStringBuilder.Append(byteValue.ToString("x2"));
                }

                return hashStringBuilder.ToString();
            }
        }
    }
}
