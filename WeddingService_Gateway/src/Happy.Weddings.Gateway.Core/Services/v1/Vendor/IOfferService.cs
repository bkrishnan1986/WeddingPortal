using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Offers;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionOffers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IOfferService
    {
        Task<APIResponse> DeleteSubcriptionOffers(int subscriptionOffersId);
        Task<APIResponse> UpdateSubcriptionOffers(int subscriptionOffersId, UpdateSubscriptionOfferRequest request);
        Task<APIResponse> CreateSubcriptionOffers(CreateSubscriptionOfferRequest request);
        Task<APIResponse> GetSubcriptionOffer(int subscriptionOffersId);
        Task<APIResponse> GetSubcriptionOffers(SubscriptionOffersParameter subscriptionOffersParameters);
        Task<APIResponse> DeleteOffer(int offerId);
        Task<APIResponse> UpdateOffer(int offerId, UpdateOfferRequest request);
        Task<APIResponse> CreateOffer(CreateOfferRequest request);
        Task<APIResponse> GetOffer(int offerId);
        Task<APIResponse> GetOffers(OffersParameter offersParameters);
    }
}
