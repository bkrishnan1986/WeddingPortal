using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.ProfilePicture;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ProfilePicture
{
    public class GetCategoryDetailsVendorIdHandler : IRequestHandler<GetCategoryDetailsVendorIdQuery, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEventByConditionHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetCategoryDetailsVendorIdHandler(
         IRepositoryWrapper repository,
         ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(GetCategoryDetailsVendorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categorydetails = await repository.CategoryDetails.GetCategoryDetailsVendorId(request.VendorId);
                if (categorydetails == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                foreach (var item in categorydetails)
                {
                    var serviceId = item.ServiceType;
                    var branchServicesList = await repository.BranchService.GetBranchServiceOfferedByServiceId(serviceId);
                    item.Branchserviceoffered = branchServicesList;

                    foreach (var items in branchServicesList)
                    {
                        var branchId = items.BranchId;
                        var branchesList = await repository.Branch.GetBranchesByBranchId(branchId);
                        item.Branches = branchesList;
                    }
                }
                return new APIResponse(categorydetails, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetCategoryDetailsVendorIdHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
