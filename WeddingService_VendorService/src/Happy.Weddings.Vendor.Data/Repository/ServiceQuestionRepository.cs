#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 |  ServiceQuestionRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceQuestion;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class ServiceQuestionRepository : RepositoryBase<Servicequestion>, IServiceQuestionRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ServiceQuestionResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ServiceQuestionResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceQuestionRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public ServiceQuestionRepository(VendorContext repositoryContext, IMapper mapper, ISortHelper<ServiceQuestionResponse> sortHelper,
                                      IDataShaper<ServiceQuestionResponse> dataShaper) : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all service question by service type identifier.
        /// </summary>
        /// <param name="serviceQuestionParameters"></param>
        /// <returns></returns>
        /* public async Task<PagedList<Entity>> GetAllServiceQuestionByServiceTypeId(ServiceQuestionParameters serviceQuestionParameters)
          {
              var getServiceQuestionParameters = new object[] {
                  new MySqlParameter("@p_Limit", serviceQuestionParameters.PageSize),
                  new MySqlParameter("@p_Offset", (serviceQuestionParameters.PageNumber - 1) * serviceQuestionParameters.PageSize),
                  new MySqlParameter("@p_Value", serviceQuestionParameters.Value),
                  new MySqlParameter("@p_IsForSingleData", false),
                  new MySqlParameter("@p_IsForServiceType", true),
                  new MySqlParameter("@p_VendorLeadId", serviceQuestionParameters.VendorLeadId),
                  new MySqlParameter("@p_IsForVendor", serviceQuestionParameters.IsForVendor),
                  new MySqlParameter("@p_FromDate", serviceQuestionParameters.FromDate),
                  new MySqlParameter("@p_ToDate", serviceQuestionParameters.ToDate)
              };

              var servicequestions = await FindAll("CALL SpSelectSearchServiceQuestion(@p_Limit, @p_Offset, @p_Value, @p_IsForSingleData,@p_IsForServiceType,@p_VendorLeadId,@p_IsForVendor, @p_FromDate, @p_ToDate)", getServiceQuestionParameters).ToListAsync();

              var mappedservicequestions = servicequestions.AsQueryable().ProjectTo<ServiceQuestionResponse>(mapper.ConfigurationProvider);
              var sortedservicequestions = sortHelper.ApplySort(mappedservicequestions, serviceQuestionParameters.OrderBy);
              var shapedservicequestions = dataShaper.ShapeData(sortedservicequestions, serviceQuestionParameters.Fields);

              return await PagedList<Entity>.ToPagedList(shapedservicequestions, serviceQuestionParameters.PageNumber, serviceQuestionParameters.PageSize);
          }   */

        public async Task<IEnumerable<ServiceQuestionDetailsResponse>> GetAllServiceQuestionByServiceTypeId(ServiceQuestionParameters serviceQuestionParameters)
        {
            var serviceQuestions = FindByCondition(servicequestion => servicequestion.Active == Convert.ToInt16(true)).OrderBy(x => x.ServiceType)
                                    .ProjectTo<ServiceQuestionDetailsResponse>(mapper.ConfigurationProvider);
            SearchByVendorLeadId(ref serviceQuestions, serviceQuestionParameters);
            var result = await serviceQuestions.ToListAsync();
            return result;
        }

        private void SearchByVendorLeadId(ref IQueryable<ServiceQuestionDetailsResponse> serviceQuestions, ServiceQuestionParameters serviceQuestionParameters)
        {
            if (serviceQuestionParameters.Value > 0)
            {
                if (serviceQuestionParameters.IsForVendor == true)
                {
                    serviceQuestions = serviceQuestions.Where(x => x.ServiceType.Equals(serviceQuestionParameters.Value) && x.IsForVendor.Equals(Convert.ToInt16(serviceQuestionParameters.IsForVendor))).OrderBy(x => x.ServiceType);
                }
                else
                {
                    serviceQuestions = serviceQuestions.Where(x => x.ServiceType.Equals(serviceQuestionParameters.Value) && x.IsForVendor.Equals(Convert.ToInt16(serviceQuestionParameters.IsForVendor))).OrderBy(x => x.ServiceType);
                }
            }
        }

        public async Task<List<Servicequestion>> GetServiceQuestionsById(ServiceQuestionServiceTypeParameters serviceQuestionServiceTypeParameters)
        {
            var getServiceQuestionParameters = new object[] {
               new MySqlParameter("@limit", serviceQuestionServiceTypeParameters.PageSize),
                new MySqlParameter("@offset", (serviceQuestionServiceTypeParameters.PageNumber - 1) * serviceQuestionServiceTypeParameters.PageSize),
                new MySqlParameter("@IsForVendor", serviceQuestionServiceTypeParameters.IsForVendor),
                new MySqlParameter("@ServiceType", serviceQuestionServiceTypeParameters.ServiceType),
            };

            return await FindAll("CALL SpSelectActiveServiceQuestion(@limit, @offset,@IsForVendor,@ServiceType)", getServiceQuestionParameters).ToListAsync();
        }

        public async Task<List<ServiceQuestionDetailsResponse>> GetServiceQuestionByServiceQuestionId(int serviceQuestionId)
        {
            return await FindByCondition(servicequestion => servicequestion.Id.Equals(serviceQuestionId))
                //.Include(sq => sq.Serviceanswer)
                .ProjectTo<ServiceQuestionDetailsResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Creates the service questions.
        /// </summary>
        /// <param name="servicequestion">The servicequestion.</param>
        public void CreateServiceQuestion(Servicequestion servicequestion)
        {
            Create(servicequestion);
        }

        /// <summary>
        /// Updates the service question.
        /// </summary>
        /// <param name="servicequestion">The servicequestion.</param>
        public void UpdateServiceQuestion(Servicequestion servicequestion)
        {
            Update(servicequestion);
        }

        public async Task<Servicequestion> GetServiceQuestionById(int questionId)
        {
            var getServiceQuestionParameters = new object[] {
                new MySqlParameter("@p_Limit", 0),
                new MySqlParameter("@p_Offset", 0),
                new MySqlParameter("@p_Value", questionId),
                new MySqlParameter("@p_IsForSingleData", true),
                new MySqlParameter("@p_IsForServiceType", false),
                new MySqlParameter("@p_VendorLeadId", 0),
                new MySqlParameter("@p_IsForVendor", true),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null)
            };

            var servicequestions = await FindAll("CALL SpSelectSearchServiceQuestion(@p_Limit, @p_Offset, @p_Value, @p_IsForSingleData,@p_IsForServiceType,@p_VendorLeadId,@p_IsForVendor, @p_FromDate, @p_ToDate)", getServiceQuestionParameters).ToListAsync();

            return servicequestions.FirstOrDefault();
        }

        public void DeleteEvent(Servicequestion servicequestion)
        {
            Delete(servicequestion);
        }
    }
}
