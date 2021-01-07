using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ProfilePicture
{
    public class GetCategoryDetailsVendorIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event parameters.
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCategoryDetailsVendorIdQuery"/> class.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        public GetCategoryDetailsVendorIdQuery(string vendorId)
        {
            VendorId = vendorId;
        }
    }
}
