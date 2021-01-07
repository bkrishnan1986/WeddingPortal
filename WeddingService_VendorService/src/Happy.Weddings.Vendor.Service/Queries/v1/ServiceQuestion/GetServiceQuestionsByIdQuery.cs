using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceQuestion
{
    public class GetServiceQuestionsByIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service type identifier.
        /// </summary>
        /// <value>
        /// The service type identifier.
        /// </value>
        public ServiceQuestionServiceTypeParameters serviceQuestionServiceTypeParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllServiceQuestionByServiceTypeQuery"/> class.
        /// </summary>
        /// <param name="serviceTypeId">The service type identifier.</param>
        public GetServiceQuestionsByIdQuery(ServiceQuestionServiceTypeParameters serviceQuestionServiceTypeParameters)
        {
            this.serviceQuestionServiceTypeParameters = serviceQuestionServiceTypeParameters;
        }
    }
}
