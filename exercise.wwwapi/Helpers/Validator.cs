using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Helpers
{
    public static class Validator
    {
        public static string Password(string passwordString)
        {
            // Not less than 8 characters       | Done
            // Atleast one uppercase            | Done
            // Atleast one number               | Done
            // Atleast one special character    | Done

            if (passwordString.Count() < 8) return "Too few characters";

            if (!passwordString.Any(char.IsUpper)) return "Missing uppercase characters";

            if (!passwordString.Any(char.IsNumber)) return "Missing number(s) in password";

            // Accept only !@#$%^&*()-_=+{};:',./\|~
            string regexPattern = ".*[!@#$%^&*()\\-_=+{};:',./\\\\|~].*";
            if (!Regex.IsMatch(passwordString, regexPattern)) return "Missing special character";
            return "Accepted";
        }

        public static string Email(string emailString)
        {
            if (!new EmailAddressAttribute().IsValid(emailString)) return "Invalid email format";
            if (!Regex.IsMatch(emailString, @"@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$")) return "Invalid email domain";
            return "Accepted";
        }
    }
}
