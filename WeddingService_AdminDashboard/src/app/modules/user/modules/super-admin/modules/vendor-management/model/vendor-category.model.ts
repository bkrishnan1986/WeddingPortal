import { CategoryQuestionModel } from './category-question.model';

export class VendorCategoryModel {

    id: number;
    categoryId: number;
    categoryType: number;
    vendorId: string;
    vendorName: string;
    districtId: number;
    value: string;
    name: string;
    websiteLink: string;
    checkWebsiteLink: boolean;
    facebookLink: string;
    checkFacebookLink: boolean;
    instagramLink: string;
    checkInstagramLink: boolean;
    pinterestLink: string;
    checkPinterestLink: boolean;
    twitterHandle: string;
    checkTwitterHandle: boolean;
    profilePicture: string;
    createdBy: number;
    commissionMode: string;
    videolink: string;
    questions: CategoryQuestionModel[] = [];
    uploadPhotos: any[] = [];
    subCategory: any[] = [];
    profilePhoto: ProfileImage[] = [];
    ServiceType;
}
export class ProfileImage {
    profileImage: FormData;
}