using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Userinvitation;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.EventAssistant
{
    public interface IUserinvitationService
    {
        Task<APIResponse> DeleteUserinvitations(int userinvitationId);
        Task<APIResponse> UpdateUserinvitations(int userinvitationId, UpdateUserinvitationRequest request);
        Task<APIResponse> CreateUserinvitations(CreateUserInvitationListRequest request);
        Task<APIResponse> GetUserinvitationById(int userinvitationId);
        Task<APIResponse> GetUserinvitations(UserinvitationParameters userinvitationParameters);
    }
}
