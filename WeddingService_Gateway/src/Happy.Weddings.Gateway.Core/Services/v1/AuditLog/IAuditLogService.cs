using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.AuditLog
{
    public interface IAuditLogService
    {
        /// <summary>
        /// Gets the AuditLog.
        /// </summary>
        /// <param name="auditLogParameters">The AuditLog Parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllAuditLogs(AuditLogParameters auditLogParameters);

        /// <summary>
        /// Gets the AuditLog.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetAuditLog(AuditLogIdDetails details);

        /// <summary>
        /// Creates the AuditLog.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateAuditLog(CreateAuditLogRequest request);

        /// <summary>
        /// Updates the AuditLog.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateAuditLog(AuditLogIdDetails details, UpdateAuditLogRequest request);

        /// <summary>
        /// Deletes the AuditLog.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteAuditLog(AuditLogIdDetails details);
    }
}
