using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Product;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.ECommerce
{
    public interface IProductService
    {
        Task<APIResponse> DeleteProducts(int productId);
        Task<APIResponse> UpdateProducts(int productId, UpdateProductRequest request);
        Task<APIResponse> CreateProducts(CreateProductsRequest request);
        Task<APIResponse> GetProductById(int productId);
        Task<APIResponse> GetProducts(ProductParameters productParameters);
    }
}
