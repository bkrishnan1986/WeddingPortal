#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | IRepositoryWrapper interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Gets the Services.
        /// </summary>
        IServiceRepository ServiceRepository { get; }

        /// <summary>
        /// Gets the Assets.
        /// </summary>
        IAssetRepository AssetRepository { get; }

        /// <summary>
        /// Gets the SubscriptionPlans.
        /// </summary>
        ISubscriptionPlansRepository SubscriptionPlans { get; }

        IWalletRepository Wallets { get; }

        /// <summary>
        /// Gets the SubscriptionBenefits.
        /// </summary>
        IsubscriptionBenefitRepository SubscriptionBenefits { get; }

        //ISubsBenefitRepository SubsBenefits { get; }

        /// <summary>
        /// Gets the SubscriptionOffers.
        /// </summary>
        ISubscriptionOfferRepository SubscriptionOffers { get; }

        IServiceSubscriptionRepository ServiceSubscriptions { get; }

        /// <summary>
        /// Gets the VendorSubscriptions.
        /// </summary>
        ITopUpRepository TopUps { get; }

        ITopUpBenefitRepository TopUpBenefits { get; }

        IServiceTopupRepository ServiceTopups { get; }

        IUtilityRepository Utilitys { get; }

        ISuggestionListRepository SuggestionLists { get; }

        /// <summary>
        /// Gets the VendorSubscriptions.
        /// </summary>
        IReviewRepository Reviews { get; }

        IAverageRatingRepository AverageRatings { get; }

        /// <summary>
        /// Gets the VendorSubscriptions.
        /// </summary>
        ICommentReplyRepository CommentReply { get; }

        IReplyCountRepository ReplyCounts { get; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        IOffersRepository Offers { get; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        IBenefitsRepository Benefits { get; }
        ISubscriptionLocationRepository SubscriptionLocations { get; }

        /// <summary>
        /// Gets the multicodes.
        /// </summary>
        IMultiCodeRepository MultiCodes { get; }

        /// <summary>
        /// Gets the multidetails.
        /// </summary>
        IMultiDetailRepository MultiDetails { get; }

        /// <summary>
        /// Gets the events.
        /// </summary>
        IEventRepository Events { get; }

        /// <summary>
        /// Gets the event gallery.
        /// </summary>
        /// <value>
        /// The event gallery.
        /// </value>
        IEventGalleryRepository EventGallery { get; }

        /// <summary>
        /// Gets the service offer.
        /// </summary>
        /// <value>
        /// The service offer.
        /// </value>
        IServiceOfferRepository ServiceOffer { get; }

        /// <summary>
        /// Gets the service question.
        /// </summary>
        /// <value>
        /// The service question.
        /// </value>
        IServiceQuestionRepository ServiceQuestion { get; }

        /// <summary>
        /// Gets the service answer.
        /// </summary>
        /// <value>
        /// The service answer.
        /// </value>
        IServiceAnswerRepository ServiceAnswer { get; }
        IProfilePictureRepository ProfilePicture { get; }
        ICategoryDetailsRepository CategoryDetails { get; }
        IVendorQuestionAnswerRepository VendorQuestionAnswer { get; }
        IBranchRepository Branch { get; }
        IBranchServiceRepository BranchService { get; }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
