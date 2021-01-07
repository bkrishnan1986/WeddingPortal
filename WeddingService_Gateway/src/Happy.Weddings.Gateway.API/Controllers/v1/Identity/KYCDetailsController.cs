using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.KYCData;
using Happy.Weddings.Gateway.Core.Services.v1.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Identity
{
    /// <summary>
    /// KYCDetailsController
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/profiles")]
    [ApiController]
    public class KYCDetailsController : Controller
    {
        /// <summary>
        /// The kyc detail service
        /// </summary>
        private readonly IKYCDetailsService kycDetailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="KYCDetailsController"/> class.
        /// </summary>
        /// <param name="kycDetailService">The kyc detail service.</param>
        public KYCDetailsController(
            IKYCDetailsService kycDetailService)
        {
            this.kycDetailService = kycDetailService;
        }

        /// <summary>
        /// Creates the kyc data.
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{profileId}/kyc")]
        public async Task<IActionResult> CreateKYCData(int profileId, [FromForm] KYCFormData data)
        {
            var kycDataModel = JsonConvert.DeserializeObject<List<KYCCreateData>>(data.KYCData);
            foreach (var kyc in kycDataModel)
            {
                if (kyc.GSTDetailString != null)
                {
                    kyc.Gstdocument = data.GstDoc;
                }
                else
                {
                    if (kyc.Dob != null && kyc.FatherName != null)
                    {
                        kyc.Kycdoc = data.KycDoc;
                    }
                    else
                    {
                        kyc.Proofdocument = data.ProofDoc;
                    }
                }

            }
            CreateKYCDataRequest request = new CreateKYCDataRequest()
            {
                KYCData = kycDataModel
            };
            var result = await kycDetailService.CreateKYCData(profileId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the kyc data.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [Route("{profileId}/kyc")]
        [HttpPut]
        public async Task<IActionResult> UpdateKYCData(int profileId, [FromForm] KYCFormData data)
        {
            var kycDataModel = JsonConvert.DeserializeObject<List<KYCUpdateData>>(data.KYCData);
            foreach (var kyc in kycDataModel)
            {
                if (kyc.GSTDetailString != null)
                {
                    kyc.Gstdocument = data.GstDoc;
                }
                else
                {
                    if (kyc.Dob != null && kyc.FatherName != null)
                    {
                        kyc.Kycdoc = data.KycDoc;
                    }
                    else
                    {
                        kyc.Proofdocument = data.ProofDoc;
                    }
                }

            }
            UpdateKYCDataRequest request = new UpdateKYCDataRequest()
            {
                UpdateData = kycDataModel
            };
            var result = await kycDetailService.UpdateKYCData(profileId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the kyc portion.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}/kyc")]
        [HttpPatch]
        public async Task<IActionResult> UpdateKYCPortion(int profileId, [FromBody] UpdateKYCPortionRequest request)
        {
            var result = await kycDetailService.UpdateKYCPortion(profileId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        [Route("{profileId}/kyc")]
        [HttpGet]
        public async Task<IActionResult> GetKYCDatas(int profileId)
        {
            var result = await kycDetailService.GetKYCDatas(profileId);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
