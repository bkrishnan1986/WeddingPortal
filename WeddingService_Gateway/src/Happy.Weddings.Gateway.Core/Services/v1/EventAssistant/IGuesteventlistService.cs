using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Guesteventlist;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.EventAssistant
{
    public interface IGuesteventlistService
    {
        Task<APIResponse> DeleteGuesteventlists(int guesteventlistId);
        Task<APIResponse> UpdateGuesteventlists(int guesguesteventlistIdtlidtId, UpdateGuesteventlistRequest request);
        Task<APIResponse> CreateGuesteventlists(CreateGuesteventlistRequest request);
        Task<APIResponse> GetGuesteventlistById(int guesteventlistId);
        Task<APIResponse> GetGuesteventlists(GuesteventlistParameters guesteventlistParameters);
    }
}
