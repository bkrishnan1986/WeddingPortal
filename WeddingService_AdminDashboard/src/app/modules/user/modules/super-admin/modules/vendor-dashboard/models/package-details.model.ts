import { MultiDetailModel } from './multidetails.model';

export class PackageDetails {
    servicesubscription: Array<ServiceSubscription>;
    subscriptionLocation: Array<SubscriptionLocation>;
    subscriptionPlan: Array<SubscriptionPlan>
    subscriptionbenefit: Array<Subscriptionbenefit>
    servicetopup: Array<ServiceTopup>;
    topUp: Array<Topup>;
    topupbenefit: Array<Topup>;
    id: number;
    serviceType: number;
    serviceName: string;
    description: string;
    experience: number;
    experienceUnit: number;
    award: string;
    rateType: number;
    priceRangeStart: number;
    priceRangeEnd: number;
    currency: number;
    currencyName: string;
    vendorId: number;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: number;
    updatedAt: string
}
export class ServiceSubscription {
    id: number;
    serviceId: number;
    serviceName: string;
    subscription: number;
    subscriptionName: string;
    subscribedOn: string;
    expiry: string;
    paidAmount: number;
    paymentStatus: number;
    paymentStatusValue: string;
    valletBalance: number;
    aprovalStatus: number;
    aprovalStatusValue: string;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: string;
    updatedAt: string;

}
export class SubscriptionLocation {
    id: number;
    subscriptionId: number;
    locationId: number;
    locationName: string;
    categoryId: number;
    categoryName: string;
    packageType: number;
    packageName: string;
    mode: number;
    modeName: string;
    registrationFee: number;
    serviceFee: number;
    cgstRatePercentage: number;
    cgstamount: number;
    sgstRatePercentage: number;
    sgstamount: number;
    igstRatePercentage: number;
    igstamount: number;
    gstRatePercentage: number;
    gstamount: number;
    cplamount: number;
    commissionAmount: number;
    totalPrice: number;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: string;
    updatedAt: string;
}
export class SubscriptionPlan {
    id: number;
    parentsubscriptionId: number;
    name: string;
    description: string;
    mode: number;
    modeName: string;
    registrationFee: number;
    serviceFee: number;
    cgstRatePercentage: number;
    cgstamount: number;
    sgstRatePercentage: number;
    sgstamount: number;
    igstRatePercentage: number;
    igstamount: number;
    gstRatePercentage: number;
    gstamount: number;
    cplamount: number;
    commissionAmount: number;
    totalPrice: number;
    validity: number;
    validityUnit: number;
    validityUnitName: string;
    approvalStatus: number;
    approvalStatusName: string;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: string;
    updatedAt: string;
}
export class Subscriptionbenefit {
    id: number;
    subscriptionId: number;
    subscriptionValue: string;
    benefit: number;
    benefitValue: null;
    count: number;
    approvalStatus: number;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: null;
    updatedAt: null;
    multidetail: Array<MultiDetailModel>
}
export class ServiceTopup {
    id: number;
    serviceId: number;
    serviceName: string;
    topUpId: number;
    topUpName: string;
    topUpOn: string;
    expiry: string;
    paidAmount: number;
    paymentStatus: number;
    paymentStatusValue: string;
    valletBalance: number;
    approvalStatus: number;
    approvalStatusValue: string;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: null;
    updatedAt: null
}
export class Topup {
    id: number;
    topUpType: number;
    topUpTypeName: string;
    name: string;
    description: string;
    mode: number;
    modeName: string;
    price: number;
    cgstRatePercentage: number;
    cgstamount: number;
    sgstRatePercentage: number;
    sgstamount: number;
    igstRatePercentage: number;
    igstamount: number;
    gstRatePercentage: number;
    gstamount: number;
    cplamount: number;
    commissionAmount: number;
    totalPrice: number;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: null;
    updatedAt: null;
}
export class TopupBenefit {
    id: number;
    topUpId: number;
    topUpName: string;
    benefit: number;
    benefitName: string;
    count: number;
    approvalStatus: number;
    approvalStatusName: string;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedBy: null;
    updatedAt: null;
}