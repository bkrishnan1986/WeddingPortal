using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceAnswer;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceQuestion;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Vendorquestionanswer;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IServiceQuestionService
    {
        Task<APIResponse> DeleteServiceAnswer(int questionId, ServiceAnswerDetails request);
        Task<APIResponse> UpdateServiceAnswer(int questionId, ServiceAnswerDetails request);
        Task<APIResponse> CreateServiceAnswer(ServiceAnswerRequest request);
        Task<APIResponse> DeleteServiceQuestion(int questionId);
        Task<APIResponse> UpdateServiceQuestion(int questionId, UpdateServiceQuestionRequest request);
        Task<APIResponse> CreateServiceQuestion(CreateServiceQuestionRequest request);
        Task<APIResponse> GetAllServiceAnswerByServiceQuestion(int serviceQuestionId);
        Task<APIResponse> GetAllServiceQuestionsByServiceType(ServiceQuestionParameters serviceQuestionParameters);
        Task<APIResponse> GetServiceQuestionsById(ServiceQuestionServiceTypeParameters serviceQuestionServiceTypeParameters);
        Task<APIResponse> GetServiceAnswersById(int serviceQuestionId, string Id, int serviceAnswerId);
        Task<APIResponse> GetAllVendorQuestionAnswersById(string Id, bool IsForVendor);
        Task<APIResponse> CreateVendorQuestionAnswer(CreateVendorQuestionAnswerRequest request);
        Task<APIResponse> UpdateVendorQuestionAnswer(string vendorleadId, UpdateVendorQusetionAnswerDetailsRequest request);
    }
}
