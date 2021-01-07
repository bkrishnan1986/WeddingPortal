using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Orderlocation;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.ECommerce
{
    public interface IOrderlocationService
    {
        Task<APIResponse> DeleteOrderlocations(int orderId);
        Task<APIResponse> UpdateOrderlocations(int orderId, UpdateOrderlocationRequest request);
        Task<APIResponse> CreateOrderlocation(CreateOrderlocationRequest request);
        Task<APIResponse> GetOrderlocationById(int orderId);
        Task<APIResponse> GetOrderlocations(OrderlocationParameters productParameters);
    }
}
