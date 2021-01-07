using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Cart;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.ECommerce
{
    public interface ICartService
    {
        Task<APIResponse> DeleteCarts(int cartId);
        Task<APIResponse> UpdateCarts(int cartId, UpdateCartRequest request);
        Task<APIResponse> CreateCarts(CreateCartsRequest request);
        Task<APIResponse> GetCartById(int cartId);

        Task<APIResponse> GetCartByUserId(int userId);
        Task<APIResponse> GetCarts(CartParameters cartParameters);
    }
}
