using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
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
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Infrastructure;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Happy.Weddings.Vendor.Data.Repository;
using Happy.Weddings.Vendor.Infrastructure;
using Happy.Weddings.Vendor.Service.Commands.v1.Asset;
using Happy.Weddings.Vendor.Service.Commands.v1.Benefits;
using Happy.Weddings.Vendor.Service.Commands.v1.Branch;
using Happy.Weddings.Vendor.Service.Commands.v1.CommentReply;
using Happy.Weddings.Vendor.Service.Commands.v1.Event;
using Happy.Weddings.Vendor.Service.Commands.v1.MultiCode;
using Happy.Weddings.Vendor.Service.Commands.v1.MultiDetail;
using Happy.Weddings.Vendor.Service.Commands.v1.Offers;
using Happy.Weddings.Vendor.Service.Commands.v1.ProfilePicture;
using Happy.Weddings.Vendor.Service.Commands.v1.Review;
using Happy.Weddings.Vendor.Service.Commands.v1.Service;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceAnswer;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceQuestion;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceSubscriptions;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceTopup;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionBenefits;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionLocation;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionOffers;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionPlans;
using Happy.Weddings.Vendor.Service.Commands.v1.SuggestionList;
using Happy.Weddings.Vendor.Service.Commands.v1.TopUp;
using Happy.Weddings.Vendor.Service.Commands.v1.TopUpBenefit;
using Happy.Weddings.Vendor.Service.Commands.v1.Utility;
using Happy.Weddings.Vendor.Service.Commands.v1.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Service.Commands.v1.Wallet;
using Happy.Weddings.Vendor.Service.Handlers.v1.Asset;
using Happy.Weddings.Vendor.Service.Handlers.v1.Benefit;
using Happy.Weddings.Vendor.Service.Handlers.v1.Branch;
using Happy.Weddings.Vendor.Service.Handlers.v1.CommentReply;
using Happy.Weddings.Vendor.Service.Handlers.v1.Event;
using Happy.Weddings.Vendor.Service.Handlers.v1.EventGallery;
using Happy.Weddings.Vendor.Service.Handlers.v1.MultiCode;
using Happy.Weddings.Vendor.Service.Handlers.v1.MultiDetail;
using Happy.Weddings.Vendor.Service.Handlers.v1.Offer;
using Happy.Weddings.Vendor.Service.Handlers.v1.ProfilePicture;
using Happy.Weddings.Vendor.Service.Handlers.v1.Reviews;
using Happy.Weddings.Vendor.Service.Handlers.v1.ServiceAnswer;
using Happy.Weddings.Vendor.Service.Handlers.v1.ServiceHandler;
using Happy.Weddings.Vendor.Service.Handlers.v1.ServiceQuestion;
using Happy.Weddings.Vendor.Service.Handlers.v1.ServiceSubscriptions;
using Happy.Weddings.Vendor.Service.Handlers.v1.ServiceTopup;
using Happy.Weddings.Vendor.Service.Handlers.v1.ServiceTopups;
using Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionBenefits;
using Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionLocation;
using Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionOffer;
using Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionPlan;
using Happy.Weddings.Vendor.Service.Handlers.v1.SubscriptionsPlan;
using Happy.Weddings.Vendor.Service.Handlers.v1.SuggestionLists;
using Happy.Weddings.Vendor.Service.Handlers.v1.TopUp;
using Happy.Weddings.Vendor.Service.Handlers.v1.TopUpBenefits;
using Happy.Weddings.Vendor.Service.Handlers.v1.Utility;
using Happy.Weddings.Vendor.Service.Handlers.v1.VedorQuestionAnswer;
using Happy.Weddings.Vendor.Service.Handlers.v1.VendorSubscriptions;
using Happy.Weddings.Vendor.Service.Handlers.v1.Wallets;
using Happy.Weddings.Vendor.Service.Helpers;
using Happy.Weddings.Vendor.Service.Queries.v1.Assets;
using Happy.Weddings.Vendor.Service.Queries.v1.Benefits;
using Happy.Weddings.Vendor.Service.Queries.v1.Branch;
using Happy.Weddings.Vendor.Service.Queries.v1.CommentReply;
using Happy.Weddings.Vendor.Service.Queries.v1.Event;
using Happy.Weddings.Vendor.Service.Queries.v1.EventGallery;
using Happy.Weddings.Vendor.Service.Queries.v1.MultiCode;
using Happy.Weddings.Vendor.Service.Queries.v1.MultiDetail;
using Happy.Weddings.Vendor.Service.Queries.v1.Offers;
using Happy.Weddings.Vendor.Service.Queries.v1.ProfilePicture;
using Happy.Weddings.Vendor.Service.Queries.v1.Review;
using Happy.Weddings.Vendor.Service.Queries.v1.Service;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceAnswer;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceQuestion;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceSubscriptions;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceTopup;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionBenefits;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionLocation;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionOffers;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionPlans;
using Happy.Weddings.Vendor.Service.Queries.v1.SuggesstionList;
using Happy.Weddings.Vendor.Service.Queries.v1.TopUp;
using Happy.Weddings.Vendor.Service.Queries.v1.TopUpBenefits;
using Happy.Weddings.Vendor.Service.Queries.v1.Utility;
using Happy.Weddings.Vendor.Service.Queries.v1.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Service.Queries.v1.Wallet;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace Happy.Weddings.Vendor.API.Extensions
{
    /// <summary>
    /// Extension for adding object injection lifetime
    /// </summary>
    public static class ServicesInjection
    {
        /// <summary>
        /// Adds the services injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="HostingEnvironment">The hosting environment.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddServicesInjection(this IServiceCollection services,
                                                                   IWebHostEnvironment HostingEnvironment,
                                                                   IConfiguration configuration)
        {
            //Configure logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var rabbitMQConfig = configuration.GetSection("RabbitMqConfig").Get<RabbitMqConfig>();

            services.AddSingleton(Log.Logger);
            services.AddSingleton(HostingEnvironment);
            services.AddSingleton(rabbitMQConfig);

            services.AddDbContext<VendorContext>(options =>
                 options.UseMySQL(configuration.GetConnectionString("Database")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMediatR(typeof(Startup));

            services.AddTransient<IRequestHandler<CreateServiceCommand, APIResponse>, AddServiceHandler>();
            services.AddTransient<IRequestHandler<UpdateServiceCommand, APIResponse>, UpdateServiceHandler>();
            services.AddTransient<IRequestHandler<DeleteServiceCommand, APIResponse>, DeleteServiceHandler>();
            services.AddTransient<IRequestHandler<GetAllServicesQuery, APIResponse>, GetAllServicesHandler>();
            services.AddTransient<IRequestHandler<SearchFromAllServicesQuery, APIResponse>, SearchFromAllServicesHandler>();
            services.AddTransient<IRequestHandler<GetServicesofVendorQuery, APIResponse>, GetServicesofVendorHandler>();

            services.AddTransient<IRequestHandler<CreateAssetCommand, APIResponse>, AddAssetHandler>();
            services.AddTransient<IRequestHandler<UpdateAssetCommand, APIResponse>, UpdateAssetHandler>();
            services.AddTransient<IRequestHandler<DeleteAssetCommand, APIResponse>, DeleteAssetHandler>();
            services.AddTransient<IRequestHandler<GetAllAssetsQuery, APIResponse>, GetAllAssetHandler>();
            services.AddTransient<IRequestHandler<GetAssetQuery, APIResponse>, GetAssetByIdHandler>();

            services.AddTransient<IRequestHandler<GetAllSubscriptionPlansQuery, APIResponse>, GetAllSubscriptionPlansHandler>();
            services.AddTransient<IRequestHandler<GetSubscriptionPlanQuery, APIResponse>, GetSubscriptionPlanHandler>();
            services.AddTransient<IRequestHandler<CreateSubscriptionPlanCommand, APIResponse>, CreateSubscriptionPlanHandler>();
            services.AddTransient<IRequestHandler<UpdateSubscriptionPlanCommand, APIResponse>, UpdateSubscriptionPlanHandler>();
            services.AddTransient<IRequestHandler<DeleteSubscriptionPlanCommand, APIResponse>, DeleteSubscriptionPlanHandler>();

            services.AddTransient<IRequestHandler<GetAllOffersQuery, APIResponse>, GetAllOffersHandler>();
            services.AddTransient<IRequestHandler<GetOfferQuery, APIResponse>, GetOfferHandler>();
            services.AddTransient<IRequestHandler<CreateOfferCommand, APIResponse>, CreateOfferHandler>();
            services.AddTransient<IRequestHandler<UpdateOfferCommand, APIResponse>, UpdateOfferHandler>();
            services.AddTransient<IRequestHandler<DeleteOfferCommand, APIResponse>, DeleteOfferHandler>();

            services.AddTransient<IRequestHandler<GetAllBenefitsQuery, APIResponse>, GetAllBenefitsHandler>();
            services.AddTransient<IRequestHandler<GetBenefitsQuery, APIResponse>, GetBenefitHandler>();
            services.AddTransient<IRequestHandler<CreateBenefitCommand, APIResponse>, CreateBenefitHandler>();
            services.AddTransient<IRequestHandler<UpdateBenefitsCommand, APIResponse>, UpdateBenefitHandler>();
            services.AddTransient<IRequestHandler<DeleteBenefitCommand, APIResponse>, DeleteBenefitHandler>();

            services.AddTransient<IRequestHandler<GetAllUtilityQuery, APIResponse>, GetAllUtilityHandler>();
            services.AddTransient<IRequestHandler<GetUtilityQuery, APIResponse>, GetUtilityHandler>();
            services.AddTransient<IRequestHandler<CreateUtilityCommand, APIResponse>, CreateUtilityHandler>();
            services.AddTransient<IRequestHandler<UpdateUtilityCommand, APIResponse>, UpdateUtilityHandler>();
            services.AddTransient<IRequestHandler<DeleteUtilityCommand, APIResponse>, DeleteUtilityHandler>();

            services.AddTransient<IRequestHandler<GetAllSubscriptionBenefitsQuery, APIResponse>, GetAllSubscriptionBenefitsHandler>();
            services.AddTransient<IRequestHandler<GetSubscriptionBenefitQuery, APIResponse>, GetSubscriptionBenefitHandler>();
            services.AddTransient<IRequestHandler<CreateSubscriptionBenefitCommand, APIResponse>, CreateSubscriptionBenefitHandler>();
            services.AddTransient<IRequestHandler<UpdateSubscriptionBenefitCommand, APIResponse>, UpdateSubscriptionBenefitHandler>();
            services.AddTransient<IRequestHandler<DeleteSubscriptionBenefitCommand, APIResponse>, DeleteSubscriptionBenefitHandler>();

            services.AddTransient<IRequestHandler<GetAllSubscriptionOffersQuery, APIResponse>, GetAllSubscriptionOffersHandler>();
            services.AddTransient<IRequestHandler<GetSubscriptionOfferQuery, APIResponse>, GetSubscriptionOfferHandler>();
            services.AddTransient<IRequestHandler<CreateSubscriptionOfferCommand, APIResponse>, CreateSubscriptionOfferHandler>();
            services.AddTransient<IRequestHandler<UpdateSubscriptionOfferCommand, APIResponse>, UpdateSubscriptionOfferHandler>();
            services.AddTransient<IRequestHandler<DeleteSubscriptionOfferCommand, APIResponse>, DeleteSubscriptionOfferHandler>();

            services.AddTransient<IRequestHandler<GetAllServiceSubscriptionsQuery, APIResponse>, GetAllServiceSubscriptionsHandler>();
            services.AddTransient<IRequestHandler<GetServiceSubscriptionQuery, APIResponse>, GetServiceSubscriptionHandler>();
            services.AddTransient<IRequestHandler<CreateServiceSubscriptioncommand, APIResponse>, CreateServiceSubscriptionHandler>();
            services.AddTransient<IRequestHandler<UpdateServiceSubscriptionCommand, APIResponse>, UpdateServiceSubscriptionHandler>();
            services.AddTransient<IRequestHandler<DeleteServiceSubscriptionCommand, APIResponse>, DeleteServiceSubscriptionHandler>();

            services.AddTransient<IRequestHandler<GetAllSubscriptionLocationsQuery, APIResponse>, GetAllSubscriptionLocationHandler>();
            services.AddTransient<IRequestHandler<GetSubscriptionLocationQuery, APIResponse>, GetSubscriptionLocationHandler>();
            services.AddTransient<IRequestHandler<CreateSubscriptionLocationCommand, APIResponse>, CreateSubscriptionLocationHandler>();
            services.AddTransient<IRequestHandler<UpdateSubscriptionLocationCommand, APIResponse>, UpdateSubscriptionLocationHandler>();
            services.AddTransient<IRequestHandler<DeleteSubscriptionLocationCommand, APIResponse>, DeleteSubscriptionLocationHandler>();

            services.AddTransient<IRequestHandler<GetAllTopUpQuery, APIResponse>, GetAllTopUpHandler>();
            services.AddTransient<IRequestHandler<GetTopUpQuery, APIResponse>, GetTopUpHandler>();
            services.AddTransient<IRequestHandler<CreateTopUpcommand, APIResponse>, CreateTopUpHandler>();
            services.AddTransient<IRequestHandler<UpdateTopUpCommand, APIResponse>, UpdateTopUpHandler>();
            services.AddTransient<IRequestHandler<DeleteTopUpCommand, APIResponse>, DeleteTopUpHandler>();

            services.AddTransient<IRequestHandler<GetAllTopUpBenefitsQuery, APIResponse>, GetAllTopUpBenefitHandler>();
            services.AddTransient<IRequestHandler<GetTopUpBenefitQuery, APIResponse>, GetTopUpBenefitHandler>();
            services.AddTransient<IRequestHandler<CreateTopUpBenefitCommand, APIResponse>, CreateTopUpBenefitHandler>();
            services.AddTransient<IRequestHandler<UpdateTopUpBenefitCommand, APIResponse>, UpdateTopUpBenefitHandler>();
            services.AddTransient<IRequestHandler<DeleteTopUpBenefitCommand, APIResponse>, DeleteTopUpBenefitHandler>();

            services.AddTransient<IRequestHandler<GetAllServiceTopupQuery, APIResponse>, GetAllServiceTopupHandler>();
            services.AddTransient<IRequestHandler<GetServiceTopupQuery, APIResponse>, GetServiceTopupHandler>();
            services.AddTransient<IRequestHandler<CreateServiceTopupCommand, APIResponse>, CreateServiceTopupHandler>();
            services.AddTransient<IRequestHandler<UpdateServiceTopupCommand, APIResponse>, UpdateServiceTopupHandler>();
            services.AddTransient<IRequestHandler<DeleteServiceTopupCommand, APIResponse>, DeleteServiceTopupHandler>();

            services.AddTransient<IRequestHandler<GetAllSuggestionListsQuery, APIResponse>, GetAllSuggestionListsHandler>();
            services.AddTransient<IRequestHandler<GetSuggestionListQuery, APIResponse>, GetSuggestionListHandler>();
            services.AddTransient<IRequestHandler<CreateSuggestionListCommand, APIResponse>, CreateSuggestionListHandler>();
            services.AddTransient<IRequestHandler<UpdateSuggestionListCommand, APIResponse>, UpdateSuggestionlistHandler>();
            services.AddTransient<IRequestHandler<DeleteSuggestionListCommand, APIResponse>, DeleteSuggestionListHandler>();

            services.AddTransient<IRequestHandler<GetAllReviewsQuery, APIResponse>, GetAllReviewsHandler>();
            services.AddTransient<IRequestHandler<GetReviewQuery, APIResponse>, GetReviewHandler>();
            services.AddTransient<IRequestHandler<CreateReviewCommand, APIResponse>, CreateReviewHandler>();
            services.AddTransient<IRequestHandler<UpdateReviewCommand, APIResponse>, UpdateReviewHandler>();
            services.AddTransient<IRequestHandler<DeleteReviewCommand, APIResponse>, DeleteReviewHandler>();

            services.AddTransient<IRequestHandler<GetAllCommentRepliesQuery, APIResponse>, GetAllCommentRepliesHandler>();
            services.AddTransient<IRequestHandler<GetCommentReplyQuery, APIResponse>, GetCommentReplyHandler>();
            services.AddTransient<IRequestHandler<GetAllCommentsQuery, APIResponse>, GetAllCommentsHandler>();
            services.AddTransient<IRequestHandler<CreateCommentReplyCommand, APIResponse>, CreateCommentReplyHandler>();
            services.AddTransient<IRequestHandler<UpdateCommentReplyCommand, APIResponse>, UpdateCommentReplyHandler>();
            services.AddTransient<IRequestHandler<DeleteCommentReplyCommand, APIResponse>, DeleteCommentReplyHandler>();     

            services.AddTransient<IRequestHandler<GetAllWalletsQuery, APIResponse>, GetAllWalletsHandler>();
            services.AddTransient<IRequestHandler<GetWalletQuery, APIResponse>, GetWalletHandler>();
            services.AddTransient<IRequestHandler<CreateWalletCommand, APIResponse>, CreateWalletHandler>();

            services.AddTransient<IRequestHandler<GetAllMultiCodesQuery, APIResponse>, GetAllMultiCodesHandler>();
            services.AddTransient<IRequestHandler<GetMultiCodeQuery, APIResponse>, GetMultiCodeHandler>();
            services.AddTransient<IRequestHandler<CreateMultiCodeCommand, APIResponse>, CreateMultiCodeHandler>();
            services.AddTransient<IRequestHandler<UpdateMultiCodeCommand, APIResponse>, UpdateMultiCodeHandler>();
            services.AddTransient<IRequestHandler<DeleteMultiCodeCommand, APIResponse>, DeleteMultiCodeHandler>();

            services.AddTransient<IRequestHandler<GetAllMultiDetailsQuery, APIResponse>, GetAllMultiDetailsHandler>();
            services.AddTransient<IRequestHandler<GetMultiDetailsByIdQuery, APIResponse>, GetMultiDetailHandler>();
            services.AddTransient<IRequestHandler<CreateMultiDetailsCommand, APIResponse>, CreateMultiDetailHandler>();
            services.AddTransient<IRequestHandler<UpdateMultiDetailsCommand, APIResponse>, UpdateMultiDetailHandler>();
            services.AddTransient<IRequestHandler<DeleteMultiDetailsCommand, APIResponse>, DeleteMultiDetailHandler>();

            services.AddTransient<IRequestHandler<GetEventsByConditionQuery, APIResponse>, GetEventByConditionHandler>();
            services.AddTransient<IRequestHandler<GetEventDetailsQueryByVendorId, APIResponse>, GetEventDetailsHandler>();
            services.AddTransient<IRequestHandler<GetEventQuery, APIResponse>, GetEventHandler>();
            services.AddTransient<IRequestHandler<CreateEventCommand, APIResponse>, CreateEventHandler>();
            services.AddTransient<IRequestHandler<UpdateEventCommand, APIResponse>, UpdateEventHandler>();
            services.AddTransient<IRequestHandler<DeleteEventCommand, APIResponse>, DeleteEventHandler>();

            services.AddTransient<IRequestHandler<GetAllEventGalleryByVendorIdQuery, APIResponse>, GetEventGalleryByVendorIdHandler>();

            services.AddTransient<IRequestHandler<GetAllServiceQuestionByServiceTypeQuery, APIResponse>, GetAllServiceQuestionsByServiceTypeHandler>();
            services.AddTransient<IRequestHandler<GetServiceQuestionsByIdQuery, APIResponse>, GetServiceQuestionsByIdHandler>();
            services.AddTransient<IRequestHandler<CreateServiceQuestionCommand, APIResponse>, CreateServiceQuestionHandler>();
            services.AddTransient<IRequestHandler<UpdateServiceQuestionCommand, APIResponse>, UpdateServiceQuestionHandler>();
            services.AddTransient<IRequestHandler<DeleteServiceQuestionCommand, APIResponse>, DeleteServiceQuestionHandler>();

            services.AddTransient<IRequestHandler<GetAllServiceAnswerByServiceQuestionQuery, APIResponse>, GetAllServiceAnswerByServiceQuestionIdHandler>();
            services.AddTransient<IRequestHandler<CreateServiceAnswerCommand, APIResponse>, CreateServiceAnswerHandler>();
            services.AddTransient<IRequestHandler<UpdateAnswerCommand, APIResponse>, UpdateServiceAnswerHandler>();
            services.AddTransient<IRequestHandler<DeleteServiceAnswerCommand, APIResponse>, DeleteServiceAnswerHandler>();

            services.AddTransient<IRequestHandler<GetAllVendorQuestionAnswersByIdQuery, APIResponse>, GetAllVendorQuestionAnswersByIdHandler>();
            services.AddTransient<IRequestHandler<CreateVendorQuestionAnswerCommand, APIResponse>, CreateVendorQuestionAnswerHandler>();
            services.AddTransient<IRequestHandler<UpdateVendorQuestionAnswerCommand, APIResponse>, UpdateVendorQuestionAnswerHandler>();
           // services.AddTransient<IRequestHandler<DeleteServiceAnswerCommand, APIResponse>, DeleteServiceAnswerHandler>();

            services.AddTransient<IRequestHandler<GetCategoryDetailsVendorIdQuery, APIResponse>, GetCategoryDetailsVendorIdHandler>();
            services.AddTransient<IRequestHandler<CreateProfielPictureCommand, APIResponse>, CreateProfilePictureHandler>();
            services.AddTransient<IRequestHandler<UpdateProfilePictureCommand, APIResponse>, UpdateProfilePictureHandler>();
            services.AddTransient<IRequestHandler<CreateCategoryDetailsCommand, APIResponse>, CreateCategoryDetailsHandler>();
            services.AddTransient<IRequestHandler<UpdateCategoryDetailsCommand, APIResponse>, UpdateCategoryDetailsHandler>();

            services.AddTransient<IRequestHandler<GetAllBranchesQuery, APIResponse>, GetAllBranchByIdHandler>();
            services.AddTransient<IRequestHandler<CreateBranchCommand, APIResponse>, CreateBranchHandler>();
            services.AddTransient<IRequestHandler<UpdateBranchCommand, APIResponse>, UpdateBranchHandler>();
            services.AddTransient<IRequestHandler<DeleteBranchCommand, APIResponse>, DeleteBranchHandler>();

            services.AddScoped<ISortHelper<SubscriptionPlansResponse>, SortHelper<SubscriptionPlansResponse>>();
            services.AddScoped<ISortHelper<OffersResponse>, SortHelper<OffersResponse>>();
            services.AddScoped<ISortHelper<BenefitsResponse>, SortHelper<BenefitsResponse>>();
            services.AddScoped<ISortHelper<SubscriptionBenefitsResponse>, SortHelper<SubscriptionBenefitsResponse>>();
            services.AddScoped<ISortHelper<SubsBenefitDataResponse>, SortHelper<SubsBenefitDataResponse>>();
            services.AddScoped<ISortHelper<ServiceSubscriptionsResponse>, SortHelper<ServiceSubscriptionsResponse>>();
            services.AddScoped<ISortHelper<ServiceTopupResponse>, SortHelper<ServiceTopupResponse>>();
            services.AddScoped<ISortHelper<TopUpsResponse>, SortHelper<TopUpsResponse>>();
            services.AddScoped<ISortHelper<TopUpBenefitResponse>, SortHelper<TopUpBenefitResponse>>();
            services.AddScoped<ISortHelper<SuggestionListResponse>, SortHelper<SuggestionListResponse>>();
            services.AddScoped<ISortHelper<SubscriptionOfferResponse>, SortHelper<SubscriptionOfferResponse>>();
            services.AddScoped<ISortHelper<WalletResponse>, SortHelper<WalletResponse>>();
            services.AddScoped<ISortHelper<ReviewsResponse>, SortHelper<ReviewsResponse>>();
            services.AddScoped<ISortHelper<CommentReplyResponse>, SortHelper<CommentReplyResponse>>();
            services.AddScoped<ISortHelper<MultiCodeResponse>, SortHelper<MultiCodeResponse>>();
            services.AddScoped<ISortHelper<MultiDetailResponse>, SortHelper<MultiDetailResponse>>();
            services.AddScoped<ISortHelper<EventResponse>, SortHelper<EventResponse>>();
            services.AddScoped<ISortHelper<EventGalleryResponse>, SortHelper<EventGalleryResponse>>();
            services.AddScoped<ISortHelper<ServiceOfferResponse>, SortHelper<ServiceOfferResponse>>();
            services.AddScoped<ISortHelper<SubscriptionLocationResponse>, SortHelper<SubscriptionLocationResponse>>();
            services.AddScoped<ISortHelper<ServiceQuestionResponse>, SortHelper<ServiceQuestionResponse>>();
            services.AddScoped<ISortHelper<ServiceAnswerResponse>, SortHelper<ServiceAnswerResponse>>();
            services.AddScoped<ISortHelper<ProfilePictureResponse>, SortHelper<ProfilePictureResponse>>();
            services.AddScoped<ISortHelper<CategoryDetailsResponse>, SortHelper<CategoryDetailsResponse>>();
            services.AddScoped<ISortHelper<VendorQuestionAnswerResponse>, SortHelper<VendorQuestionAnswerResponse>>();
            services.AddScoped<ISortHelper<BranchResponse>, SortHelper<BranchResponse>>();
            services.AddScoped<ISortHelper<BranchServiceResponse>, SortHelper<BranchServiceResponse>>();
            services.AddScoped<ISortHelper<UtilityResponse>, SortHelper<UtilityResponse>>();

            services.AddScoped<IDataShaper<SubscriptionPlansResponse>, DataShaper<SubscriptionPlansResponse>>();
            services.AddScoped<IDataShaper<OffersResponse>, DataShaper<OffersResponse>>();
            services.AddScoped<IDataShaper<BenefitsResponse>, DataShaper<BenefitsResponse>>();
            services.AddScoped<IDataShaper<SubscriptionBenefitsResponse>, DataShaper<SubscriptionBenefitsResponse>>();
            services.AddScoped<IDataShaper<SubsBenefitDataResponse>, DataShaper<SubsBenefitDataResponse>>();
            services.AddScoped<IDataShaper<ServiceSubscriptionsResponse>, DataShaper<ServiceSubscriptionsResponse>>();
            services.AddScoped<IDataShaper<ServiceTopupResponse>, DataShaper<ServiceTopupResponse>>();
            services.AddScoped<IDataShaper<TopUpsResponse>, DataShaper<TopUpsResponse>>();
            services.AddScoped<IDataShaper<TopUpBenefitResponse>, DataShaper<TopUpBenefitResponse>>();
            services.AddScoped<IDataShaper<SuggestionListResponse>, DataShaper<SuggestionListResponse>>();
            services.AddScoped<IDataShaper<WalletResponse>, DataShaper<WalletResponse>>();
            services.AddScoped<IDataShaper<ReviewsResponse>, DataShaper<ReviewsResponse>>();
            services.AddScoped<IDataShaper<CommentReplyResponse>, DataShaper<CommentReplyResponse >>();
            services.AddScoped<IDataShaper<SubscriptionOfferResponse>, DataShaper<SubscriptionOfferResponse>>();
            services.AddScoped<IDataShaper<MultiCodeResponse>, DataShaper<MultiCodeResponse>>();
            services.AddScoped<IDataShaper<MultiDetailResponse>, DataShaper<MultiDetailResponse>>();
            services.AddScoped<IDataShaper<EventGalleryResponse>, DataShaper<EventGalleryResponse>>();
            services.AddScoped<IDataShaper<ServiceOfferResponse>, DataShaper<ServiceOfferResponse>>();
            services.AddScoped<IDataShaper<SubscriptionLocationResponse>, DataShaper<SubscriptionLocationResponse>>();
            services.AddScoped<IDataShaper<ServiceQuestionResponse>, DataShaper<ServiceQuestionResponse>>();
            services.AddScoped<IDataShaper<ServiceAnswerResponse>, DataShaper<ServiceAnswerResponse>>();
            services.AddScoped<IDataShaper<ProfilePictureResponse>, DataShaper<ProfilePictureResponse>>();
            services.AddScoped<IDataShaper<CategoryDetailsResponse>, DataShaper<CategoryDetailsResponse>>();
            services.AddScoped<IDataShaper<VendorQuestionAnswerResponse>, DataShaper<VendorQuestionAnswerResponse>>();
            services.AddScoped<IDataShaper<BranchResponse>, DataShaper<BranchResponse>>();
            services.AddScoped<IDataShaper<BranchServiceResponse>, DataShaper<BranchServiceResponse>>();
            services.AddScoped<IDataShaper<UtilityResponse>, DataShaper<UtilityResponse>>();

            services.AddTransient<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<ISortHelper<ServiceResponse>, SortHelper<ServiceResponse>>();
            services.AddScoped<IDataShaper<ServiceResponse>, DataShaper<ServiceResponse>>();
            services.AddScoped<IDataShaper<Services>, DataShaper<Services>>();
            services.AddScoped<IDataShaper<EventResponse>, DataShaper<EventResponse>>();
            services.AddScoped<ISortHelper<AssetResponse>, SortHelper<AssetResponse>>();
            services.AddScoped<IDataShaper<AssetResponse>, DataShaper<AssetResponse>>();
            services.AddScoped<IDataShaper<Assets>, DataShaper<Assets>>();                             

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            return services;
        }
    }
}
