using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeroBolee.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PasswordAttribute : ValidationAttribute
    {
        public int MinLength { get; set; } = 6;
        public int MaxLength { get; set; } = 8;

        public override bool IsValid(object value)
        {
            string pwd = value == null ? null : value.ToString();
            if (pwd != null)
            {
                bool isValid = HasLowerCaseLetter(pwd) & HasUpperCaseLetter(pwd) & HasSpecialChar(pwd) & HasDigit(pwd) & HasMinimumLength(pwd, MinLength) & IsBelowMaximumLength(pwd, MaxLength);
                return isValid;
            }
            return false;
        }


        /// <summary>
        /// Returns TRUE if the password has at least one lowercase letter
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool HasLowerCaseLetter(string password)
        {
            return password.Any(c => char.IsLower(c));
        }

        /// <summary>
        /// Returns TRUE if the password has at least one uppercase letter
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool HasUpperCaseLetter(string password)
        {
            return password.Any(c => char.IsUpper(c));
        }

        /// <summary>
        /// Returns TRUE if the password has at least one special character
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool HasSpecialChar(string password)
        {
            return password.IndexOfAny("!@#$%^&*?_~-£().,".ToCharArray()) != -1;
        }


        /// <summary>
        /// Returns TRUE if the password has at least one digit
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool HasDigit(string password)
        {
            return password.Any(c => char.IsDigit(c));
        }

        /// <summary>
        /// Returns TRUE if the password length meets min length criteria
        /// </summary>
        /// <param name="password"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        private bool HasMinimumLength(string password, int minLength)
        {
            return password.Length >= minLength;
        }

        /// <summary>
        /// Returns TRUE if the password length doesn't exceed maximum lenght criteria
        /// </summary>
        /// <param name="password"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private bool IsBelowMaximumLength(string password, int maxLength)
        {
            return password.Length <= maxLength;
        }
    }
}
