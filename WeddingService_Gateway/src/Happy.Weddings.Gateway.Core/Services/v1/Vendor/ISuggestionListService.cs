using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SuggestionList;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface ISuggestionListService
    {
        Task<APIResponse> DeleteSuggestionList(int suggestionlistId);
        Task<APIResponse> UpdateSuggestionList(int suggestionlistId, UpdateSuggestionListRequest request);
        Task<APIResponse> CreateSuggestionList(CreateSuggestionListRequest request);
        Task<APIResponse> GetSuggestionList(int suggestionlistId);
        Task<APIResponse> GetSuggestionLists(SuggestionListParameter suggestionListsParameters);
    }
}
