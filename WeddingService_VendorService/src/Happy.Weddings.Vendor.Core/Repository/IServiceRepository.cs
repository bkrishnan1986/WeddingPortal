#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | IServiceRepository interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses.Service;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository

{
    /// <summary>
    /// Interface For AssetRepository
    /// </summary>
    public interface IServiceRepository : IRepositoryBase<Services>
    {
        void CreateServices(List<Services> services);
        Task<Services> GetServiceById(int serviceId);
        void UpdateServices(Services services);
        void DeleteServices(Services services);
        // Task<PagedList<Domain.Entity>> GetAllServices(ServicesParameters serviceParameters);
        Task<List<ServiceResposnseList>> GetAllServices(ServicesParameters serviceParameters);
        Task<List<ServiceDetailsResponse>> GetServicesofVendor(string vendorId);
        Task<PagedList<Domain.Entity>> SearchFromAllServices(SearchParameters searchParameters);
    }
}
