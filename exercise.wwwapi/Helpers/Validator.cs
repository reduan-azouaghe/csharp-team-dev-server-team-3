using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;
using System.Net.Mail;

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

        public static string Email(string emailString, List<string> emails)
        {
            // Valid email format                | Done
            // Email already exist in database

            if (string.IsNullOrWhiteSpace(emailString)) return "Email string is empty";
            try
            {
                if (new MailAddress(emailString).Address != emailString) return "Invalid email format";
            }
            catch 
            {
                return "Invalid email format";
            }
            // TODO: Get all emails in Endpoint where this method is called. Check if emailString already exists.
            return "Accepted";
        }
    }
}
