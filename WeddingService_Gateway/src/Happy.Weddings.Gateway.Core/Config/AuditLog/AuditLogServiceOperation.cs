using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Config.AuditLog
{
    public class AuditLogServiceOperation
    {
        #region Base

        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/auditLog";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "AuditLogService";

        /// <summary>
        /// The get AuditLog cache name
        /// </summary>
        public static string GetAuditLogCacheName = "GetAuditLogCache()";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";

        #endregion

        #region MultiCode

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiCodes() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string GetMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiCode() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string UpdateMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string DeleteMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        #endregion

        #region MultiDetail

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multicodeId">The Multicode identifier.</param>
        /// <returns></returns>
        public static string GetMultiDetailsById(string multicodeId) => $"{baseUrl}/multidetails/{multicodeId}";

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string UpdateMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string DeleteMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        #endregion

        #region AuditLogs

        /// <summary>
        /// Gets the AuditLogs.
        /// </summary>
        /// <returns></returns>
        public static string GetAllAuditLogs() => $"{baseUrl}/auditlogs";

        /// <summary>
        /// Gets the AuditLogs.
        /// </summary>
        /// <param name="auditLogId">The AuditLogs identifier.</param>
        /// <returns></returns>
        public static string GetAuditLog(int auditLogId) => $"{baseUrl}/auditlogs/{auditLogId}";

        /// <summary>
        /// Creates the AuditLogs.
        /// </summary>
        /// <returns></returns>
        public static string CreateAuditLog() => $"{baseUrl}/auditlogs";

        /// <summary>
        /// Updates the AuditLogs.
        /// </summary>
        /// <param name="auditLogId">The AuditLogs identifier.</param>
        /// <returns></returns>
        public static string UpdateAuditLog(int auditLogId) => $"{baseUrl}/auditlogs/{auditLogId}";

        /// <summary>
        /// Deletes the AuditLogs.
        /// </summary>
        /// <param name="auditLogId">The AuditLogs identifier.</param>
        /// <returns></returns>
        public static string DeleteAuditLog(int auditLogId) => $"{baseUrl}/auditlogs/{auditLogId}";

        #endregion
    }
}
