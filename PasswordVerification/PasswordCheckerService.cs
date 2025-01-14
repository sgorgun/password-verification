﻿using System;
using System.Linq;

namespace PasswordVerification
{
    public class PasswordCheckerService
    {
        private readonly SqlRepository repository = new SqlRepository();

        public (bool, string) VerifyPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"{password} is null or empty.", nameof(password));
            }
            
            if (password == string.Empty)
            {
                return (false, $"{password} is empty ");
            }
            
            // check if length more than 7 chars 
            if (password.Length <= 7)
            {
                return (false, $"{password} length too short");
            }
            
            // check if length more than 10 chars for admins
            if (password.Length >= 15)
            {
                return (false, $"{password} length too long");
            }

            // check if password contains at least one alphabetical character 
            if (!password.Any(char.IsLetter))
            {
                return (false, $"{password} hasn't alphanumerical chars");
            }
            
            // check if password contains at least one digit character 
            if (!password.Any(char.IsNumber))
            {
                return (false, $"{password} hasn't digits");
            }
            
            this.repository.Create(password);

            return (true, "Password is Ok. User was created");
        }
    }

}