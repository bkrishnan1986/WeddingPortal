using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Order;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.ECommerce
{
    public interface IOrderService
    {
        Task<APIResponse> DeleteOrders(int orderId);
        Task<APIResponse> UpdateOrders(int orderId, UpdateOrderRequest request);
        Task<APIResponse> CreateOrders(CreateOrderRequest request);
        Task<APIResponse> GetOrderById(int orderId);
        Task<APIResponse> GetOrders(OrderParameters productParameters);
    }
}
