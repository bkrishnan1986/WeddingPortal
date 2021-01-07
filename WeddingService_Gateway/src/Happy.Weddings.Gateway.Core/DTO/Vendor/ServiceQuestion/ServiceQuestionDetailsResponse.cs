using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceAnswer;
using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceQuestion
{
    public class ServiceQuestionDetailsResponse : ServiceQuestionResponse
    {
        public List<ServiceAnswerResponse> ServiceAnswer { get; set; }
    }
}
