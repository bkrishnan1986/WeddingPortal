#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 | IServiceAnswerRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header    

using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceAnswer;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IServiceAnswerRepository : IRepositoryBase<Serviceanswer>
    {
        /// <summary>
        /// Gets the service by identifier.
        /// </summary>
        /// <param name="serviceQuestionId">The service question identifier.</param>
        /// <returns></returns>
        Task<List<Serviceanswer>> GetServiceAnswerByQuestionId(int serviceQuestionId);
        /// <summary>
        /// Gets the service answers by identifier.
        /// </summary>
        /// <param name="serviceQuestionId"></param>
        /// <param name="Id"></param>
        /// <param name="serviceAnswerId"></param>
        /// <returns></returns>
        Task<List<ServiceAnswerResponse>> GetServiceAnswersById(int serviceAnswerId);
        /// <summary>
        /// Gets the service answer by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<Serviceanswer> GetServiceAnswerById(int Id);      
        /// <summary>
        /// Creates the service answer.
        /// </summary>
        /// <param name="serviceanswer">The serviceanswer.</param>
        void CreateServiceAnswer(List<Serviceanswer> serviceanswer);
        /// <summary>
        /// Creates the service answer.
        /// </summary>
        /// <param name="serviceanswer">The serviceanswer.</param>
        void UpdateServiceAnswerRange(List<Serviceanswer> serviceanswer);
        /// <summary>
        /// Updates the service answer.
        /// </summary>
        /// <param name="serviceanswer">The serviceanswer.</param>
        void UpdateServiceAnswer(Serviceanswer serviceanswer);
    }
}
