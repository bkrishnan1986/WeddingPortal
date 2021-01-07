#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ServiceTopupRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// ServiceTopupRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Vendorsubscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ITopUpRepository" />
    public class ServiceTopupRepository : RepositoryBase<Servicetopup>, IServiceTopupRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ServiceTopupResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ServiceTopupResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public ServiceTopupRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<ServiceTopupResponse> sortHelper,
            IDataShaper<ServiceTopupResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all VendorSubscriptions.
        /// </summary>
        /// <param name="vendorSubscriptionsParameter">The VendorSubscriptions parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllServiceTopups(ServiceTopupParameter serviceTopupParameter)
        {
            {
                var getserviceTopupParams = new object[] {
                new MySqlParameter("@p_Limit", serviceTopupParameter.PageSize),
                new MySqlParameter("@p_Offset", (serviceTopupParameter.PageNumber - 1) * serviceTopupParameter.PageSize),
                new MySqlParameter("@p_IsForSingleServiceTopUp", serviceTopupParameter.IsForSingleServiceTopUp),
                new MySqlParameter("@p_IsForService", serviceTopupParameter.IsForService),
                new MySqlParameter("@p_IsForTopUp", serviceTopupParameter.IsForTopUp),
                new MySqlParameter("@p_Value", serviceTopupParameter.Value),
                new MySqlParameter("@p_ApprovalStatus", serviceTopupParameter.ApprovalStatus),
                new MySqlParameter("@p_PaymentStatus", serviceTopupParameter.PaymentStatus),
                new MySqlParameter("@p_FromDate", serviceTopupParameter.FromDate),
                new MySqlParameter("@p_ToDate", serviceTopupParameter.ToDate),


            };
                var servicesubscriptions = await FindAll("CALL SpSelectActiveServiceTopUp(@p_Limit, @p_Offset, @p_IsForSingleServiceTopUp,@p_IsForService,@p_IsForTopUp,@p_Value,@p_ApprovalStatus,@p_PaymentStatus, @p_FromDate, @p_ToDate)", getserviceTopupParams).ToListAsync();
                var mappedVendorSubscriptions = servicesubscriptions.AsQueryable().ProjectTo<ServiceTopupResponse>(mapper.ConfigurationProvider);
                var sortedVendorSubscriptions = sortHelper.ApplySort(mappedVendorSubscriptions, serviceTopupParameter.OrderBy);
                var shapedVendorSubscriptions = dataShaper.ShapeData(sortedVendorSubscriptions, serviceTopupParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedVendorSubscriptions, serviceTopupParameter.PageNumber, serviceTopupParameter.PageSize);

            }
        }

        /// <summary>
        /// Gets the ServiceTopup by identifier.
        /// </summary>
        /// <param name="ServiceTopupId">The ServiceTopup identifier.</param>
        /// <returns></returns>
        public async Task<Servicetopup> GetServiceTopupById(int ServiceTopupId)
        {
            var getserviceTopupParams = new object[] {
                new MySqlParameter("@p_Limit", null),
                new MySqlParameter("@p_Offset", null),
                new MySqlParameter("@p_IsForSingleServiceTopUp", true),
                new MySqlParameter("@p_IsForService", null),
                new MySqlParameter("@p_IsForTopUp", null),
                new MySqlParameter("@p_Value", ServiceTopupId),
                new MySqlParameter("@p_ApprovalStatus", null),
                new MySqlParameter("@p_PaymentStatus", null),
                new MySqlParameter("@p_FromDate", null),
                new MySqlParameter("@p_ToDate", null),

            };
            var servicesubscriptions = await FindAll("CALL SpSelectActiveServiceTopUp(@p_Limit, @p_Offset, @p_IsForSingleServiceTopUp,@p_IsForService,@p_IsForTopUp,@p_Value,@p_ApprovalStatus,@p_PaymentStatus, @p_FromDate, @p_ToDate)", getserviceTopupParams).ToListAsync();
            return servicesubscriptions.FirstOrDefault();
        }

        public async Task<List<ServiceTopupResponse>> GetServiceTopups(int ServiceId)
        {
            var result = await FindByCondition(sb => sb.ServiceId.Equals(ServiceId))
                  .ProjectTo<ServiceTopupResponse>(mapper.ConfigurationProvider)
                  .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the ServiceTopup.
        /// </summary>
        /// <param name="servicetopup">The ServiceTopup.</param>
        public void CreateServiceTopup(List<Servicetopup> servicetopup)
        {
            CreateRange(servicetopup);
        }
        /// <summary>
        /// Updates the servicetopup.
        /// </summary>
        /// <param name="servicetopup">The servicetopup.</param>
        public void UpdateServiceTopup(Servicetopup servicetopup)
        {

            Update(servicetopup);
        }

    }
}

