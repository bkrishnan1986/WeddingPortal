import { CompanyDistricts } from './company-districts.model';
import { ProfilePermission } from './profile-permission.model';

export class AddUser {
    profileId: string;
    firstName: string;
    lastName: string;
    primaryMobileNumber: string;
    email: string;
    country: number;
    state: number;
    gender: number;
    address: string;
    photo: string;
    role: number;
    userId: string;
    employeeId: string;
    companyDistricts: CompanyDistricts[];
    profilePermission: ProfilePermission[];
    userName: string;
    password: string;
    companyName: string;
    companyCode: string;
    companyLogo: string;
    approvalStatus: number;
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
    companyPincode: string;
    createdBy: number;
}
