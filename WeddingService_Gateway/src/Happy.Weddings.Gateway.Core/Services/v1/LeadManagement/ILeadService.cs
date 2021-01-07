using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.LeadManagement
{
    public interface ILeadService
    {

        #region Lead

        Task<APIResponse> GetLeads(LeadParameters leadParameters);
        Task<APIResponse> GetLead(string leadId);
        Task<APIResponse> GetLeadsByVendor(LeadsByVendorParameters leadsByVendorParameters);
        Task<APIResponse> CreateLead(CreateLeadDataCollectionRequest request);
        Task<APIResponse> UpdateLead(int leadId, UpdateLeadRequest request);
        Task<APIResponse> UpdateLeadPortion(int leadDatacollectionId, UpdateLeadPortionRequest request);
        Task<APIResponse> DeleteLead(int leadId);

        #endregion

        #region FollowLead

        Task<APIResponse> CreateFollowLead(int leadId, CreateLeadValidationRequest request);
        Task<APIResponse> UpdateFollowLead(int leadId, int leadValidationId, UpdateLeadValidationRequest request);

        #endregion

        #region AssignLead

        Task<APIResponse> CreateAssignLead(int leadId, CreateLeadAssignRequest request);

        #endregion

        #region LeadQuote

        Task<APIResponse> GetLeadQuotes(int leadId, LeadQuoteParameters quoteParameters);
        Task<APIResponse> CreateLeadQuote(int leadId, CreateLeadQuoteRequest request);
        Task<APIResponse> UpdateLeadQuote(int leadId, UpdateLeadQuoteRequest request);
        Task<APIResponse> DeleteLeadQuote(int leadId);

        #endregion

        #region LeadStatus

        Task<APIResponse> GetLeadStatus(int leadId, LeadStatusParameter leadStatusParameter);
        #endregion

        #region LeadCount

        Task<APIResponse> GetLeadCount(string vendorId, LeadCountTotAmtParameter leadCountTotAmt);
        #endregion

        #region LeadTotalAmount

        Task<APIResponse> GetLeadTotalAmount(string vendorId, LeadCountTotAmtParameter leadCountTotAmt);
        #endregion

        #region LeadId
        Task<APIResponse> GetLeadId(LeadIdParameters idParameters);

        #endregion
    }
}
