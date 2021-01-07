using Happy.Weddings.Gateway.Core.DTO;
using Happy.Weddings.Gateway.Core.DTO.Vendor.EventGallery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.Core.Services.v1.Vendor
{
    public interface IEventGalleryService
    {
        Task<APIResponse> GetEventGalleryByVendorId(EventGalleryParameters eventGalleryParameters);
    }
}
