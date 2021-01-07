using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog;
using Happy.Weddings.Gateway.Core.Services.v1.AuditLog;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.AuditLog
{
    /// <summary>
    /// AuditLog operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("auditlogs")]
    [ApiController]
    public class AuditLogController : ControllerBase
    {
        /// <summary>
        /// The AuditLog service
        /// </summary>
        private readonly IAuditLogService auditLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogController"/> class.
        /// </summary>
        /// <param name="auditLogService">The AuditLog service.</param>
        public AuditLogController(
            IAuditLogService auditLogService)
        {
            this.auditLogService = auditLogService;
        }

        /// <summary>
        /// Gets the AuditLog.
        /// </summary>
        /// <param name="auditLogParameters">The AuditLog parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllAuditLogs([FromQuery] AuditLogParameters auditLogParameters)
        {
            var result = await auditLogService.GetAllAuditLogs(auditLogParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the AuditLog.
        /// </summary>
        /// <param name="auditLogId">The AuditLog identifier.</param>
        /// <returns></returns>
        [Route("{auditLogId}")]
        [HttpGet]
        public async Task<IActionResult> GetAuditLog(int auditLogId)
        {
            var result = await auditLogService.GetAuditLog(new AuditLogIdDetails(auditLogId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the AuditLog.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAuditLog([FromBody] CreateAuditLogRequest request)
        {
            var result = await auditLogService.CreateAuditLog(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the AuditLog.
        /// </summary>
        /// <param name="auditLogId">The AuditLog identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{auditLogId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateAuditLog(int auditLogId, [FromBody] UpdateAuditLogRequest request)
        {
            var result = await auditLogService.UpdateAuditLog(new AuditLogIdDetails(auditLogId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the AuditLog.
        /// </summary>
        /// <param name="auditLogId">The AuditLog identifier.</param>
        /// <returns></returns>
        [Route("{auditLogId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAuditLog(int auditLogId)
        {
            var result = await auditLogService.DeleteAuditLog(new AuditLogIdDetails(auditLogId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
