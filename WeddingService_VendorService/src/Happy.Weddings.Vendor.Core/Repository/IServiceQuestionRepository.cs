#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 |  IServiceQuestionRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header    

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceQuestion;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IServiceQuestionRepository : IRepositoryBase<Servicequestion>
    {
        /// <summary>
        /// Gets all service question by service type identifier.
        /// </summary>
        /// <returns></returns>
       // public Task<PagedList<Domain.Entity>> GetAllServiceQuestionByServiceTypeId(ServiceQuestionParameters serviceQuestionParameters);

        public Task<IEnumerable<ServiceQuestionDetailsResponse>> GetAllServiceQuestionByServiceTypeId(ServiceQuestionParameters serviceQuestionParameters);
        
        /// <summary>
        /// Gets all service question by service type identifier.
        /// </summary>
        /// <returns></returns>
        public Task<List<Servicequestion>> GetServiceQuestionsById(ServiceQuestionServiceTypeParameters serviceQuestionServiceTypeParameters);

        /// <summary>
        /// Gets the service question by identifier.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <returns></returns>
        public Task<Servicequestion> GetServiceQuestionById(int questionId);

        /// <summary>
        /// Gets all service question by service question identifier.
        /// </summary>
        /// <param name="serviceQuestionId">The service question identifier.</param>
        /// <returns></returns>
        public Task<List<ServiceQuestionDetailsResponse>> GetServiceQuestionByServiceQuestionId(int serviceQuestionId);

        /// <summary>
        /// Creates the service questions.
        /// </summary>
        /// <param name="servicequestion">The servicequestion.</param>
        void CreateServiceQuestion(Servicequestion servicequestion);

        /// <summary>
        /// Updates the service question.
        /// </summary>
        /// <param name="servicequestion">The servicequestion.</param>
        void UpdateServiceQuestion(Servicequestion servicequestion);

        /// <summary>
        /// Deletes the event.
        /// </summary>
        /// <param name="servicequestion">The servicequestion.</param>
        void DeleteEvent(Servicequestion servicequestion);
    }
}
