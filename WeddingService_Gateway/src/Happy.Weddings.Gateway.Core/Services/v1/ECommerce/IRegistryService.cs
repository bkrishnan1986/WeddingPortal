using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.ECommerce.Registry;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.ECommerce
{
    public interface IRegistryService
    {
        Task<APIResponse> DeleteRegistrys(int registryId);
        Task<APIResponse> UpdateRegistrys(int registryId, UpdateRegistryRequest request);
        Task<APIResponse> CreateRegistrys(CreateRegistryRequest request);
        Task<APIResponse> GetRegistryById(int registryId);
        Task<APIResponse> GetRegistrys(RegistryParameters productParameters);
    }
}
