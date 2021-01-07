using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Commands.v1.Profile;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    public class VerifyOtpHandler : IRequestHandler<VerifyOtpCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="VerifyOtpHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public VerifyOtpHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(VerifyOtpCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await repository.ProfileRepository.GetUserProfileById(command.ProfileId);
                if(profile.Otp != command.Request.Otp)
                {
                    return new APIResponse(HttpStatusCode.Conflict);
                }
                profile.IsPhoneVerified = 1;

                repository.ProfileRepository.UpdateUserProfile(profile);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'VerifyOtpHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
