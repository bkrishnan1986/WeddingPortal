using System;

namespace Happy.Weddings.Gateway.Core.Config.Identity
{
    public class IdentityServiceOperation
    {
        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/identity-management";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "IdentityService";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public static string GetUsers() => $"{baseUrl}/profiles";

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public static string GetUser(int profileId) => $"{baseUrl}/profiles/{profileId}";

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public static string CreateUser() => $"{baseUrl}/profiles";

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public static string UpdateUser(int profileId) => $"{baseUrl}/profiles/{profileId}";

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public static string DeleteUser(int profileId) => $"{baseUrl}/profiles/{profileId}";

        /// <summary>
        /// Gets the kyc datas.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public static string GetKYCDatas(int profileId) => $"{baseUrl}/profiles/{profileId}/kyc";

        /// <summary>
        /// Creates the kyc data.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public static string CreateKYCData(int profileId) => $"{baseUrl}/profiles/{profileId}/kyc";

        /// <summary>
        /// Updates the kyc data.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public static string UpdateKYCData(int profileId) => $"{baseUrl}/profiles/{profileId}/kyc";

        /// <summary>
        /// Updates the kyc portion.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public static string UpdateKYCPortion(int profileId) => $"{baseUrl}/profiles/{profileId}/kyc";

        /// <summary>
        /// Creates the multi details.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Creates the multi code.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiCode() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Deletes the multi code.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <returns></returns>
        public static string DeleteMultiCode(string multicodeId) => $"{baseUrl}/multicodes/{multicodeId}";

        /// <summary>
        /// Gets the multi code by identifier.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <returns></returns>
        public static string GetMultiCodeById(string multicodeId) => $"{baseUrl}/multicodes/{multicodeId}";

        /// <summary>
        /// Updates the multi code.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <returns></returns>
        public static string UpdateMultiCode(string multicodeId) => $"{baseUrl}/multicodes/{multicodeId}";

        /// <summary>
        /// Gets the multi details.
        /// </summary>
        /// <returns></returns>
        public static string GetMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Deletes the multi details.
        /// </summary>
        /// <param name="multidetailId">The multidetail identifier.</param>
        /// <returns></returns>
        public static string DeleteMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        /// <summary>
        /// Gets the multi details by identifier.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <returns></returns>
        public static string GetMultiDetailsById(string multicodeId) => $"{baseUrl}/multidetails/{multicodeId}";

        /// <summary>
        /// Updates the multi details.
        /// </summary>
        /// <param name="multidetailId">The multidetail identifier.</param>
        /// <returns></returns>
        public static string UpdateMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        /// <summary>
        /// Gets the multi codes.
        /// </summary>
        /// <returns></returns>
        public static string GetMultiCodes() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <returns></returns>
        public static string GetUserId() => $"{baseUrl}/profiles/userId";

        /// <summary>
        /// Sends the otp.
        /// </summary>
        /// <returns></returns>
        public static string SendOtp(int profileId) => $"{baseUrl}/profiles/{profileId}/otpSend";

        /// <summary>
        /// Verifies the otp.
        /// </summary>
        /// <returns></returns>
        public static string VerifyOtp(int profileId) => $"{baseUrl}/profiles/{profileId}/otpVerify";
    }
}
