using System;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Core.Entity
{
    /// <summary>
    ///  This class is used to map MultiDetail Entity
    /// </summary>
    public partial class Multidetail
    {
        public Multidetail()
        {
            AssetAssetConditionNavigation = new HashSet<Assets>();
            AssetAssetTypeNavigation = new HashSet<Assets>();
            AssetStatusNavigation = new HashSet<Assets>();
            AssetUnitNavigation = new HashSet<Assets>();
            Benefit = new HashSet<Benefits>();
            Branches = new HashSet<Branches>();
            Branchserviceoffered = new HashSet<Branchserviceoffered>();
            EventApprovalStatusNavigation = new HashSet<Events>();
            EventEventTypeNavigation = new HashSet<Events>();
            OfferTypeNavigation = new HashSet<Offers>();
            OfferValidityUnitNavigation = new HashSet<Offers>();
            OfferConditionsNavigation = new HashSet<Offers>();
            ReviewApprovalStatusNavigation = new HashSet<Review>();
            ReviewReviewTypeNavigation = new HashSet<Review>();
            ServiceCurrencyNavigation = new HashSet<Services>();
            ServiceExperienceUnitNavigation = new HashSet<Services>();
            ServiceLocation = new HashSet<Services>();
            ServiceRateTypeNavigation = new HashSet<Services>();
            ServiceServiceTypeNavigation = new HashSet<Services>();
            Serviceanswer = new HashSet<Serviceanswer>();
            Servicequestion = new HashSet<Servicequestion>();
            SubscriptionApprovalStatusNavigation = new HashSet<Subscription>();
            SubscriptionValidityUnitNavigation = new HashSet<Subscription>();
            SubscriptionModeNavigation = new HashSet<Subscription>();
            ServicesubscriptionApprovalStatusNavigation = new HashSet<Servicesubscription>();
            ServicesubscriptionPaymentStatusNavigation = new HashSet<Servicesubscription>();
            Subscriptionoffer = new HashSet<Subscriptionoffer>();
            Subcategory = new HashSet<Subcategory>();
            Serviceoffered = new HashSet<Serviceoffered>();
            ServicetopupApprovalStatusNavigation = new HashSet<Servicetopup>();
            ServicetopupPaymentStatusNavigation = new HashSet<Servicetopup>();
            SubscriptionbenefitApprovalStatusNavigation = new HashSet<Subscriptionbenefit>();
            SubscriptionbenefitBenefitNavigation = new HashSet<Subscriptionbenefit>();
            Suggestionlist = new HashSet<Suggestionlist>();
            CommentreplyApprovalStatusNavigation = new HashSet<Commentreply>();
            ReviewApprovalStatusNavigation = new HashSet<Review>();
            ReviewReviewTypeNavigation = new HashSet<Review>();
            Commentreply = new HashSet<Commentreply>();
            TopupbenefitApprovalStatusNavigation = new HashSet<Topupbenefit>();
            TopupbenefitBenefitNavigation = new HashSet<Topupbenefit>();
            Wallet = new HashSet<Wallet>();
            SubscriptionlocationCategory = new HashSet<Subscriptionlocation>();
            SubscriptionlocationLocation = new HashSet<Subscriptionlocation>();
            SubscriptionlocationModeNavigation = new HashSet<Subscriptionlocation>();
            SubscriptionlocationPackageTypeNavigation = new HashSet<Subscriptionlocation>();
            TopupModeNavigation = new HashSet<Topup>();
            TopupTopUpTypeNavigation = new HashSet<Topup>();
            Vendorserviceutilisation = new HashSet<Vendorserviceutilisation>();
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the multi code identifier.
        /// </summary>
        /// <value>
        /// The multi code identifier.
        /// </value>
        public int MultiCodeId { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        public DateTime? UpdatedAt { get; set; }

        public virtual Multicode MultiCode { get; set; }
        public virtual ICollection<Assets> AssetAssetConditionNavigation { get; set; }
        public virtual ICollection<Assets> AssetAssetTypeNavigation { get; set; }
        public virtual ICollection<Assets> AssetStatusNavigation { get; set; }
        public virtual ICollection<Assets> AssetUnitNavigation { get; set; }
        public virtual ICollection<Benefits> Benefit { get; set; }
        public virtual ICollection<Branches> Branches { get; set; }
        public virtual ICollection<Branchserviceoffered> Branchserviceoffered { get; set; }
        public virtual ICollection<Commentreply> CommentreplyApprovalStatusNavigation { get; set; }
        public virtual ICollection<Commentreply> CommentreplyTypeNavigation { get; set; }
        public virtual ICollection<Events> EventApprovalStatusNavigation { get; set; }
        public virtual ICollection<Events> EventEventTypeNavigation { get; set; }
        public virtual ICollection<Services> ServiceLocation { get; set; }
        public virtual ICollection<Offers> OfferTypeNavigation { get; set; }
        public virtual ICollection<Offers> OfferValidityUnitNavigation { get; set; }
        public virtual ICollection<Offers> OfferConditionsNavigation { get; set; }
        public virtual ICollection<Review> ReviewApprovalStatusNavigation { get; set; }
        public virtual ICollection<Review> ReviewReviewTypeNavigation { get; set; }
        public virtual ICollection<Services> ServiceCurrencyNavigation { get; set; }
        public virtual ICollection<Services> ServiceExperienceUnitNavigation { get; set; }
        public virtual ICollection<Services> ServiceRateTypeNavigation { get; set; }
        public virtual ICollection<Services> ServiceServiceTypeNavigation { get; set; }
        public virtual ICollection<Serviceanswer> Serviceanswer { get; set; }
        public virtual ICollection<Servicequestion> Servicequestion { get; set; }
        public virtual ICollection<Serviceoffered> Serviceoffered { get; set; }
        public virtual ICollection<Suggestionlist> Suggestionlist { get; set; }
        public virtual ICollection<Subscriptionlocation> SubscriptionlocationLocation { get; set; }
        public virtual ICollection<Commentreply> Commentreply { get; set; }
        public virtual ICollection<Subscription> SubscriptionApprovalStatusNavigation { get; set; }
        public virtual ICollection<Subscription> SubscriptionValidityUnitNavigation { get; set; }
        public virtual ICollection<Subscription> SubscriptionModeNavigation { get; set; }
        public virtual ICollection<Subscriptionbenefit> SubscriptionbenefitApprovalStatusNavigation { get; set; }
        public virtual ICollection<Subscriptionbenefit> SubscriptionbenefitBenefitNavigation { get; set; }
        public virtual ICollection<Servicesubscription> ServicesubscriptionApprovalStatusNavigation { get; set; }
        public virtual ICollection<Servicesubscription> ServicesubscriptionPaymentStatusNavigation { get; set; }
        public virtual ICollection<Servicetopup> ServicetopupApprovalStatusNavigation { get; set; }
        public virtual ICollection<Servicetopup> ServicetopupPaymentStatusNavigation { get; set; }
        public virtual ICollection<Topupbenefit> TopupbenefitApprovalStatusNavigation { get; set; }
        public virtual ICollection<Topupbenefit> TopupbenefitBenefitNavigation { get; set; }
        public virtual ICollection<Subscriptionoffer> Subscriptionoffer { get; set; }
        public virtual ICollection<Wallet> Wallet { get; set; }
        public virtual ICollection<Subcategory> Subcategory { get; set; }
        public virtual ICollection<Subscriptionlocation> SubscriptionlocationCategory { get; set; }
        public virtual ICollection<Subscriptionlocation> SubscriptionlocationPackageTypeNavigation { get; set; }
        public virtual ICollection<Subscriptionlocation> SubscriptionlocationModeNavigation { get; set; }
        public virtual ICollection<Topup> TopupModeNavigation { get; set; }
        public virtual ICollection<Topup> TopupTopUpTypeNavigation { get; set; }

        public virtual ICollection<Vendorserviceutilisation> Vendorserviceutilisation { get; set; }
    }
}
