import { ContactListModel } from './contactList.model';

export class BranchModel {
    districtId: number;
    branchName: string;
    listingAddress: string;
    buildingName: string;
    flatPlotDoorNo: string;
    floor: string;
    streetName: string;
    localityName: string;
    pincode: number;
    landmark: string;
    latitude: string;
    longitude: string;
    establishedYear: number;
    branchServiceoffered: ContactListModel[] = [];
    active: number;
    createdBy: string;
    checklistingAddress: boolean;


}
