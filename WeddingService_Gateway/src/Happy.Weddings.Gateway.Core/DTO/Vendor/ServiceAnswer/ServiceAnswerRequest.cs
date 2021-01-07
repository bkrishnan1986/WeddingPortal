using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceAnswer
{
    public class ServiceAnswerRequest
    {
        public IEnumerable<CreateServiceAnswerRequest> ServiceAnswers { get; set; }
    }
}
