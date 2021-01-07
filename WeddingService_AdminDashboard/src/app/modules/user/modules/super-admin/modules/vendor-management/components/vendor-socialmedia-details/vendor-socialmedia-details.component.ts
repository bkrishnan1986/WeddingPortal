import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { BasicDetailsModel } from '../../model/basic-details.model';
import { DistrictModel } from '../../model/district.model';
import { CategoryModel } from '../../model/category.model';
import { VendorManagmentService } from '../../service/vendor-managment.service';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';
import { Constants } from 'src/app/shared/constants/constants';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { PartialSaveService } from '../../service/partial-save.service';

@Component({
  selector: 'app-vendor-socialmedia-details',
  templateUrl: './vendor-socialmedia-details.component.html',
  styleUrls: ['./vendor-socialmedia-details.component.css']
})
export class VendorSocialmediaDetailsComponent implements OnInit, OnDestroy {

  dropdownSettings: IDropdownSettings;

  categories = new Array<CategoryModel>();
  dist = new Array<DistrictModel>();
  districtOption = new Array<DistrictModel>();
  basicDetails: BasicDetailsModel;

  categorySubscript: ISubscription;
  districtSubscript: ISubscription;
  partSaveSubscript: ISubscription;
  getVendorNo: ISubscription;
  selectedDist;
  selectedCate;
  enableNext = true;
  formSubmitted = false;
  image: string;
  files: any[] = [];
  vendorNo: string;
  formData: FormData = new FormData();

  constructor(
    private router: Router,
    private service: VendorManagmentService,
    private partialService: PartialSaveService
  ) { }

  basicForm = new FormGroup({
    googleProfileUrl: new FormControl(),
    companyWebsite: new FormControl(),
    companyFacebookLink: new FormControl(),
    companyInstagramLink: new FormControl(),
    companyPinterestLink: new FormControl(),
    companyTwitterHandle: new FormControl(),
    companyProfilePhoto: new FormControl(),
    districtCity: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    category: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
  });

  get form() {
    return this.basicForm.controls;
  }

  ngOnInit(): void {
    this.dropdownSettings = {
      singleSelection: false,
      itemsShowLimit: 7,
      idField: 'id',
      textField: 'value',
      allowSearchFilter: true
    };

    this.basicDetails = this.partialService.getPartialBasicDetails();

    // this.categorySubscript = this.service.getAllVendorMultidetails(Constants.ServiceType)
    //   .subscribe((response) => {
    //     if (response) {
    //       this.categories = response;
    //     }
    //   });
    this.categories = [
      { id: 1, serviceId: 1, value: 'Styling: Makeup & Hair', expression: false, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
      { id: 2, serviceId: 1, value: 'Catering', expression: false, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
      { id: 3, serviceId: 1, value: 'Decoration', expression: false, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
      { id: 4, serviceId: 1, value: 'Photography', expression: false, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
      { id: 5, serviceId: 1, value: 'Entertainment', expression: false, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },

    ];

    this.districtSubscript = this.service.getAllMultidetails(Constants.City)
      .subscribe((response) => {
        if (response) {
          this.districtOption = response;
        }
      });

    // this.districtOption = [
    //   { id: 1, value: 'Alappuzha', tabList: [], keepContact: null, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
    //   { id: 2, value: 'Ernakulam', tabList: [], keepContact: null, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
    //   { id: 3, value: 'Idukki', tabList: [], keepContact: null, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
    //   { id: 4, value: 'Kannur', tabList: [], keepContact: null, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
    //   { id: 5, value: 'Kasaragod', tabList: [], keepContact: null, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null },
    //   { id: 6, value: 'Kollam', tabList: [], keepContact: null, contactPerson: null, emailId: null, primaryMobNo: null, multiCodeId: null }

    // ];
    this.getVendorNo = this.service.getVendorNo()
      .subscribe((response) => {
        if (response) {
          this.vendorNo = response;
        }
      });
  }

  ngOnDestroy() {
    if (this.categorySubscript) {
      this.categorySubscript.unsubscribe();
    }
    if (this.districtSubscript) {
      this.districtSubscript.unsubscribe();
    }
    if (this.partSaveSubscript) {
      this.partSaveSubscript.unsubscribe();
    }
    if (this.getVendorNo) {
      this.getVendorNo.unsubscribe();
    }
  }
  saveBasicDetails() {
    this.formSubmitted = true;

    if (this.basicForm.valid) {
      const params = new BasicDetailsModel();

      params.googleProfileUrl = this.basicForm?.controls['googleProfileUrl'].value;
      params.website = this.basicForm?.controls['companyWebsite'].value;
      params.facebookLink = this.basicForm?.controls['companyFacebookLink'].value;
      params.instagramLink = this.basicForm?.controls['companyInstagramLink'].value;
      params.pintrestLink = this.basicForm?.controls['companyPinterestLink'].value;
      params.twitterHandle = this.basicForm?.controls['companyTwitterHandle'].value;
      params.companyProfilePhoto = this.basicForm?.controls['companyProfilePhoto'].value;
      params.districtCity = this.basicForm?.controls['districtCity'].value;
      params.category = this.basicForm?.controls['category'].value;

      params.companyName = this.basicDetails?.companyName;
      params.primaryMobileNumber = this.basicDetails?.primaryMobileNumber;
      params.secondaryMobileNumber = this.basicDetails?.secondaryMobileNumber;
      params.primaryContactPerson = this.basicDetails?.primaryContactPerson;
      params.role = this.basicDetails?.role;
      params.email = this.basicDetails?.email;
      params.companyAddress = this.basicDetails?.companyAddress;
      params.companyLocation = this.basicDetails?.companyLocation;
      params.companyPincode = this.basicDetails?.companyPincode;
      params.listingName = this.basicDetails?.listingName;
      params.listingAddress = this.basicDetails?.listingAddress;
      params.location = this.basicDetails?.location;
      params.pincode = this.basicDetails?.pincode;

      const companydistricts: any[] = [];
      params.districtCity.forEach(x => {
        companydistricts.push({ district: x.id });
      });

      this.formData.append('userId', JSON.stringify(this.vendorNo));
      this.formData.append('googleprofileurl', JSON.stringify(params.googleProfileUrl));
      this.formData.append('website', JSON.stringify(params.website));
      this.formData.append('facebooklink', JSON.stringify(params.facebookLink));
      this.formData.append('instagramlink', JSON.stringify(params.instagramLink));
      this.formData.append('pintrestlink', JSON.stringify(params.pintrestLink));
      this.formData.append('twitterhandle', JSON.stringify(params.twitterHandle));
      this.formData.append('companyname', JSON.stringify(params.companyName));
      this.formData.append('primarymobilenumber', JSON.stringify(params.primaryMobileNumber));
      this.formData.append('secondarymobilenumber', JSON.stringify(params.secondaryMobileNumber));
      this.formData.append('primarycontactperson', JSON.stringify(params.primaryContactPerson));
      this.formData.append('role', JSON.stringify(params.role));
      this.formData.append('email', JSON.stringify(params.email));
      this.formData.append('companyaddress', JSON.stringify(params.companyAddress));
      this.formData.append('listingaddress', JSON.stringify(params.listingAddress));
      this.formData.append('companylocation', JSON.stringify(params.companyLocation));
      this.formData.append('companypincode', JSON.stringify(params.companyPincode));
      this.formData.append('lisitingname', JSON.stringify(params.listingName));
      // this.formData.append('district', JSON.stringify(params.location));
      this.formData.append('pincode', JSON.stringify(params.pincode));
      this.formData.append('companydistrictsstring', JSON.stringify(companydistricts));
      this.formData.append('createdby', JSON.stringify(1));
      this.formData.append('firstname', JSON.stringify(params.companyName));
      this.formData.append('lastname', JSON.stringify(params.companyName));
      // this.formData.append('username', JSON.stringify(params.companyName));
      // this.formData.append('password', JSON.stringify(params.companyName));
      this.formData.append('country', JSON.stringify(25));
      this.formData.append('approvalstatus', JSON.stringify(25));
      this.formData.append('state', JSON.stringify(25));


      this.dist = params.districtCity;
      this.partialService.saveVendorNo(this.vendorNo);

      this.partSaveSubscript = this.service.saveBasicDetails(this.formData)
        .subscribe((response) => {
          if (response) {

            this.partialService.saveVendorId(response.profileId);
            // this.router.navigate([`/app/superadmin/vendor-management/socialmedia-details`]);
            this.enableNext = false;
          }
        });


      this.partialService.savePartialBasicDetails(params);
      this.partialService.saveBasicDetails(this.dist, params.category);
      this.enableNext = false;

    }
  }
  selected() {

  }
  nextStep() {
    this.router.navigate([`/app/superadmin/vendor-management/address-details`]);
  }
  prepareImageFilesList(files: Array<any>) {
    for (const item of files) {
      const reader = new FileReader();
      reader.onload = (event: any) => {
        this.image = event.target.result;
        this.files.push({ 'image': this.image, 'fileName': item.name });

      };
      reader.readAsDataURL(item);
    }
    for (let i = 0; i < files.length; i++) {
      this.formData.append('profilephoto', files[i]);
    }
  }

  deleteFile(index: number) {
    this.files.splice(index, 1);
  }
}
