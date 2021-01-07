using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Productquantity;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.ECommerce
{
    public interface IProductquantityService
    {
        Task<APIResponse> DeleteProductquantity(int productquantityId);
        Task<APIResponse> UpdateProductquantity(int productquantityId, UpdateProductquantityRequest request);
        Task<APIResponse> CreateProductquantity(CreateProductquantitysRequest request);
        Task<APIResponse> GetProductquantityById(int productquantityId);
        Task<APIResponse> GetProductquantitys(ProductquantityParameters productquantityParameters);
    }
}
