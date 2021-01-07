import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { BasicDetailsModel } from '../../model/basic-details.model';
import { VendorManagmentService } from '../../service/vendor-managment.service';
import { PartialSaveService } from '../../service/partial-save.service';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { Constants } from 'src/app/shared/constants/constants';

@Component({
  selector: 'app-vendor-basic-details',
  templateUrl: './vendor-basic-details.component.html',
  styleUrls: ['./vendor-basic-details.component.css']
})
export class VendorBasicDetailsComponent implements OnInit, OnDestroy {
  listingNameCheck = false;
  enableNext = false;
  formSubmitted = false;
  role = [];
  dropdownSettings: IDropdownSettings;

  rolSubscript: ISubscription;

  basicForm = new FormGroup({
    companyName: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    mobileNumber: new FormControl('',
      Validators.compose([Validators.required, Validators.pattern(/^[0-9]*$/), CustomFormValidator.cannotContainSpace])),
    alternateMobileNumber: new FormControl('',
      Validators.compose([Validators.required, Validators.pattern(/^[0-9]*$/), CustomFormValidator.cannotContainSpace])),
    primaryContactPerson: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    primaryContactRole: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    emailID: new FormControl('',
      Validators.compose([Validators.required, Validators.email, CustomFormValidator.cannotContainSpace])),
    companyAddress: new FormControl(),
    companyLocation: new FormControl(),
    listingNameCheck: new FormControl(),
    companyPincode: new FormControl(),
    listingName: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    listingAddress: new FormControl(),
    location: new FormControl(),
    pincode: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace]))
  });

  get form() {
    return this.basicForm.controls;
  }
  constructor(
    private router: Router,
    private service: VendorManagmentService,
    private partialService: PartialSaveService
  ) { }

  ngOnInit(): void {
    this.dropdownSettings = {
      singleSelection: true,
      itemsShowLimit: 7,
      idField: 'id',
      textField: 'value',
      allowSearchFilter: true
    };
    this.rolSubscript = this.service.getAllMultidetails(Constants.UserRoll)
      .subscribe((response) => {
        if (response) {
          this.role = response;
        }
      });
  }
  ngOnDestroy() {
    if (this.rolSubscript) {
      this.rolSubscript.unsubscribe();
    }

  }
  disableListingName() {
    const check = this.basicForm?.controls['listingNameCheck'].value;
    if (check) {
      this.form.listingName.enable();
    } else {
      this.form.listingName.disable();
      const companyName = this.basicForm?.controls['companyName'].value;
      this.basicForm?.controls['listingName'].setValue(companyName);
    }
  }
  nextStep(basicForm) {
    this.formSubmitted = true;

    if (basicForm.valid) {
      const params = new BasicDetailsModel();
      let temp = [];
      params.companyName = this.basicForm?.controls['companyName'].value;
      params.primaryMobileNumber = this.basicForm?.controls['mobileNumber'].value;
      params.secondaryMobileNumber = this.basicForm?.controls['alternateMobileNumber'].value;
      params.primaryContactPerson = this.basicForm?.controls['primaryContactPerson'].value;
      temp = this.basicForm?.controls['primaryContactRole'].value;
      params.role = temp[0].id;
      params.email = this.basicForm?.controls['emailID'].value;
      params.companyAddress = this.basicForm?.controls['companyAddress'].value;
      params.companyLocation = this.basicForm?.controls['companyLocation'].value;
      params.companyPincode = this.basicForm?.controls['companyPincode'].value;
      params.listingName = this.basicForm?.controls['listingName'].value;
      params.listingAddress = this.basicForm?.controls['listingAddress'].value;
      params.location = this.basicForm?.controls['location'].value;
      params.pincode = this.basicForm?.controls['pincode'].value;


      // this.service.savePartialBasicDetails(params)
      //   .subscribe((response) => {
      //     if (response) {
      //       this.router.navigate([`/app/superadmin/vendor-management/socialmedia-details`]);
      //     }
      //   });

      this.partialService.savePartialBasicDetails(params);

      this.router.navigate([`/app/superadmin/vendor-management/socialmedia-details`]);


    }

  }


}
