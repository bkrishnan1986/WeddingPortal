using Happy.Weddings.Gateway.Core.Domain.Vendor;

namespace Happy.Weddings.Gateway.Core.Messaging.Sender.v1.Vendor
{
    public interface IUpdateVendorStatusSender
    {
        void SendVendorStatus(VendorStatusList vendorStatus);
    }
}
