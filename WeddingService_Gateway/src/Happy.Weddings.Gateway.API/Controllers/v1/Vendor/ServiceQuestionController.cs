using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceAnswer;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceQuestion;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Vendorquestionanswer;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Vendor Questions ans Answer operations handled by this controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("servicequestion")]
    [ApiController]
    public class ServiceQuestionController : ControllerBase
    {
        /// <summary>
        /// The service question service
        /// </summary>
        private readonly IServiceQuestionService serviceQuestionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionController"/> class.
        /// </summary>
        /// <param name="serviceQuestionService">The service question service.</param>
        public ServiceQuestionController(
            IServiceQuestionService serviceQuestionService)
        {
            this.serviceQuestionService = serviceQuestionService;
        }

        /// <summary>
        /// Gets the type of the service question by service.
        /// </summary>
        /// <param name="serviceQuestionParameters">The service type identifier.</param>
        /// <returns></returns>
        [Route("servicequestions")]
        [HttpGet]
        public async Task<IActionResult> GetAllServiceQuestionsByServiceType([FromQuery] ServiceQuestionParameters serviceQuestionParameters)
        {
            var result = await serviceQuestionService.GetAllServiceQuestionsByServiceType(serviceQuestionParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets all service answer by service question.
        /// </summary>
        /// <param name="serviceQuestionId">The service question identifier.</param>
        /// <returns></returns>
        [Route("getallserviceanswers")]
        [HttpGet]
        public async Task<IActionResult> GetAllServiceAnswerByServiceQuestion(int serviceQuestionId)
        {
            var result = await serviceQuestionService.GetAllServiceAnswerByServiceQuestion(serviceQuestionId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the service question 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceQuestion([FromBody] CreateServiceQuestionRequest request)
        {
            var result = await serviceQuestionService.CreateServiceQuestion(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the service question
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("{questionId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateServiceQuestion(int questionId, [FromBody] UpdateServiceQuestionRequest request)
        {
            var result = await serviceQuestionService.UpdateServiceQuestion(questionId,request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the service question.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <returns></returns>
        [Route("{questionId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceQuestion(int questionId)
        {
            var result = await serviceQuestionService.DeleteServiceQuestion(questionId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the service answer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("createanswers")]
        [HttpPost]
        public async Task<IActionResult> CreateServiceAnswer([FromBody] ServiceAnswerRequest request)
        {
            var result = await serviceQuestionService.CreateServiceAnswer(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the service answer.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{questionId}/updateanswers")]
        [HttpPut]
        public async Task<IActionResult> UpdateServiceAnswer(int questionId, [FromBody] ServiceAnswerDetails request)
        {
            var result = await serviceQuestionService.UpdateServiceAnswer(questionId,request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the service answer.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("{questionId}/deleteserviceanswer")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceAnswer(int questionId, [FromBody] ServiceAnswerDetails request)
        {
            var result = await serviceQuestionService.DeleteServiceAnswer(questionId,request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the type of the service question by service type and id.
        /// </summary>
        /// <param name="serviceQuestionServiceTypeParameters">The service type identifier.</param>
        /// <returns></returns>
        [Route("servicequestion")]
        [HttpGet]
        public async Task<IActionResult> GetServiceQuestionsById([FromQuery] ServiceQuestionServiceTypeParameters serviceQuestionServiceTypeParameters)
        {
            var result = await serviceQuestionService.GetServiceQuestionsById(serviceQuestionServiceTypeParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the service answer by service type and id.
        /// </summary>
        /// <param name="serviceQuestionId">The service type identifier.</param>
        /// <param name="Id">The service type identifier.</param>
        /// <param name="serviceAnswerId">The service type identifier.</param>
        /// <returns></returns>
        [Route("serviceanswer")]
        [HttpGet]
        public async Task<IActionResult> GetServiceAnswersById(int serviceQuestionId, string Id, int serviceAnswerId)
        {
            var result = await serviceQuestionService.GetServiceAnswersById(serviceQuestionId,Id,serviceAnswerId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets all service answer by Vendor.
        /// </summary>
        /// <param name="Id">The Vendor identifier.</param>
        /// <param name="IsForVendor"></param>
        /// <returns></returns>
        [Route("{Id}/vendorquestionanswers")]
        [HttpGet]
        public async Task<IActionResult> GetAllVendorQuestionAnswersById(string Id, bool IsForVendor)
        {
            var result = await serviceQuestionService.GetAllVendorQuestionAnswersById(Id, IsForVendor);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create Vendor Question Answer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("createvendorquestioanswers")]
        [HttpPost]
        public async Task<IActionResult> CreateVendorQuestionAnswer([FromBody] CreateVendorQuestionAnswerRequest request)
        {
            var result = await serviceQuestionService.CreateVendorQuestionAnswer(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the vendor answer.
        /// </summary>
        /// <param name="vendorleadId">The vendor identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{vendorleadId}/updateVendorQuestionAnswer")]
        [HttpPut]
        public async Task<IActionResult> UpdateVendorQuestionAnswer(string vendorleadId, [FromBody] UpdateVendorQusetionAnswerDetailsRequest request)
        {
            var result = await serviceQuestionService.UpdateVendorQuestionAnswer(vendorleadId,request);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
