﻿using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiCode;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.AuditLog
{
    /// <summary>
    /// Service interface for post related operations
    /// </summary>
    public interface IMulticodeService
    {
        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="multicodeParameter">The Multicode parameters.</param>
        /// <returns></returns>
        Task<APIResponse> GetAllMultiCodes(MulticodeParameter multicodeParameter);

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> GetMultiCode(MulticodeIdDetails details);

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> CreateMultiCode(CreateMulticodeAuditLogRequest request);

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<APIResponse> UpdateMultiCode(MulticodeIdDetails details, UpdateMulticodeAuditLogRequest request);

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        Task<APIResponse> DeleteMultiCode(MulticodeIdDetails details);
    }
}
