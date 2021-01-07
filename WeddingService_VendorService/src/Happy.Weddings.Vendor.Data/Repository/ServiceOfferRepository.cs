#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
//                         | ServiceOfferedRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceOffer;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class ServiceOfferRepository : RepositoryBase<Serviceoffered>, IServiceOfferRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ServiceOfferResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ServiceOfferResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceOfferRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
       public ServiceOfferRepository(
            VendorContext repositoryContext, IMapper mapper, 
            ISortHelper<ServiceOfferResponse> sortHelper,
            IDataShaper<ServiceOfferResponse> dataShaper) : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Creates the services offered.
        /// </summary>
        /// <param name="serviceOffered">The service offered.</param>
        public void CreateServicesOffer(Serviceoffered serviceOffer)
        {
            Create(serviceOffer);
        }

        /// <summary>
        /// Gets the services offered by service identifier.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns></returns>
        public async Task<List<Serviceoffered>> GetServicesOfferedByServiceId(int serviceId)
        {
            var getServicesParams = new object[] {
                new MySqlParameter("@p_IsForSingleOfferedService", true),
                new MySqlParameter("@p_IsForService", null),
                new MySqlParameter("@p_Value", serviceId)
            };
            var servicesoffered = await FindAll("CALL SpSelectActiveService(@p_IsForSingleOfferedService, @p_IsForService, @p_Value)",
                getServicesParams).ToListAsync();
            return servicesoffered;
        }

        public void UpdateServicesOffer(Serviceoffered serviceOffer)
        {
            Update(serviceOffer);
        }
    }
}
