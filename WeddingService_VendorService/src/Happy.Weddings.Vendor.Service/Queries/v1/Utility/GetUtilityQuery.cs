using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Utility
{

    /// <summary>
    /// GetUtilityQuery
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class GetUtilityQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Benefits identifier.
        /// </summary>
        public int UtilityId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUtilityQuery"/> class.
        /// </summary>
        /// <param name="utilityId">The utility identifier.</param>
        public GetUtilityQuery(int utilityId)
        {
            UtilityId = utilityId;
        }
    }
}