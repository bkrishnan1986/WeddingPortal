export class VendorProfile {
    profilepermission: Array<ProfilePermission>
    companyDistricts: Array<CompanyDistrict>;
    id: number;
    firstName: string;
    lastName: string;
    primaryMobileNumber: string;
    email: string;
    country: number;
    state: number;
    stateName:string;
    gender: number;
    address: string;
    photo: string;
    role: number;
    roleName:string;
    userName: string;
    password: string;
    aadhar: null;
    pan: null;
    bankAccountNumber: null;
    ifsc: null;
    companyName: string;
    companyCode: string;
    companyLogo: string;
    active: number;
    approvalStatus: number;
    approvalStatusName:string;
    createdBy: number;
    createdAt: string;
    updatedBy: null;
    updatedAt: null;
    secondaryMobileNumber: string;
    listingName: string;
    listingAddress: string;
    listingPincode: string;
    website: string;
    facebookLink: string;
    instagramLink: string;
    pintrestLink: string;
    twitterHandle: string;
    district: number;
    primaryContactPerson: string;
    companyPincode: string
}
export class ProfilePermission {
    id: number;
    profileId: number;
    roleId: number;
    profilePermissions: string;
    description: string;
    active: number;
    createdAt: string;
    createdBy: number;
    updatedAt: null;
    updatedBy: null
}
export class CompanyDistrict {
    id: number;
    profileId: number;
    district: number;
    districtName:string;
    active: number;
    createdAt: string
    createdBy: number;
    updatedAt: null;
    updatedBy: null
}