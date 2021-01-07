using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.Branch;
using Happy.Weddings.Vendor.Service.Commands.v1.Event;
using MediatR;
using Serilog;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.Branch
{
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="DeleteBranchHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public DeleteBranchHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branches = await repository.Branch.GetBranchByBranchId(request.Id);
                if (branches == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
               // branches.Active = 0;
                repository.Branch.Update(branches);
                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteBranchHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
