using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.Branch;
using MediatR;
using Serilog;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.Branch
{
    public class GetAllBranchByIdHandler : IRequestHandler<GetAllBranchesQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetAllBranchByIdHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllBranchByIdHandler(
           IRepositoryWrapper repository,
           ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var branches = await repository.Branch.GetAllBranches(request.branchParameters);
             /*  foreach (var branchDetails in branches)
                {
                    var districtId = branchDetails.DistrictId;
                    var branchList = await repository.MultiDetails.GetMultiDetailByMultiDetailsId(districtId);
                    branchDetails.Multidetail = branchList;
                }  */
                return new APIResponse(branches, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllBranchByIdHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
