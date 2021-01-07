using System.ComponentModel;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceAnswer
{
    public class GetServiceAnswersByIdQuery : IRequest<APIResponse>
    {
       public int serviceQuestionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetServiceAnswersByIdQuery"/> class.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        public GetServiceAnswersByIdQuery(int serviceQuestionId)
        {
            this.serviceQuestionId = serviceQuestionId;
        }
    }
}
