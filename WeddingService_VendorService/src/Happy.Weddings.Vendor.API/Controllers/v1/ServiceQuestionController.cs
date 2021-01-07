#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 | ServiceQuestionController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Requests.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceAnswer;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceQuestion;
using Happy.Weddings.Vendor.Service.Commands.v1.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceAnswer;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceQuestion;
using Happy.Weddings.Vendor.Service.Queries.v1.VendorQuestionAnswer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.API.Controllers.v1
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
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ServiceQuestionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets all the type of the service question by service.
        /// </summary>
        /// <param name="serviceQuestionParameters">The service type identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllServiceQuestionsByServiceType([FromQuery] ServiceQuestionParameters serviceQuestionParameters)
        {
            var getServiceQuestionByServiceTypeQuery = new GetAllServiceQuestionByServiceTypeQuery(serviceQuestionParameters);
            var result = await mediator.Send(getServiceQuestionByServiceTypeQuery);  
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
            var getServiceQuestionByIdServiceTypeQuery = new GetServiceQuestionsByIdQuery(serviceQuestionServiceTypeParameters);
            var result = await mediator.Send(getServiceQuestionByIdServiceTypeQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets all service answer by service question.
        /// </summary>
        /// <param name="serviceQuestionId">The service question identifier.</param>
        /// <returns></returns>
        [Route("serviceanswers")]
        [HttpGet]
        public async Task<IActionResult> GetAllServiceAnswerByServiceQuestion(int serviceQuestionId)
        {
            var getServiceAnswerByServiceQuestionQuery = new GetAllServiceAnswerByServiceQuestionQuery(serviceQuestionId);
            var result = await mediator.Send(getServiceAnswerByServiceQuestionQuery);

         /*   if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }   */  

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the service answer by service type and id.
        /// </summary>
        /// <param name="serviceAnswerId"></param>
        /// <returns></returns>
       /* [Route("serviceanswer")]
        [HttpGet]
        public async Task<IActionResult> GetServiceAnswersById(int serviceAnswerId)
        {
            var getServiceAnswersByIdServiceTypeQuery = new GetServiceAnswersByIdQuery(serviceAnswerId);
            var result = await mediator.Send(getServiceAnswersByIdServiceTypeQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }   */

        /// <summary>
        /// Create the service question 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceQuestion([FromBody] CreateServiceQuestionRequest request)
        {
            var createServiceQuestionCommand = new CreateServiceQuestionCommand(request);
            var result = await mediator.Send(createServiceQuestionCommand);
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
            var updateServiceQuestionCommand = new UpdateServiceQuestionCommand(questionId, request);
            var result = await mediator.Send(updateServiceQuestionCommand);
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
            var deleteServiceQuestionCommand = new DeleteServiceQuestionCommand(questionId);
            var result = await mediator.Send(deleteServiceQuestionCommand);
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
            var createServiceAnswerCommand = new CreateServiceAnswerCommand(request);
            var result = await mediator.Send(createServiceAnswerCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the service answer.
        /// </summary>
        /// <param name="answerId">The answerId identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{answerId}/updateanswers")]
        [HttpPut]
        public async Task<IActionResult> UpdateServiceAnswer(int answerId, [FromBody] ServiceAnswerDetails request)
        {
            var updateServiceAnswerCommand = new UpdateAnswerCommand(answerId, request);

            var result = await mediator.Send(updateServiceAnswerCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the service answer.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <returns></returns>
        [Route("{questionId}/deleteserviceanswer")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceAnswer(int questionId)
        {
            var deleteServiceAnswerCommand = new DeleteServiceAnswerCommand(questionId);
            var result = await mediator.Send(deleteServiceAnswerCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets all service answer by Vendor.
        /// </summary>
        /// <param name="Id">The Vendor identifier.</param>
        /// <param name="IsForVendor"></param>
        /// <returns></returns>
        [Route("{Id}/{IsForVendor}/vendorquestionanswers")]
        [HttpGet]
        public async Task<IActionResult> GetAllVendorQuestionAnswersById(string Id, bool IsForVendor)
        {
            var getVendorQuestonAnswerQuery = new GetAllVendorQuestionAnswersByIdQuery(Id, IsForVendor);
            var result = await mediator.Send(getVendorQuestonAnswerQuery);

           /* if (result.Code == HttpStatusCode.OK)
            {
                   Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }         */

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the vendor answer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("createvendorquestioanswers")]
        [HttpPost]
        public async Task<IActionResult> CreateVendorQuestionAnswer([FromBody] VendorQuestionAnswerRequest request)
        {
            var createVendorQuestionAnswerCommand = new CreateVendorQuestionAnswerCommand(request);
            var result = await mediator.Send(createVendorQuestionAnswerCommand);
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
            var updateVendorQuestionAnswerCommand = new UpdateVendorQuestionAnswerCommand(vendorleadId, request);

            var result = await mediator.Send(updateVendorQuestionAnswerCommand);

            return StatusCode((int)result.Code, result.Value);
        }

    }
}