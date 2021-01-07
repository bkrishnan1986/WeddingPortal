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
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    public class SendOtpHandler : IRequestHandler<SendOtpCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="SendOtpHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public SendOtpHandler(
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
        public async Task<APIResponse> Handle(SendOtpCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await repository.ProfileRepository.GetUserProfileById(command.ProfileId);
                if (profile == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                //Random otp generator
                Random rnd = new Random();
                string randomNumber = (rnd.Next(100000, 999999)).ToString();

                //Update otp in profile
                profile.Otp = randomNumber;
                profile.UpdatedAt = DateTime.UtcNow;
                profile.UpdatedBy = command.Request.CreatedBy;

                repository.ProfileRepository.UpdateUserProfile(profile);
                await repository.SaveAsync();

                var status = SendOTP(command, randomNumber);

                if(!status.Equals(MessageResource.StatusEnum.Queued))
                {
                    return new APIResponse(HttpStatusCode.BadRequest);
                }
                return new APIResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'SendOtpHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Sends the otp.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="randomNumber">The random number.</param>
        /// <returns></returns>
        private MessageResource.StatusEnum SendOTP(SendOtpCommand command,string randomNumber)
        {
            var accountSid = "AC0095579a395f630081eb6063692413a3";
            var authToken = "acacfa719d17676196b6f89fe98dec44";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(command.Request.MobileNumber))
            {
                From = new PhoneNumber("+12056795552"),
                Body = string.Concat(randomNumber," is the OTP for completing your registration." +
                "Thank you for Registering with us..Team Happy Wedding")
            };
            var message = MessageResource.Create(messageOptions);
            return message.Status;
        }
    }
}
