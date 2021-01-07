using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.EventAssistant.Checklist;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.EventAssistant
{
    public interface IChecklistService
    {
        Task<APIResponse> DeleteChecklists(int checklistId);
        Task<APIResponse> UpdateChecklists(int checklistId, UpdateChecklistRequest request);
        Task<APIResponse> CreateChecklists(CreateChecklistRequest request);
        Task<APIResponse> GetChecklistById(int checklistId);
        Task<APIResponse> GetChecklists(ChecklistParameters checklistParameters);
    }
}
