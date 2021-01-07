import { Injectable } from '@angular/core';
import { CategoryModel } from '../model/category.model';
import { DistrictModel } from '../model/district.model';
import { BasicDetailsModel } from '../model/basic-details.model';
@Injectable({
  providedIn: 'root'
})
export class PartialSaveService {
  district;
  category;
  PartialBasicDetails: BasicDetailsModel;
  vendorId: number;
  vendorNO: string;
  branchResponse = [];
  constructor() { }

  saveBasicDetails(district: any[], category: any[]) {
    this.category = category;
    this.district = district;

  }
  saveBranchResponse(branchResponse: any[]) {
    this.branchResponse = branchResponse;
  }
  savePartialBasicDetails(obj: BasicDetailsModel) {
    this.PartialBasicDetails = obj;

  }
  saveVendorId(vendorId: number) {
    this.vendorId = vendorId;
  }
  saveVendorNo(vendorNo: string) {
    this.vendorNO = vendorNo;
  }
  getCategoryDistrict() {
    return this.district;
  }
  getCategory() {
    return this.category;
  }
  getVendorId() {
    return this.vendorId;
  }
  getVendorNo() {
    return  this.vendorNO;
  }
  getPartialBasicDetails() {
    return this.PartialBasicDetails;
  }
  getBranchResponse() {
    return this.branchResponse;
  }
}
