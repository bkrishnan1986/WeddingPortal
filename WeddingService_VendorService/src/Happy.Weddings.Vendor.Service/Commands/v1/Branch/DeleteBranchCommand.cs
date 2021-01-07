using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Branch
{
    /// <summary>
    /// Command for deleting a event
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteBranchCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteBranchCommand"/> class.
        /// </summary>
        /// <param name="branchId">The multicode identifier.</param>
        public DeleteBranchCommand(int branchId)
        {
            Id = branchId;
        }
    }
}
