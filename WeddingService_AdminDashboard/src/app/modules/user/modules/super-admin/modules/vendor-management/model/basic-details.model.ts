export class BasicDetailsModel {
    id: number;
    vendorNo: string;
    companyName: string;
    primaryMobileNumber: number;
    secondaryMobileNumber: number;
    primaryContactPerson: string;
    role: string;
    email: string;
    companyAddress: string;
    companyLocation: string;
    companyPincode: number;
    listingName: string;
    listingAddress: string;
    location: string;
    pincode: number;
    googleProfileUrl: string;
    website: string;
    facebookLink: string;
    instagramLink: string;
    pintrestLink: string;
    twitterHandle: string;
    companyProfilePhoto: string;
    districtCity: any[] = [];
    category: [];
    profilePermission: any[] = [];
    metaCreatedBy: string;
    metaCreatedDT: Date;
}
