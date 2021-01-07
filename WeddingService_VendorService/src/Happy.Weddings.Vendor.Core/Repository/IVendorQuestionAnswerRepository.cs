using Happy.Weddings.Vendor.Core.DTO.Responses.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IVendorQuestionAnswerRepository : IRepositoryBase<Vendorquestionanswers>
    {
        /// <summary>
        /// Gets  vendorquestionanswers
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<List<VendorQuestionAnswerResponseDetails>> GetAllVendorQuestionAnswersById(string Id, bool IsForVendor);

        /// <summary>
        /// Gets the vendorquestionanswer by identifier.
        /// </summary>
        /// <param name="VendorleadId"></param>
        /// <returns></returns>
        Task<Vendorquestionanswers> GetVendorQuestionAnswer(string VendorleadId);

        /// <summary>
        /// Gets the vendorquestionanswers by identifier.
        /// </summary>
        /// <param name="VendorleadId"></param>
        /// <param name="questionId"></param>
        /// <returns></returns>
        Task<List<Vendorquestionanswers>> GetVendorQuestionAnswers(string VendorleadId, int questionId);

        /// <summary>
        /// Creates the vendorquestionanswers
        /// </summary>
        /// <param name="vendorquestionanswers"></param>
        void CreateVendorQuestionAnswer(List<Vendorquestionanswers> vendorquestionanswers);

        /// <summary>
        /// Updates the vendorquestionanswers
        /// </summary>
        /// <param name="vendorquestionanswers"></param>
        void UpdateVendorQuestionAnswer(List<Vendorquestionanswers> vendorquestionanswers);
    }
}
