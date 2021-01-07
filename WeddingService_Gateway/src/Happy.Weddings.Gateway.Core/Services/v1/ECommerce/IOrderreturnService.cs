using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Orderreturn;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.ECommerce
{
    public interface IOrderreturnService
    {
        Task<APIResponse> DeleteOrderreturns(int orderreturnId);
        Task<APIResponse> UpdateOrderreturns(int orderreturnId, UpdateOrderreturnRequest request);
        Task<APIResponse> CreateOrderreturns(CreateOrderreturnRequest request);
        Task<APIResponse> GetOrderreturnById(int orderreturnId);
        Task<APIResponse> GetOrderreturns(OrderreturnParameters orderreturnParameters);
    }
}
