using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Guestlist;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.EventAssistant
{
    public interface IGuestlistService
    {
        Task<APIResponse> DeleteGuestlists(int guestlidtId);
        Task<APIResponse> UpdateGuestlists(int guestlidtId, UpdateGuestlistRequest request);
        Task<APIResponse> CreateGuestlists(CreateGuestlistRequest request);
        Task<APIResponse> GetGuestlistById(int guestlidtId);
        Task<APIResponse> GetGuestlists(GuestlistParameters guestlistParameters);
    }
}
