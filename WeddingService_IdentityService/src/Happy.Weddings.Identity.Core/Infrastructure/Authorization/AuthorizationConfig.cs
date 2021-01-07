﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Happy.Weddings.Identity.Core.Infrastructure.Authorization
{
    /// <summary>
    /// Contains the details for configuring authorization
    /// </summary>
    public class AuthorizationConfig
    {
        /// <summary>
        /// Gets or sets the domain
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets the audience
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the expiry of token in minutes
        /// </summary>
        public int TokenExpiryInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the session in minutes.
        /// </summary>
        /// <value>
        public int SessionInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the key file
        /// </summary>
        public string KeyFilePath { get; set; }

        /// <summary>
        /// Gets or sets the certificate path.
        /// </summary>
        public string CertificatePath { get; set; }

        /// <summary>
        /// Gets or sets the Key
        /// </summary>
        public SecureString SigningPassword { get; private set; }

        /// <summary>
        /// Sets the key file password.
        /// </summary>
        /// <param name="input">The input.</param>
        public void SetKeyFilePassword(string input)
        {
            SigningPassword = new SecureString();
            input.ToCharArray().ToList().ForEach((q) => SigningPassword.AppendChar(q));
        }

        /// <summary>
        /// Converts to unsecure string.
        /// </summary>
        /// <param name="securePassword">The secure password.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">securePassword</exception>
        public string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
