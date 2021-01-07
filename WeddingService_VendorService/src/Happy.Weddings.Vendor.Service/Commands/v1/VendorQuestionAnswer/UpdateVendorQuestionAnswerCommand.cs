using Happy.Weddings.Vendor.Core.DTO.Requests.Vendorquestionanswer;
using Happy.Weddings.Vendor.Core.DTO.Requests.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.VendorQuestionAnswer
{
    public class UpdateVendorQuestionAnswerCommand : IRequest<APIResponse>
    {
        public string VendorleadId;

        public UpdateVendorQusetionAnswerDetailsRequest UpdateVendorQusetionAnswerDetailsRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateVendorQuestionAnswerCommand"/> class.
        /// </summary>
        /// <param name="updateVendorQuestionAsnwerRequest">The service answer details.</param>
        public UpdateVendorQuestionAnswerCommand(string vendorleadId, UpdateVendorQusetionAnswerDetailsRequest updateVendorQuestionAsnwerRequest)
        {
            VendorleadId = vendorleadId;
            UpdateVendorQusetionAnswerDetailsRequest = updateVendorQuestionAsnwerRequest;
        }
    }
}
