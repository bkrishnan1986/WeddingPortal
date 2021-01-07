using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.Config.LeadManagement
{
    public class LeadServiceOperation
    {
        #region Base

        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/lead-management";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "LeadService";

        /// <summary>
        /// The get Lead cache name
        /// </summary>
        public static string GetLeadCacheName = "GetLeadCache()";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";

        #endregion


        #region MultiCode

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiCodes() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Gets the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string GetMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiCode() => $"{baseUrl}/multicodes";

        /// <summary>
        /// Updates the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string UpdateMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        /// <summary>
        /// Deletes the Multicode.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static string DeleteMultiCode(string code) => $"{baseUrl}/multicodes/{code}";

        #endregion

        #region MultiDetail

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string GetAllMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multicodeId">The Multicode identifier.</param>
        /// <returns></returns>
        public static string GetMultiDetailsById(string multicodeId) => $"{baseUrl}/multidetails/{multicodeId}";

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <returns></returns>
        public static string CreateMultiDetails() => $"{baseUrl}/multidetails";

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string UpdateMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        public static string DeleteMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";

        #endregion

        #region Lead

        /// <summary>
        /// Gets All the Leads.
        /// </summary>
        /// <returns></returns>
        public static string GetLeads() => $"{baseUrl}/leads";

        /// <summary>
        /// Gets the Lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public static string GetLead(string leadId) => $"{baseUrl}/leads/{leadId}";

        /// <summary>
        /// Gets All the Leads by Vendor.
        /// </summary>
        /// <returns></returns>
        public static string GetLeadsByVendor() => $"{baseUrl}/leads/GetLeadsByVendor";

        /// <summary>
        /// Creates the lead.
        /// </summary>
        /// <returns></returns>
        public static string CreateLead() => $"{baseUrl}/leads";

        /// <summary>
        /// Updates the lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public static string UpdateLead(int leadId) => $"{baseUrl}/leads/{leadId}";

        /// <summary>
        /// Update lead portion.
        /// </summary>
        /// <param name="leadDatacollectionId">The leadDatacollection identifier.</param>
        /// The update lead portion.
        /// <returns></returns>
        public static string UpdateLeadPortion(int leadDatacollectionId) => $"{baseUrl}/leads/{leadDatacollectionId}";

        /// <summary>
        /// Gets the delete lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// The delete lead.
        /// <returns></returns>
        public static string DeleteLead(int leadId) => $"{baseUrl}/leads/{leadId}";

        #endregion

        #region FollowLead

        /// <summary>
        /// Creates the follow lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public static string CreateFollowLead(int leadId) => $"{baseUrl}/leads/{leadId}/followLead";


        public static string UpdateFollowLead(int leadId, int leadValidationId) => $"{baseUrl}/leads/{leadId}/followLead/{leadValidationId}";

        #endregion

        #region AssignLead

        /// <summary>
        /// Creates the assign lead.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public static string CreateAssignLead(int leadId) => $"{baseUrl}/leads/{leadId}/assignLead";

        #endregion

        #region LeadQuote

        /// <summary>
        /// Gets the Lead quote.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public static string GetLeadQuotes(int leadId) => $"{baseUrl}/leads/{leadId}/GetLeadQuotes";

        /// <summary>
        /// Creates the lead quote.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public static string CreateLeadQuote(int leadId) => $"{baseUrl}/leads/{leadId}/CreateLeadQuote/";

        /// <summary>
        /// Updates the lead quote.
        /// </summary>
        /// <param name="quoteId">The quote identifier.</param>
        /// <returns></returns>
        public static string UpdateLeadQuote(int quoteId) => $"{baseUrl}/leads/{quoteId}/UpdateLeadQuote/";

        /// <summary>
        /// Deletes the lead quote.
        /// </summary>
        /// <param name="quoteId">The quote identifier.</param>
        /// <returns></returns>
        public static string DeleteLeadQuote(int quoteId) => $"{baseUrl}/leads/{quoteId}/DeleteLeadQuote";

        #endregion

        #region LeadStatus

        /// <summary>
        /// Gets the lead status.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <returns></returns>
        public static string GetLeadStatus(int leadId) => $"{baseUrl}/leads/{leadId}/GetLeadStatus";

        #endregion

        #region LeadCount

        /// <summary>
        /// Gets the lead count.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        public static string GetLeadCount(string vendorId) => $"{baseUrl}/leads/{vendorId}/GetLeadCount";

        #endregion


        #region LeadTotalAmount

        /// <summary>
        /// Gets the lead total amount.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        public static string GetLeadTotalAmount(string vendorId) => $"{baseUrl}/leads/{vendorId}/GetLeadTotalAmount";

        #endregion

        #region LeadId

        /// <summary>
        /// Gets the lead identifier.
        /// </summary>
        /// <returns></returns>
        public static string GetLeadId() => $"{baseUrl}/leads/leadId";

        #endregion
    }
}
