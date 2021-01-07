using System;

namespace Happy.Weddings.Gateway.Core.Config.EventAssistant
{
    public class EventAssistantServiceOperation
    {
        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/EventAssistant-Management";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "EventAssistantService";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";

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
        public static string GetMultiDetailsById(int multicodeId) => $"{baseUrl}/multidetails/{multicodeId}";

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


        /// <summary>
        /// Deletes the budgeters.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <returns></returns>
        public static string DeleteBudgeters(int budgeterId) => $"{baseUrl}/budgeters/{budgeterId}";

        /// <summary>
        /// Gets the budgeter by identifier.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <returns></returns>
        public static string GetBudgeterById(int budgeterId) => $"{baseUrl}/budgeters/{budgeterId}";

        /// <summary>
        /// Updates the budgeters.
        /// </summary>
        /// <param name="budgeterId">The budgeter identifier.</param>
        /// <returns></returns>
        public static string UpdateBudgeters(int budgeterId) => $"{baseUrl}/budgeters/{budgeterId}";

        /// <summary>
        /// Gets the budgeters.
        /// </summary>
        /// <returns></returns>
        public static string GetBudgeters() => $"{baseUrl}/budgeters";
        /// <summary>
        /// Creates the checklists.
        /// </summary>
        /// <returns></returns>
        public static string CreateBugeters() => $"{baseUrl}/budgeters";
        /// <summary>
        /// Creates the checklists.
        /// </summary>
        /// <returns></returns>
        public static string CreateChecklists() => $"{baseUrl}/checklists";

        /// <summary>
        /// Deletes the checklists.
        /// </summary>
        /// <param name="checklistId">The checklist identifier.</param>
        /// <returns></returns>
        public static string DeleteChecklists(int checklistId) => $"{baseUrl}/checklists/{checklistId}";


        /// <summary>
        /// Gets the checklist by identifier.
        /// </summary>
        /// <param name="checklistId">The checklist identifier.</param>
        /// <returns></returns>
        public static string GetChecklistById(int checklistId) => $"{baseUrl}/checklists/{checklistId}";

        /// <summary>
        /// Updates the checklists.
        /// </summary>
        /// <param name="checklistId">The checklist identifier.</param>
        /// <returns></returns>
        public static string UpdateChecklists(int checklistId) => $"{baseUrl}/checklists/{checklistId}";

        /// <summary>
        /// Gets the checklists.
        /// </summary>
        /// <returns></returns>
        public static string GetChecklists() => $"{baseUrl}/checklists";

        /// <summary>
        /// Creates the guestlists.
        /// </summary>
        /// <returns></returns>
        public static string CreateGuestlists() => $"{baseUrl}/guestlists";

        /// <summary>
        /// Deletes the guestlists.
        /// </summary>
        /// <param name="guestlistId">The guestlist identifier.</param>
        /// <returns></returns>
        public static string DeleteGuestlists(int guestlistId) => $"{baseUrl}/guestlists/{guestlistId}";


        /// <summary>
        /// Gets the guestlist by identifier.
        /// </summary>
        /// <param name="guestlistId">The guestlist identifier.</param>
        /// <returns></returns>
        public static string GetGuestlistById(int guestlistId) => $"{baseUrl}/guestlists/{guestlistId}";

        /// <summary>
        /// Updates the guestlists.
        /// </summary>
        /// <param name="guestlistId">The guestlist identifier.</param>
        /// <returns></returns>
        public static string UpdateGuestlists(int guestlistId) => $"{baseUrl}/guestlists/{guestlistId}";

        /// <summary>
        /// Gets the guestlists.
        /// </summary>
        /// <returns></returns>
        public static string GetGuestlists() => $"{baseUrl}/guestlists";

        /// <summary>
        /// Creates the invitations.
        /// </summary>
        /// <returns></returns>
        public static string CreateInvitations() => $"{baseUrl}/invitations";


        /// <summary>
        /// Deletes the invitations.
        /// </summary>
        /// <param name="invitationId">The invitation identifier.</param>
        /// <returns></returns>
        public static string DeleteInvitations(int invitationId) => $"{baseUrl}/invitations/{invitationId}";


        /// <summary>
        /// Gets the invitation by identifier.
        /// </summary>
        /// <param name="invitationId">The invitation identifier.</param>
        /// <returns></returns>
        public static string GetInvitationById(int invitationId) => $"{baseUrl}/invitations/{invitationId}";


        /// <summary>
        /// Updates the invitations.
        /// </summary>
        /// <param name="invitationId">The invitation identifier.</param>
        /// <returns></returns>
        public static string UpdateInvitations(int invitationId) => $"{baseUrl}/invitations/{invitationId}";


        /// <summary>
        /// Gets the invitations.
        /// </summary>
        /// <returns></returns>
        public static string GetInvitations() => $"{baseUrl}/invitations";

        /// <summary>
        /// Creates the guesteventlists.
        /// </summary>
        /// <returns></returns>
        public static string CreateGuesteventlists() => $"{baseUrl}/guesteventlists";


        /// <summary>
        /// Deletes the guesteventlists.
        /// </summary>
        /// <param name="guesteventlistId">The guesteventlist identifier.</param>
        /// <returns></returns>
        public static string DeleteGuesteventlists(int guesteventlistId) => $"{baseUrl}/guesteventlists/{guesteventlistId}";

        /// <summary>
        /// Gets the guesteventlist by identifier.
        /// </summary>
        /// <param name="guesteventlistId">The guesteventlist identifier.</param>
        /// <returns></returns>
        public static string GetGuesteventlistById(int guesteventlistId) => $"{baseUrl}/guesteventlists/{guesteventlistId}";

        /// <summary>
        /// Updates the guesteventlists.
        /// </summary>
        /// <param name="guesteventlistId">The guesteventlist identifier.</param>
        /// <returns></returns>
        public static string UpdateGuesteventlists(int guesteventlistId) => $"{baseUrl}/guesteventlists/{guesteventlistId}";

        /// <summary>
        /// Gets the guesteventlists.
        /// </summary>
        /// <returns></returns>
        public static string GetGuesteventlists() => $"{baseUrl}/guesteventlists";


        /// <summary>
        /// Creates the user invitationslists.
        /// </summary>
        /// <returns></returns>
        public static string CreateUserInvitations() => $"{baseUrl}/userinvitations";

        /// <summary>
        /// Deletes the user invitations.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <returns></returns>
        public static string DeleteUserInvitations(int userinvitationId) => $"{baseUrl}/userinvitations/{userinvitationId}";

        /// <summary>
        /// Gets the user invitation by identifier.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <returns></returns>
        public static string GetUserInvitationById(int userinvitationId) => $"{baseUrl}/userinvitations/{userinvitationId}";

        /// <summary>
        /// Updates the user invitations.
        /// </summary>
        /// <param name="userinvitationId">The userinvitation identifier.</param>
        /// <returns></returns>
        public static string UpdateUserInvitations(int userinvitationId) => $"{baseUrl}/userinvitations/{userinvitationId}";
        /// <summary>
        /// Gets the user invitations.
        /// </summary>
        /// <returns></returns>
        public static string GetUserInvitations() => $"{baseUrl}/userinvitations";

    }
}
