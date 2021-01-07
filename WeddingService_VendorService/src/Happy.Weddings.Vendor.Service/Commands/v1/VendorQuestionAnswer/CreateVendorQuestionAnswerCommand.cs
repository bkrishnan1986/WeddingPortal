using Happy.Weddings.Vendor.Core.DTO.Requests.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.VendorQuestionAnswer
{
    public class CreateVendorQuestionAnswerCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service answer request.
        /// </summary>
        /// <value>
        /// The service answer request.
        /// </value>
        public VendorQuestionAnswerRequest VendorQuestionAnswer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceAnswerCommand"/> class.
        /// </summary>
        /// <param name="serviceanswerrequest">The serviceanswerrequest.</param>
        public CreateVendorQuestionAnswerCommand(VendorQuestionAnswerRequest vendorquestionanswerrequest)
        {
            VendorQuestionAnswer = vendorquestionanswerrequest;
        }
    }
}
