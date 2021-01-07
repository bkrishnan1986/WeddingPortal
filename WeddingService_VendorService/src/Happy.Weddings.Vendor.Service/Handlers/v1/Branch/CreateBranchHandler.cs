using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.DTO.Responses.Branch;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.Branch;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.Branch
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateBranchHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Branches> branches = new List<Branches>();

                foreach (var item in request.BranchRequest.Branches)
                {
                    var branchRequest = mapper.Map<Branches>(item);
                    branchRequest.Branchserviceoffered.ToList().ForEach(x => x.CreatedBy = branchRequest.CreatedBy);
                    branches.Add(branchRequest);
                }    

                repository.Branch.CreateBranch(branches);                  
                await repository.SaveAsync();

                List<BranchServiceResponseId> branchServiceResponseIds = new List<BranchServiceResponseId>();

                foreach (var item in branches)
                {
                    foreach (var items in item.Branchserviceoffered)
                    {
                        branchServiceResponseIds.Add(
                        new BranchServiceResponseId()
                        {
                            BranchId = item.Id,
                            BranchServiceId = items.Id,
                            ServiceId = items.ServiceId
                        });
                    }

                }
                return new APIResponse(branchServiceResponseIds, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateBranchHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
