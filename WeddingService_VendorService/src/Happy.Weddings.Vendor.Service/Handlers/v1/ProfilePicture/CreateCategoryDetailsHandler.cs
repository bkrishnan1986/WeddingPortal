using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.ProfilePicture;
using MediatR;
using Serilog;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ProfilePicture
{
    public class CreateCategoryDetailsHandler : IRequestHandler<CreateCategoryDetailsCommand, APIResponse>
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
        public CreateCategoryDetailsHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<APIResponse> Handle(CreateCategoryDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categorydetails = mapper.Map<Categorydetails>(request.Request);
                categorydetails.Profilepictures.ToList().ForEach(x => x.CreatedBy = categorydetails.CreatedBy);
                categorydetails.Subcategory.ToList().ForEach(x => x.CreatedBy = categorydetails.CreatedBy);

                repository.CategoryDetails.CreateCategoryDetails(categorydetails);
                await repository.SaveAsync();

                var categoryid = categorydetails.Profilepictures.Last().CategoryId;
               // request.Request.CategoryId = categoryid;   
                                                        
                return new APIResponse(request.Request,HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateCategoryDetailsHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
