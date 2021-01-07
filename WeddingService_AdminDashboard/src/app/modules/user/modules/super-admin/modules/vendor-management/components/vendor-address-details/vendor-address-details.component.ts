import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { BranchModel } from '../../model/branch.model';
import { DistrictModel } from '../../model/district.model';
import { CategoryModel } from '../../model/category.model';
import { VendorManagmentService } from '../../service/vendor-managment.service';
import { PartialSaveService } from '../../service/partial-save.service';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { Constants } from 'src/app/shared/constants/constants';

@Component({
  selector: 'app-vendor-address-details',
  templateUrl: './vendor-address-details.component.html',
  styleUrls: ['./vendor-address-details.component.css']
})
export class VendorAddressDetailsComponent implements OnInit, OnDestroy {

  tabList = new Array<BranchModel>();
  districtList = new Array<DistrictModel>();
  categoryList = new Array<CategoryModel>();
  selectCategoryList = new Array<CategoryModel>();

  saveBranchDetailsSubscript: ISubscription;
  districtSubscript: ISubscription;

  identityDistrict = new Array<DistrictModel>();
  district = new Array<DistrictModel>();
  vendorDistrict = new Array<DistrictModel>();
  currentDistrictCount = 0;
  count = 0;
  currentDistrict: { id, value };
  keepContact: boolean;

  temp;
  constructor(
    private router: Router,
    private service: VendorManagmentService,
    private partialService: PartialSaveService
  ) { }

  ngOnInit(): void {
    this.keepContact = true;
    this.tabList.push({
      districtId: undefined,
      active: undefined,
      createdBy: undefined,
      branchName: undefined,
      listingAddress: undefined,
      buildingName: undefined,
      flatPlotDoorNo: undefined,
      floor: undefined,
      streetName: undefined,
      localityName: undefined,
      checklistingAddress: undefined,
      pincode: undefined,
      landmark: undefined,
      latitude: undefined,
      longitude: undefined,
      establishedYear: undefined,
      branchServiceoffered: []
    });

    this.identityDistrict = this.partialService.getCategoryDistrict();
    this.categoryList = this.partialService.getCategory();
    this.currentDistrict = this.districtList[0];
    this.categoryList.forEach(x => {
      x.expression = false;
    });
    // this.districtList.forEach(i => {
    //   i.tabList = this.tabList;
    // });

    this.districtSubscript = this.service.getAllVendorMultidetails(Constants.City)
      .subscribe((response) => {
        if (response) {
          this.district = response;
          this.district.forEach(x => {
            this.identityDistrict.forEach(y => {
              if (x.value === y.value) {
                this.districtList.push(x);
              }
            });
          });
          this.districtList[0].tabList = this.tabList;
          this.districtList[0].keepContact = true;

        }
      });
  }
  ngOnDestroy() {
    if (this.saveBranchDetailsSubscript) {
      this.saveBranchDetailsSubscript.unsubscribe();
    }
  }
  nextStep() {
    const objArray = { branches: [] };
    this.districtList[this.currentDistrictCount].tabList.forEach(x => {

      const params = new BranchModel();
      params.districtId = this.districtList[this.currentDistrictCount].id;
      params.createdBy = '1';
      params.establishedYear = Number(x.establishedYear);
      params.flatPlotDoorNo = x.flatPlotDoorNo;
      params.floor = x.floor;
      params.landmark = x.landmark;
      params.latitude = x.latitude;
      params.listingAddress = x.listingAddress;
      params.buildingName = x.buildingName;
      params.streetName = x.streetName;
      params.localityName = x.localityName;
      params.pincode = x.pincode;
      params.longitude = x.longitude;
      const array = [];
      x.branchServiceoffered.forEach(i => {
        if (this.districtList[this.currentDistrictCount].keepContact) {
          array.push({
            serviceId: i.id,
            contactPerson: this.districtList[this.currentDistrictCount].contactPerson,
            PrimaryMobileNumber: this.districtList[this.currentDistrictCount].primaryMobNo,
            emailId: this.districtList[this.currentDistrictCount].emailId,
          });
        } else {
          array.push({
            serviceId: i.id,
            contactPerson: i.contactPerson,
            PrimaryMobileNumber: i.primaryMobNo,
            emailId: i.emailId,
          });
        }
      });
      params.branchServiceoffered = array;
      objArray.branches.push(params);

    });

    this.currentDistrictCount = this.currentDistrictCount + 1;

    if (this.districtList.length > this.currentDistrictCount) {
      this.districtList[this.currentDistrictCount].keepContact = this.districtList[this.currentDistrictCount - 1].keepContact;
      this.districtList[this.currentDistrictCount + 1].tabList = [{
        districtId: undefined,
        active: undefined,
        createdBy: undefined,
        branchName: undefined,
        listingAddress: undefined,
        buildingName: undefined,
        flatPlotDoorNo: undefined,
        floor: undefined,
        checklistingAddress: undefined,
        streetName: undefined,
        localityName: undefined,
        pincode: undefined,
        landmark: undefined,
        latitude: undefined,
        longitude: undefined,
        establishedYear: undefined,
        branchServiceoffered: []

      }];
      this.currentDistrict = this.districtList[this.currentDistrictCount];


    } else {

      this.saveBranchDetailsSubscript = this.service.saveBranchDetails(objArray)
        .subscribe((response) => {
          if (response) {
            this.partialService.saveBranchResponse(response);
            this.router.navigate([`/app/superadmin/vendor-management/CategoryDetails`]);
          }
        });

    }

  }

  addTab() {
    this.count = this.count + 1;
    this.districtList[this.currentDistrictCount].tabList.push({
      districtId: undefined,
      active: undefined,
      createdBy: undefined,
      branchName: undefined,
      listingAddress: undefined,
      buildingName: undefined,
      flatPlotDoorNo: undefined,
      floor: undefined,
      checklistingAddress: undefined,
      streetName: undefined,
      localityName: undefined,
      pincode: undefined,
      landmark: undefined,
      latitude: undefined,
      longitude: undefined,
      establishedYear: undefined,
      branchServiceoffered: []

    });

  }

  removeTab() {
    this.districtList[this.currentDistrictCount].tabList.pop();
  }
  detectCheckBox(i) {

    this.categoryList[i].expression = !this.categoryList[i].expression;
    console.log(JSON.stringify(this.categoryList[i].expression));
  }
  calCategory(i) {

    this.districtList[this.currentDistrictCount].tabList[i].branchServiceoffered = [];
    this.selectCategoryList = [];
    this.categoryList.forEach(x => {
      if (x.expression === true) {
        this.districtList[this.currentDistrictCount].tabList[i].branchServiceoffered.push(x);
      }
    });


  }
  sameAsCompany(i) {

    this.districtList[this.currentDistrictCount].tabList[i].checklistingAddress = !this.districtList[this.currentDistrictCount].tabList[i].checklistingAddress;
    if (this.districtList[this.currentDistrictCount].tabList[i].checklistingAddress) {
      const obj = this.partialService.getPartialBasicDetails();
      this.districtList[this.currentDistrictCount].tabList[i].listingAddress = obj.companyAddress;
    }

  }
}
