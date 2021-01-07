using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Invitation;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.EventAssistant
{
    public interface IInvitationService
    {
        Task<APIResponse> DeleteInvitations(int invitationId);
        Task<APIResponse> UpdateInvitations(int invitationId, UpdateInvitationRequest request);
        Task<APIResponse> CreateInvitations(CreateInvitationRequest request);
        Task<APIResponse> GetInvitationById(int invitationId);
        Task<APIResponse> GetInvitations(InvitationParameters invitationParameters);
    }
}
