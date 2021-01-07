using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Identity.Service.Helpers
{
    public static class RandomPasswordGenerator
    {
        /// <summary>
        /// The lower case
        /// </summary>
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";

        /// <summary>
        /// The upper caes
        /// </summary>
        const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// The numbers
        /// </summary>
        const string NUMBERS = "123456789";

        /// <summary>
        /// The specials
        /// </summary>
        const string SPECIALS = @"!@£$%^&*()#€";

        /// <summary>
        /// Generates the password.
        /// </summary>
        /// <param name="useLowercase">if set to <c>true</c> [use lowercase].</param>
        /// <param name="useUppercase">if set to <c>true</c> [use uppercase].</param>
        /// <param name="useNumbers">if set to <c>true</c> [use numbers].</param>
        /// <param name="useSpecial">if set to <c>true</c> [use special].</param>
        /// <param name="passwordSize">Size of the password.</param>
        /// <returns></returns>
        public static string GeneratePassword(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int passwordSize)
        {
            char[] _password = new char[passwordSize];
            string charSet = ""; // Initialise to blank
            System.Random _random = new Random();
            int counter;

            // Build up the character set to choose from
            if (useLowercase) charSet += LOWER_CASE;

            if (useUppercase) charSet += UPPER_CAES;

            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < passwordSize; counter++)
            {
                _password[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return String.Join(null, _password);
        }
    }
}
