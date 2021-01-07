
import { GstDetailModel } from './gst-detail.model';
import { KycDetailsModel } from './kyc-details.model';

export class KycModel {
    kycid: number;
    kycstatus: number;
    fatherName: string;
    dob: Date;
    documentId: string;
    createdBy: number;

    gstdetailstring: string;
}
export class KycDashboardModel {
    id: number;
    kycid: number;
    kycName: string;
    vendorId: number;
    kycstatus: number;
    kycStatusName: string;
    fatherName: string;
    dob: Date;
    documentId: string;
    active: number;
    createdBy: string;
    createdAt: string;
    updatedBy: null;
    updatedAt: null;
    kycdetails: Array<KycDetailsModel>;
    gstdetails: Array<GstDetailModel>;
}