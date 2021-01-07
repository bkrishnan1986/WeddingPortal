using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.BranchService
{
    public class DeleteBranchServiceCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBranchServiceCommand"/> class.
        /// </summary>
        /// <param name="eventId">The multicode identifier.</param>
        public DeleteBranchServiceCommand(int branchId)
        {
            Id = branchId;
        }
    }
}
