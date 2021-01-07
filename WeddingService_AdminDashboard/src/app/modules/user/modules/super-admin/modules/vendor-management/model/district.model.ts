import { BranchModel } from './branch.model';

export class DistrictModel {
    id: number;
    value: string;
    multiCodeId: number;
    tabList: BranchModel[] = [];
    keepContact: boolean;
    contactPerson: string;
    primaryMobNo: number;
    emailId: string;

}
