import { MultiDetailModel } from './multidetails.model';

export class CategoryDetails {
    profilePictures: Array<ProfilePictures>
    branchserviceoffered: Array<BranchesOffered>;
    multidetail: Array<MultiDetailModel>
    categoryId: number;
    categoryType: number;
    categoryName: string;
    vendorId: number;
    websiteLink: string;
    facebookLink: string;
    instagramLink: string;
    pinterestLink: string;
    twitterHandle: string;
    profilePicture: string;
    categoryMode: number;
    videoLink: null;
    active: number;
    createdBy: number;
    createdAt: string;
    uploadProfilePicture: string;
    profileImage: null;
    updatedBy: number;
    subCategory: Array<Subcategory>;
}
export class ProfilePictures {
    proflePictureId: number;
    profilePicturePath: string;
    createdBy: number;
    createdAt: string;
}
export class BranchesOffered {
    id: number;
    serviceId: number;
    serviceName: string;
    branchId: number;
    branchName: string;
    contactPerson: string;
    primaryMobileNumber: string;
    emailId: string;
    active: number;
    createdBy: number;
    createdAt: string;
    branches: Array<Branches>;
}
export class Branches {
    id: number;
    districtId: number;
    districtName: string;
    listingAddress: string;
    buildingName: string;
    flatPlotDoorNo: string;
    floor: string;
    streetName: string;
    localityName: string;
    pincode: string;
    landmark: string;
    latitude: string;
    longitude: string;
    establishedYear: number;
    active: number;
    createdBy: number;
    createdAt: string;
    updatedAt: string;
    multidetail: Array<MultiDetailModel>
}
export class Subcategory {
    categoryId: number;
    categoryValue: string;
    subCategoryType: number;
    subCategoryValue: string;
    active: number;
    createdBy: number;
    createdAt: string;
}