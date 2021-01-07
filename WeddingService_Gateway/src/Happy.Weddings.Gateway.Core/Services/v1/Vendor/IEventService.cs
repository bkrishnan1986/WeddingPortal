using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Event;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IEventService
    {
        Task<APIResponse> DeleteEvent(int eventId);
        Task<APIResponse> UpdateEvent(int eventId, UpdateEventRequest request);
        Task<APIResponse> GetEventById(int eventId);
        Task<APIResponse> GetEventDetailsById(EventVendorParameters eventVendorParameters);
        Task<APIResponse> CreateEvent(CreateEventRequest request);
        Task<APIResponse> GetEventsByCondition(EventParameters eventParameters);
    }
}
