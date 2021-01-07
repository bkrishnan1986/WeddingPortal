using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceAnswer;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.ServiceQuestion
{
    public class ServiceQuestionDetailsResponse : ServiceQuestionResponse
    {
        public List<ServiceAnswerResponse> ServiceAnswer { get; set; }  
    }
}
