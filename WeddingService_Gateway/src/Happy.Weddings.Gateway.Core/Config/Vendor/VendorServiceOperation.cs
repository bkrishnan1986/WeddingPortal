using System;

namespace Happy.Weddings.Gateway.Core.Config.Vendor
{
    public class VendorServiceOperation
    {
        /// <summary>
        /// The base URL
        /// </summary>
        const string baseUrl = "/api/v1/vendor-management";

        /// <summary>
        /// The service name
        /// </summary>
        public static string serviceName = "VendorService";

        /// <summary>
        /// The get Vendor cache name
        /// </summary>
        public static string GetWalletCacheName = "GetVendorCache()";

        /// <summary>
        /// Gets the health.
        /// </summary>
        /// <returns></returns>
        public static string GetHealth() => $"/hc";           

        public static string AddAssets()
        {
            throw new NotImplementedException();
        }

        public static string CreateEvent() => $"{baseUrl}/events";
        //{
        //    throw new NotImplementedException();
        //}

        public static string CreateOffer()
        {
            throw new NotImplementedException();
        }

        public static string CreateCommentReply()
        {
            throw new NotImplementedException();
        }

        public static string CreateReview()
        {
            throw new NotImplementedException();
        }

        public static string AddService()
        {
            throw new NotImplementedException();
        }

        public static string CreateServiceSubscription() => $"{baseUrl}/servicesubscriptions";
        public static string CreateServiceTopup() => $"{baseUrl}/servicetopup";

        public static string CreateSubcriptionLocation()
        {
            throw new NotImplementedException();
        }

        public static string CreateTopUp()
        {
            throw new NotImplementedException();
        }

        public static string CreateSuggestionList()
        {
            throw new NotImplementedException();
        }

        public static string UpdateAsset(int assetId)
        {
            throw new NotImplementedException();
        }

        public static string CreateSubcriptionPlan()
        {
            throw new NotImplementedException();
        }

        public static string UpdateEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateSubcriptionOffers(int subscriptionOffersId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateOffer(int offerId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateCommentReply(int commentreplyId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateService(int serviceId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateVendorSubscription(int servicesubscriptionId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteService(int serviceId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteServiceTopup(int servicetopupId)
        {
            throw new NotImplementedException();
        }

        public static string CreateTopUpBenefit()
        {
            throw new NotImplementedException();
        }

        public static string DeleteTopUp(int topupId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteSuggestionList(int suggestionlistId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteSubcriptionPlan(int subscriptionLocationId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteSubcriptionBenefit(int subcriptionbenefitId)
        {
            throw new NotImplementedException();
        }

        public static string CreateSubcriptionOffers()
        {
            throw new NotImplementedException();
        }

        public static string DeleteServiceSubscription(int servicesubscriptionId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteAsset(int assetId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateServiceTopup(int servicesubscriptionId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateSubcriptionBenefit(int subcriptionbenefitId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateSubcriptionPlan(int subscriptionLocationId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateSuggestionList(int suggestionlistId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateTopUpBenefit(int topupId)
        {
            throw new NotImplementedException();
        }

        public static string UpdateTopUp(int topupId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteCommentReply(int commentReplyId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteOffer(int offerId)
        {
            throw new NotImplementedException();
        }

        public static string DeleteReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public static string GetAssetById(int assetId) => $"{baseUrl}/assets/{assetId}";
        public static string GetAllAssets() => $"{baseUrl}/assets";
        public static string GetEventDetailsById() => $"{baseUrl}/events/eventVendorParameters";
        public static string GetEventsByCondition() => $"{baseUrl}/events/eventParameters";
        public static string GetEventById(int eventId) => $"{baseUrl}/events/{eventId}";
        public static string GetEventGalleryByVendorId() => $"{baseUrl}/events/eventsgallery";
        public static string GetOffers() => $"{baseUrl}/offers";
        public static string GetOffer(int offerId) => $"{baseUrl}/offers/{offerId}";
        public static string GetSubcriptionOffers() => $"{baseUrl}/offers/subscriptionoffers";
        public static string GetSubcriptionOffer(int subscriptionOffersId) => $"{baseUrl}/offers/{subscriptionOffersId}";
        public static string GetReviews() => $"{baseUrl}/reviews";
        public static string GetReview(int reviewId) => $"{baseUrl}/reviews/{reviewId}";
        public static string GetCommentReply(int commentreplyId) => $"{baseUrl}/reviews/{commentreplyId}";
        public static string GetAllBranches() => $"{baseUrl}/branch";
        public static string CreateBranch() => $"{baseUrl}/branch";
        public static string UpdateBranch(int branchId) => $"{baseUrl}/branch/{branchId}";
        public static string DeleteBranch(int branchId) => $"{baseUrl}/branch/{branchId}";          
        public static string GetCategoryDetailsByVendorId(string vendorId) => $"{baseUrl}/vendorprofile/{vendorId}";
        public static string CreateCategoryDetails() => $"{baseUrl}/vendorprofile/categoryDetails";
        public static string UpdateCategoryDetails(int categoryId) => $"{baseUrl}/vendorprofile/{categoryId}";
        public static string GetAllServiceQuestionsByServiceType() => $"{baseUrl}/servicequestion";
        public static string GetAllServiceAnswerByServiceQuestion(int serviceQuestionId) => $"{baseUrl}/servicequestion/{serviceQuestionId}";
        public static string CreateServiceQuestion() => $"{baseUrl}/servicequestion";
        public static string UpdateServiceQuestion(int questionId) => $"{baseUrl}/servicequestion/{questionId}";
        public static string DeleteServiceQuestion(int questionId) => $"{baseUrl}/servicequestion/{questionId}";
        public static string CreateServiceAnswer() => $"{baseUrl}/servicequestion/createanswers";
        public static string UpdateServiceAnswer(int questionId) => $"{baseUrl}/servicequestion/{questionId}/updateanswers";
        public static string DeleteServiceAnswer(int questionId) => $"{baseUrl}/servicequestion/{questionId}/deleteserviceanswer";
        public static string GetServiceQuestionsById() => $"{baseUrl}/servicequestion";
        public static string GetServiceAnswersById(int serviceQuestionId, string Id, int serviceAnswerId) => $"{baseUrl}/serviceanswer/{serviceQuestionId}/{Id}/{serviceAnswerId}";
        public static string GetAllVendorQuestionAnswersById(string Id, bool IsForVendor) => $"{baseUrl}/servicequestion/{Id}/{IsForVendor}/vendorquestionanswers";
        public static string CreateVendorQuestionAnswer() => $"{baseUrl}/servicequestion/createvendorquestioanswers";
        public static string UpdateVendorQuestionAnswer(string vendorleadId) => $"{baseUrl}/servicequestion/{vendorleadId}/updateVendorQuestionAnswer";
        public static string CreateMultiDetails() => $"{baseUrl}/multidetails";
        public static string CreateMultiCode() => $"{baseUrl}/multicodes";
        public static string DeleteMultiCode(string code) => $"{baseUrl}/multicodes/{code}";
        public static string GetMultiCodeById(string code) => $"{baseUrl}/multicodes/{code}";
        public static string UpdateMultiCode(string code) => $"{baseUrl}/multicodes/{code}";
        public static string DeleteMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";
        public static string GetMultiDetailsById(string code) => $"{baseUrl}/multidetails/{code}";
        public static string UpdateMultiDetails(int multidetailId) => $"{baseUrl}/multidetails/{multidetailId}";
        public static string GetMultiCodes() => $"{baseUrl}/multicodes";
        public static string GetMultiDetails() => $"{baseUrl}/multidetails";  
        public static string GetServicesofVendor(string vendorId) => $"{baseUrl}/services/vendorservice/{vendorId}";
        public static string Createutility() => $"{baseUrl}/utility";
        public static string Deleteutility(int utilityId) => $"{baseUrl}/utility/{utilityId}";
        public static string GetutilityById(int utilityId) => $"{baseUrl}/utility/{utilityId}";
        public static string Updateutility(int utilityId) => $"{baseUrl}/utility/{utilityId}";
        public static string Getutilitys() => $"{baseUrl}/utility";
        public static string GetAllServices() => $"{baseUrl}/services";

    }
}
