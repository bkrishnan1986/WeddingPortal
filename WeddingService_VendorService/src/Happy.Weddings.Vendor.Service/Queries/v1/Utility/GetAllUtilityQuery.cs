using Happy.Weddings.Vendor.Core.DTO.Requests.Utility;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Utility
{

    /// <summary>
    /// Query for getting Assets
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllUtilityQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Asset parameters.
        /// </summary>
        public SubscriptionUtilityParameters SubscriptionUtilityParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAssetsQuery"/> class.
        /// </summary>
        /// <param name="offersParameter">The Benefits parameters.</param>
        public GetAllUtilityQuery(SubscriptionUtilityParameters subscriptionUtilityParameters)
        {
            SubscriptionUtilityParameters = subscriptionUtilityParameters;
        }
    }
}