using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Utility
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteUtilityCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the utility identifier.
        /// </summary>
        /// <value>
        /// The utility identifier.
        /// </value>
        public int UtilityId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUtilityCommand"/> class.
        /// </summary>
        /// <param name="utilityId">The utility identifier.</param>
        public DeleteUtilityCommand(int utilityId)
        {
            UtilityId = utilityId;
        }
    }
}