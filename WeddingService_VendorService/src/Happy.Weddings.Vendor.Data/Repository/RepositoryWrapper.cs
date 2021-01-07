#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | RepositoryWrapper class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses.Asset;
using Happy.Weddings.Vendor.Core.DTO.Responses.Benefits;
using Happy.Weddings.Vendor.Core.DTO.Responses.Branch;
using Happy.Weddings.Vendor.Core.DTO.Responses.BranchServiceOffered;
using Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Responses.Event;
using Happy.Weddings.Vendor.Core.DTO.Responses.EventGallery;
using Happy.Weddings.Vendor.Core.DTO.Responses.MultiCode;
using Happy.Weddings.Vendor.Core.DTO.Responses.MultiDetail;
using Happy.Weddings.Vendor.Core.DTO.Responses.Offers;
using Happy.Weddings.Vendor.Core.DTO.Responses.ProfilePicture;
using Happy.Weddings.Vendor.Core.DTO.Responses.Review;
using Happy.Weddings.Vendor.Core.DTO.Responses.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceOffer;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceSubscriptions;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.DTO.Responses.SuggestionList;
using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.DTO.Responses.Utility;
using Happy.Weddings.Vendor.Core.DTO.Responses.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses.Wallet;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        /// <summary>
        /// Gets or sets the repository context.
        /// </summary>
        private VendorContext repositoryContext { get; set; }
        /// <summary>
        /// Gets the services.
        /// </summary>
        private IServiceRepository services { get; set; }
        /// <summary>
        /// Gets the services.
        /// </summary>
        private IAssetRepository assets { get; set; }

        /// <summary>
        /// Gets the MultiCode.
        /// </summary>
        private IMultiCodeRepository multiCode { get; set; }

        /// <summary>
        /// Gets the MultiDetail.
        /// </summary>
        private IMultiDetailRepository multidetail { get; set; }

        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;
        /// <summary>
        /// Gets the SubscriptionsPlans.
        /// </summary>
        private ISubscriptionPlansRepository subscriptionsPlans { get; set; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        private IOffersRepository offers { get; set; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        private IBenefitsRepository benefits { get; set; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        private IsubscriptionBenefitRepository subscriptionBenefits { get; set; }

        //private ISubsBenefitRepository subsBenefits { get; set; }


        private IUtilityRepository utility { get; set; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        private ISubscriptionOfferRepository subscriptionOffers { get; set; }

        private IServiceSubscriptionRepository serviceSubscriptions { get; set; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        private ITopUpRepository topUps { get; set; }

        private ITopUpBenefitRepository topUpBenefits { get; set; }

        private IServiceTopupRepository serviceTopups { get; set; }

        private ISuggestionListRepository suggestionLists { get; set; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        private IReviewRepository reviews { get; set; }

        private IAverageRatingRepository averageRatings { get; set; }


        private IReplyCountRepository replyCounts { get; set; }

        /// <summary>
        /// Gets the Offers.
        /// </summary>
        private ICommentReplyRepository commentReply { get; set; }

        /// <summary>
        /// Gets the event.
        /// </summary>
        private IEventRepository events { get; set; }

        private IWalletRepository wallets { get; set; }

        private ISubscriptionLocationRepository subscriptionLocations { get; set; }

        /// <summary>
        /// Gets or sets the event gallery.
        /// </summary>
        /// <value>
        /// The event gallery.
        /// </value>
        private IEventGalleryRepository eventGallery { get; set; }

        private IServiceOfferRepository serviceOffer { get; set; }

        /// <summary>
        /// Gets or sets the service question.
        /// </summary>
        /// <value>
        /// The service question.
        /// </value>
        private IServiceQuestionRepository serviceQuestion { get; set; }

        /// <summary>
        /// Gets or sets the service answer.
        /// </summary>
        /// <value>
        /// The service answer.
        /// </value>
        private IServiceAnswerRepository serviceAnswer { get; set; }
        private IProfilePictureRepository profilePicture { get; set; }
        private ICategoryDetailsRepository categoryDetails { get; set; }
        private IVendorQuestionAnswerRepository vendorQuestionAnswer { get; set; }
        private IBranchRepository branch{ get; set; }
        private IBranchServiceRepository branchService { get; set; }

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<SubscriptionPlansResponse> subscriptionsPlansSortHelper;   

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<SubscriptionPlansResponse> subscriptionsPlansDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<SubscriptionBenefitsResponse> subscriptionsBenefitsSortHelper;   

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<SubscriptionBenefitsResponse> subscriptionsBenefitsDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<SubsBenefitDataResponse> subsBenefitsSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<SubsBenefitDataResponse> subsBenefitsDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<ServiceSubscriptionsResponse> serviceSubscriptionsSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<ServiceSubscriptionsResponse> serviceSubscriptionsDataShaper;

        private IDataShaper<ProfilePictureResponse> profilePictureDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<ServiceTopupResponse> serviceTopupsSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<ServiceTopupResponse> serviceTopupsDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<TopUpsResponse> topUpsSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<TopUpsResponse> topUpsDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<UtilityResponse> utilitySortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<UtilityResponse> utilityDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<TopUpBenefitResponse> topUpBenefitsSortHelper;

        private ISortHelper<WalletResponse> walletsSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<WalletResponse> walletsDataShaper;

        private ISortHelper<SubscriptionLocationResponse> subscriptionLocationsSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<SubscriptionLocationResponse> subscriptionLocationsDataShaper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<SuggestionListResponse> suggestionListsDataShaper;


        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<SuggestionListResponse> suggestionListsSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<TopUpBenefitResponse> topUpBenefitsDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<CommentReplyResponse> commentReplySortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<CommentReplyResponse> commentReplyDataShaper;

        /// <summary>
        /// The reviews sort helper
        /// </summary>
        private ISortHelper<ReviewsResponse>   reviewsSortHelper;

        /// <summary>
        /// The reviews data shaper
        /// </summary>
        private IDataShaper<ReviewsResponse> reviewsDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<SubscriptionOfferResponse> subscriptionsOffersSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<SubscriptionOfferResponse> subscriptionsOffersDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<OffersResponse> offerSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<OffersResponse> offerDataShaper;

        /// <summary>
        /// The stories sort helper
        /// </summary>
        private ISortHelper<BenefitsResponse> benefitSortHelper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<BenefitsResponse> benefitDataShaper;
        /// <summary>
        /// The service sort helper
        /// </summary>
        private ISortHelper<ServiceResponse> servicesSortHelper;

        /// <summary>
        /// The multicode sort helper
        /// </summary>
        private ISortHelper<MultiCodeResponse> multicodeSortHelper;

        /// <summary>
        /// The multidetail sort helper
        /// </summary>
        private ISortHelper<MultiDetailResponse> multidetailSortHelper;

        /// <summary>
        /// The multidetail data shaper
        /// </summary>
        private IDataShaper<MultiDetailResponse> multidetailDataShaper;

        /// <summary>
        /// The stories data shaper
        /// </summary>
        private IDataShaper<MultiCodeResponse> multicodeDataShaper;

        /// <summary>
        /// The service data shaper
        /// </summary>
        private IDataShaper<ServiceResponse> servicesDataShaper;
        /// <summary>
        /// The asset sort helper
        /// </summary>
        private ISortHelper<AssetResponse> assetSortHelper;     

        /// <summary>
        /// The asset data shaper
        /// </summary>
        private IDataShaper<AssetResponse> assetDataShaper;

        /// <summary>
        /// The events sort helper
        /// </summary>
        private ISortHelper<EventResponse> eventsSortHelper;    

        /// <summary>
        /// The events data shaper
        /// </summary>
        private IDataShaper<EventResponse> eventsDataShaper;
        /// <summary>
        /// The eventgallery sort helper
        /// </summary>
        private ISortHelper<EventGalleryResponse> eventgallerySortHelper;

        /// <summary>
        /// The eventgallery data shaper/
        /// </summary>
        private IDataShaper<EventGalleryResponse> eventgalleryDataShaper;

        /// <summary>
        /// The service offersort helper
        /// </summary>
        ISortHelper<ServiceOfferResponse> serviceOffersortHelper;

        /// <summary>
        /// The service offerdata shaper
        /// </summary>
        IDataShaper<ServiceOfferResponse> serviceOfferdataShaper;

        /// <summary>
        /// The service question helper
        /// </summary>
        ISortHelper<ServiceQuestionResponse> serviceQuestionsortHelper;

        /// <summary>
        /// The service question shaper
        /// </summary>
        IDataShaper<ServiceQuestionResponse> serviceQuestiondataShaper;

        /// <summary>
        /// The service answersort helper
        /// </summary>
        ISortHelper<ServiceAnswerResponse> serviceAnswersortHelper;

        /// <summary>
        /// The service answerdata shaper
        /// </summary>
        IDataShaper<ServiceAnswerResponse> serviceAnswerdataShaper;

        private ISortHelper<ProfilePictureResponse> profilePictureSortHelper;

        /// <summary>
        /// The service answerdata shaper
        /// </summary>
        private IDataShaper<CategoryDetailsResponse> categoryDetailsDataShaper;

        private ISortHelper<CategoryDetailsResponse> categoryDetailsSortHelper;

        private ISortHelper<VendorQuestionAnswerResponse> vendorQuestionAnswerSortHelper;

        private IDataShaper<VendorQuestionAnswerResponse> vendorQuestionAnswerDataShaper;

        private ISortHelper<BranchResponse> branchSortHelper;
        private IDataShaper<BranchResponse> branchDataShaper;
        private ISortHelper<BranchServiceResponse> branchServiceSortHelper;
        private IDataShaper<BranchServiceResponse> branchServiceDataShaper;

        /// <summary>
        /// Gets the stroies.
        /// </summary>
        public ISubscriptionPlansRepository SubscriptionPlans
        {
            get
            {
                if (subscriptionsPlans == null)
                {
                    subscriptionsPlans = new SubscriptionPlansRepository(repositoryContext, mapper, subscriptionsPlansSortHelper, subscriptionsPlansDataShaper);
                }
                return subscriptionsPlans;
            }
        }
        public IsubscriptionBenefitRepository SubscriptionBenefits
        {
            get
            {
                if (subscriptionBenefits == null)
                {
                    subscriptionBenefits = new SubscriptionBenefitsRepository(repositoryContext, mapper, subscriptionsBenefitsSortHelper, subscriptionsBenefitsDataShaper);
                }
                return subscriptionBenefits;
            }
        }
        //public ISubsBenefitRepository SubsBenefits
        //{
        //    get
        //    {
        //        if (subsBenefits == null)
        //        {
        //            subsBenefits = new SubsBenefitRepository(repositoryContext, mapper, subsBenefitsSortHelper, subsBenefitsDataShaper);
        //        }
        //        return subsBenefits;
        //    }
        //}
        public ISubscriptionOfferRepository SubscriptionOffers
        {
            get
            {
                if (subscriptionOffers == null)
                {
                    subscriptionOffers = new SubscriptionOffersRepository(repositoryContext, mapper, subscriptionsOffersSortHelper, subscriptionsOffersDataShaper);
                }
                return subscriptionOffers;
            }
        }
        public IServiceSubscriptionRepository ServiceSubscriptions
        {
            get
            {
                if (serviceSubscriptions == null)
                {
                    serviceSubscriptions = new ServiceSubscriptionsRepository(repositoryContext, mapper, serviceSubscriptionsSortHelper, serviceSubscriptionsDataShaper);
                }
                return serviceSubscriptions;
            }
        }
        public IWalletRepository Wallets
        {
            get
            {
                if (wallets == null)
                {
                    wallets = new WalletRepository(repositoryContext, mapper, walletsSortHelper, walletsDataShaper);
                }
                return wallets;
            }
        }
        public IUtilityRepository Utilitys
        {
            get
            {
                if (utility == null)
                {
                    utility = new UtilityRepository(repositoryContext, mapper, utilitySortHelper, utilityDataShaper);
                }
                return utility;
            }
        }

        public ICommentReplyRepository CommentReply
        {
            get
            {
                if (commentReply == null)
                {
                    commentReply = new CommentReplyRepository(repositoryContext, mapper, commentReplySortHelper, commentReplyDataShaper);
                }
                return commentReply;
            }
        }
        public IAverageRatingRepository AverageRatings
        {
            get
            {
                if (averageRatings == null)
                {
                    averageRatings = new AverageRatingRepository(repositoryContext, mapper, reviewsSortHelper, reviewsDataShaper);
                }
                return averageRatings;
            }
        }
        public IReplyCountRepository ReplyCounts
        {
            get
            {
                if (replyCounts == null)
                {
                    replyCounts = new ReplyCountRepository(repositoryContext, mapper, commentReplySortHelper, commentReplyDataShaper);
                }
                return replyCounts;
            }
        }
        public ITopUpRepository TopUps
        {
            get
            {
                if (topUps == null)
                {
                    topUps = new TopUpRepository(repositoryContext, mapper, topUpsSortHelper, topUpsDataShaper);
                }
                return topUps;
            }
        }
        public ITopUpBenefitRepository TopUpBenefits
        {
            get
            {
                if (topUpBenefits == null)
                {
                    topUpBenefits = new TopUpBenefitRepository(repositoryContext, mapper, topUpBenefitsSortHelper, topUpBenefitsDataShaper);
                }
                return topUpBenefits;
            }
        }
        public IServiceTopupRepository ServiceTopups
        {
            get
            {
                if (serviceTopups == null)
                {
                    serviceTopups = new ServiceTopupRepository(repositoryContext, mapper, serviceTopupsSortHelper, serviceTopupsDataShaper);
                }
                return serviceTopups;
            }
        }
        public ISuggestionListRepository SuggestionLists
        {
            get
            {
                if (suggestionLists == null)
                {
                   suggestionLists = new SuggestionListRepository(repositoryContext, mapper, suggestionListsSortHelper, suggestionListsDataShaper);
                }
                return suggestionLists;
            }
        }
        public IReviewRepository Reviews
        {
            get
            {
                if (reviews == null)
                {
                    reviews = new ReviewRepository(repositoryContext, mapper, reviewsSortHelper, reviewsDataShaper);
                }
                return reviews;
            }
        }
        public IOffersRepository Offers
        {
            get
            {
                if (offers == null)
                {
                    offers = new OfferRepository(repositoryContext, mapper, offerSortHelper, offerDataShaper);
                }
                return offers;
            }
        }
        public IAssetRepository AssetRepository
        {
            get
            {
                if (assets == null)
                {
                    assets = new AssetRepository(repositoryContext, mapper, assetSortHelper, assetDataShaper);
                }
                return assets;
            }
        }
        public IBenefitsRepository Benefits
        {
            get
            {
                if (benefits == null)
                {
                    benefits = new BenefitRepository(repositoryContext, mapper, benefitSortHelper, benefitDataShaper);
                }
                return benefits;
            }
        }

        /// <summary>
        /// Gets the multicode.
        /// </summary>
        public IMultiCodeRepository MultiCodes
        {
            get
            {
                if (multiCode == null)
                {
                    multiCode = new MultiCodeRepository(repositoryContext, mapper, multicodeSortHelper, multicodeDataShaper);
                }
                return multiCode;
            }
        }

        /// <summary>
        /// Gets the multidetail.
        /// </summary>
        public IMultiDetailRepository MultiDetails
        {
            get
            {
                if (multidetail == null)
                {
                    multidetail = new MultiDetailRepository(repositoryContext, mapper, multidetailSortHelper, multidetailDataShaper);
                }
                return multidetail;
            }
        }

        /// <summary>
        /// Gets the event.
        /// </summary>
        public IEventRepository Events
        {
            get
            {
                if (events == null)
                {
                    events = new EventRepository(repositoryContext, mapper, eventsSortHelper, eventsDataShaper);
                }
                return events;
            }
        }

        public IServiceRepository ServiceRepository
        {
            get
            {
                if (services == null)
                {
                    services = new ServiceRepository(repositoryContext, mapper, servicesSortHelper, servicesDataShaper);
                }
                return services;
            }
        }
        public ISubscriptionLocationRepository SubscriptionLocations
        {
            get
            {
                if (subscriptionLocations == null)
                {
                    subscriptionLocations = new SubscriptionLocationRepository(repositoryContext, mapper, subscriptionLocationsSortHelper, subscriptionLocationsDataShaper);
                }
                return subscriptionLocations;
            }
        }
        public IEventGalleryRepository EventGallery
        {
            get
            {
                if (eventGallery == null)
                {
                    eventGallery = new EventGalleryRepository(repositoryContext, mapper, eventgallerySortHelper, eventgalleryDataShaper);
                }
                return eventGallery;
            }
        }

        public IServiceOfferRepository ServiceOffer
        {
            get
            {
                if (serviceOffer == null)
                {
                    serviceOffer = new ServiceOfferRepository(repositoryContext, mapper, serviceOffersortHelper, serviceOfferdataShaper);
                }
                return serviceOffer;
            }
        }

        public IServiceQuestionRepository ServiceQuestion
        {
            get
            {
                if (serviceQuestion == null)
                {
                    serviceQuestion = new ServiceQuestionRepository(repositoryContext, mapper, serviceQuestionsortHelper, serviceQuestiondataShaper);
                }
                return serviceQuestion;
            }
        }

        public IServiceAnswerRepository ServiceAnswer
        {
            get
            {
                if (serviceAnswer == null)
                {
                    serviceAnswer = new ServiceAnswerRepository(repositoryContext, mapper, serviceAnswersortHelper, serviceAnswerdataShaper);
                }
                return serviceAnswer;
            }
        }

        public IProfilePictureRepository ProfilePicture
        {
            get
            {
                if (profilePicture == null)
                {
                    profilePicture = new ProfilePictureRepository(repositoryContext, mapper, profilePictureSortHelper, profilePictureDataShaper);
                }
                return profilePicture;
            }
        }

        public ICategoryDetailsRepository CategoryDetails
        {
            get
            {
                if (categoryDetails == null)
                {
                    categoryDetails = new CategoryDetailsRepository(repositoryContext, mapper, categoryDetailsSortHelper, categoryDetailsDataShaper);
                }
                return categoryDetails;
            }
        }

        public IVendorQuestionAnswerRepository VendorQuestionAnswer
        {
            get
            {
                if (vendorQuestionAnswer == null)
                {
                    vendorQuestionAnswer = new VendorQuestionAsnwerRepository(repositoryContext, mapper, vendorQuestionAnswerSortHelper, vendorQuestionAnswerDataShaper);
                }
                return vendorQuestionAnswer;
            }
        }

        public IBranchRepository Branch
        {
            get
            {
                if (branch == null)
                {
                    branch = new BranchRepository(repositoryContext, mapper, branchSortHelper, branchDataShaper);
                }
                return branch;
            }
        }
        public IBranchServiceRepository BranchService
        {
            get
            {
                if (branchService == null)
                {
                    branchService = new BranchServiceRepository(repositoryContext, mapper, branchServiceSortHelper, branchServiceDataShaper);
                }
                return branchService;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryWrapper" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="multicodeSortHelper">The multicode sort helper.</param>
        /// <param name="multicodeDataShaper">The multicode data shaper.</param>
        /// <param name="multidetailSortHelper">The multidetail sort helper.</param>
        /// <param name="multidetailDataShaper">The mutlidetail data shaper.</param>
        /// <param name="eventsSortHelper">The event sort helper.</param>
        /// <param name="eventsDataShaper">The event data shaper.</param>
        /// <param name="eventgallerySortHelper">The event sort helper.</param>
        /// <param name="eventgalleryDataShaper">The event data shaper.</param>
        public RepositoryWrapper(
           VendorContext repositoryContext,
           IMapper mapper,
           ISortHelper<ServiceResponse> servicesSortHelper,
           IDataShaper<ServiceResponse> servicesDataShaper,
           ISortHelper<SubscriptionPlansResponse> subscriptionPlansSortHelper,
            IDataShaper<SubscriptionPlansResponse> subscriptionPlansDataShaper,
            ISortHelper<MultiCodeResponse> multicodeSortHelper,
            IDataShaper<MultiCodeResponse> multicodeDataShaper,
            ISortHelper<MultiDetailResponse> multidetailSortHelper,
            IDataShaper<MultiDetailResponse> multidetailDataShaper,
            ISortHelper<AssetResponse> assetSortHelper,
            IDataShaper<AssetResponse> assetDataShaper,
            ISortHelper<OffersResponse> offersSortHelper,
            IDataShaper<OffersResponse> offersDataShaper,
            ISortHelper<BenefitsResponse> benefitsSortHelper,
            IDataShaper<BenefitsResponse> benefitsDataShaper,
            ISortHelper<SubscriptionBenefitsResponse> subscriptionBenefitsSortHelper,
            IDataShaper<SubscriptionBenefitsResponse> subscriptionBenefitsDataShaper,
            ISortHelper<SubsBenefitDataResponse> subsBenefitsSortHelper,
            IDataShaper<SubsBenefitDataResponse> subsBenefitsDataShaper,
            ISortHelper<SubscriptionOfferResponse> subscriptionOffersSortHelper,
            IDataShaper<SubscriptionOfferResponse> subscriptionOffersDataShaper,
           ISortHelper<TopUpsResponse> topUpsSortHelper,
            IDataShaper<TopUpsResponse> topUpsDataShaper,
           ISortHelper<ServiceTopupResponse> serviceTopupsSortHelper,
            IDataShaper<ServiceTopupResponse> serviceTopupsDataShaper,
           ISortHelper<TopUpBenefitResponse> topUpBenefitsSortHelper,
            IDataShaper<TopUpBenefitResponse> topUpBenefitsDataShaper,
            ISortHelper<SuggestionListResponse> suggestionListsSortHelper,
            IDataShaper<SuggestionListResponse> suggestionListsDataShaper,
           ISortHelper<EventResponse> eventsSortHelper,
           IDataShaper<EventResponse> eventsDataShaper,
           ISortHelper<ReviewsResponse> reviewsSortHelper,
           IDataShaper<ReviewsResponse> reviewsDataShaper,
           ISortHelper<CommentReplyResponse> commentReplySortHelper,
           IDataShaper<CommentReplyResponse> commentReplyDataShaper,
           ISortHelper<EventGalleryResponse> eventgallerySortHelper,
           IDataShaper<EventGalleryResponse> eventgalleryDataShaper,
           ISortHelper<ServiceSubscriptionsResponse> serviceSubscriptionsSortHelper,
            IDataShaper<ServiceSubscriptionsResponse> serviceSubscriptionsDataShaper,
            ISortHelper<ServiceOfferResponse> serviceOffersortHelper,
            IDataShaper<ServiceOfferResponse> serviceOfferdataShaper,
           ISortHelper<WalletResponse> walletsSortHelper,
            IDataShaper<WalletResponse> walletsDataShaper,
           ISortHelper<SubscriptionLocationResponse> subscriptionLocationsSortHelper,
            IDataShaper<SubscriptionLocationResponse> subscriptionLocationsDataShaper,
             ISortHelper<ServiceQuestionResponse> serviceQuestionsortHelper,
             IDataShaper<ServiceQuestionResponse> serviceQuestiondataShaper,
             ISortHelper<ServiceAnswerResponse> serviceAnswersortHelper,
             IDataShaper<ServiceAnswerResponse> serviceAnswerdataShaper,
               ISortHelper<ProfilePictureResponse> profilePictureSortHelper,
             IDataShaper<ProfilePictureResponse> profilePictureDataShaper,
              ISortHelper<CategoryDetailsResponse> categoryDetailsSortHelper,
            IDataShaper<CategoryDetailsResponse> categoryDetailsDataShaper,
             ISortHelper<VendorQuestionAnswerResponse> vendorQuestionAnswerSortHelper,
            IDataShaper<VendorQuestionAnswerResponse> vendorQuestionAnswerDataShaper,
            ISortHelper<BranchResponse> branchSortHelper,
            IDataShaper<BranchResponse> branchDataShaper,
             ISortHelper<BranchServiceResponse> branchServiceSortHelper,
            IDataShaper<BranchServiceResponse> branchServiceDataShaper,
            ISortHelper<UtilityResponse> utilitySortHelper,
            IDataShaper<UtilityResponse> utilityDataShaper
           )
        {
            this.repositoryContext = repositoryContext;
            this.mapper = mapper;
            this.servicesSortHelper = servicesSortHelper;
            this.servicesDataShaper = servicesDataShaper;
            this.subscriptionsPlansSortHelper = subscriptionPlansSortHelper;
            this.subscriptionsPlansDataShaper = subscriptionPlansDataShaper;
            this.multicodeSortHelper = multicodeSortHelper;
            this.multicodeDataShaper = multicodeDataShaper;
            this.multidetailSortHelper = multidetailSortHelper;
            this.multidetailDataShaper = multidetailDataShaper;
            this.assetSortHelper = assetSortHelper;
            this.assetDataShaper = assetDataShaper;
            this.offerSortHelper = offersSortHelper;
            this.offerDataShaper = offersDataShaper;
            this.benefitSortHelper = benefitsSortHelper;
            this.benefitDataShaper = benefitsDataShaper;
            this.subscriptionsBenefitsSortHelper = subscriptionBenefitsSortHelper;
            this.subscriptionsBenefitsDataShaper = subscriptionBenefitsDataShaper;
            this.subsBenefitsSortHelper = subsBenefitsSortHelper;
            this.subsBenefitsDataShaper = subsBenefitsDataShaper;
            this.subscriptionsOffersSortHelper = subscriptionOffersSortHelper;
            this.subscriptionsOffersDataShaper = subscriptionOffersDataShaper;
            this.topUpsSortHelper = topUpsSortHelper;
            this.topUpBenefitsDataShaper = topUpBenefitsDataShaper;
            this.topUpBenefitsSortHelper = topUpBenefitsSortHelper;
            this.suggestionListsDataShaper = suggestionListsDataShaper;
            this.suggestionListsSortHelper = suggestionListsSortHelper;
            this.topUpsDataShaper = topUpsDataShaper;
            this.eventsSortHelper = eventsSortHelper;
            this.eventsDataShaper = eventsDataShaper;
            this.reviewsSortHelper = reviewsSortHelper;
            this.reviewsDataShaper = reviewsDataShaper;
            this.commentReplySortHelper = commentReplySortHelper;
            this.commentReplyDataShaper = commentReplyDataShaper;
            this.eventgallerySortHelper = eventgallerySortHelper;
            this.eventgalleryDataShaper = eventgalleryDataShaper;
            this.serviceSubscriptionsSortHelper = serviceSubscriptionsSortHelper;
            this.serviceSubscriptionsDataShaper = serviceSubscriptionsDataShaper;
            this.serviceTopupsSortHelper = serviceTopupsSortHelper;
            this.serviceTopupsDataShaper = serviceTopupsDataShaper;
            this.serviceOffersortHelper = serviceOffersortHelper;
            this.serviceOfferdataShaper = serviceOfferdataShaper;
            this.walletsSortHelper = walletsSortHelper;
            this.walletsDataShaper = walletsDataShaper;
            this.subscriptionLocationsSortHelper = subscriptionLocationsSortHelper;
            this.subscriptionLocationsDataShaper = subscriptionLocationsDataShaper;
            this.serviceQuestionsortHelper = serviceQuestionsortHelper;
            this.serviceQuestiondataShaper = serviceQuestiondataShaper;
            this.serviceAnswersortHelper = serviceAnswersortHelper;
            this.serviceAnswerdataShaper = serviceAnswerdataShaper;
            this.profilePictureSortHelper = profilePictureSortHelper;
            this.profilePictureDataShaper = profilePictureDataShaper;
            this.categoryDetailsSortHelper = categoryDetailsSortHelper;
            this.categoryDetailsDataShaper = categoryDetailsDataShaper;
            this.vendorQuestionAnswerSortHelper = vendorQuestionAnswerSortHelper;
            this.vendorQuestionAnswerDataShaper = vendorQuestionAnswerDataShaper;
            this.branchSortHelper = branchSortHelper;
            this.branchDataShaper = branchDataShaper;
            this.branchServiceSortHelper = branchServiceSortHelper;
            this.branchServiceDataShaper = branchServiceDataShaper;
            this.utilitySortHelper = utilitySortHelper;
            this.utilityDataShaper = utilityDataShaper;
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await repositoryContext.SaveChangesAsync() >= 0;
        }

    }
}
