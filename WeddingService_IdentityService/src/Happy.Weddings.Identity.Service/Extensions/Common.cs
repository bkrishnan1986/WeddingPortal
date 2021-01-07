#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  14-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | Common extensions class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;

#endregion

namespace Happy.Weddings.Identity.Service.Extensions
{
    public static class Common
    {
        /// <summary>
        /// Method for convert binary to decimal.
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public static int ToDecimal(this string binary)
        {
            if (!Int32.TryParse(binary, out int num))
            {
                throw new Exception("Input value is not a valid binary number");
            }

            int decVal = 0, baseVal = 1, rem;
            while (num > 0)
            {
                rem = num % 10;
                decVal += rem * baseVal;
                num /= 10;
                baseVal *= 2;
            }

            return decVal;
        }

        /// <summary>
        /// Method for convert decimal to binary.
        /// </summary>
        /// <param name="decimalVal"></param>
        /// <returns></returns>
        public static string ToBinary(this string decimalVal)
        {
            if (!Int32.TryParse(decimalVal, out int decimalNumber))
            {
                throw new Exception("Input value is not a valid decimal number");
            }

            int remainder;
            string result = string.Empty;
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
            }

            return result.PadLeft(6, '0');
        }

        public static string EncodeTo64(this string toEncode)
        {
            byte[] toEncodeAsBytes= System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue= System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        public static string DecodeFrom64(this string encodedData)
        {
            byte[] encodedDataAsBytes= System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.ASCIIEncoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
