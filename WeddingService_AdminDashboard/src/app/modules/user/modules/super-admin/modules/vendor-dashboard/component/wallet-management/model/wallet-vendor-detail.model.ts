export class WalletVendorDetails {
    locationId: number;
    locationName: string;
    vendorId: number;
    vendorName: string;
    vendorStatus: number;
    vendorStatusName: string;
    active: number;
    servicesubscription: servicesubscription[];
}

export class servicesubscription {
    id: number;
    vendorId: number;
    vendorName: string;
    vendorStatusName: string;
    locationId: number;
    locationName: string;
    serviceId: number;
    serviceName: string;
    subscription: number;
    subscriptionName: string;
    subscribedOn: Date;
    expiry: Date;
    paidAmount: number;
    paymentStatus: number;
    paymentStatusValue: string;
    walletBalance: number;
    walletStatus: number;
    walletStatusName: string;
    aprovalStatus: number;
    aprovalStatusValue: number;
    active: number;
    createdBy: number;
    createdAt: Date;
    updatedBy: number;
    updatedAt: Date;

}