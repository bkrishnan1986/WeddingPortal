import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { ManualWalletAdjustModel } from '../model/manual-wallet-adjust-model';
import { Constants } from 'src/app/shared/constants/constants';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { WalletServiceService } from '../services/wallet-service.service';

@Component({
  selector: 'app-manual-wallet-adjustment',
  templateUrl: './manual-wallet-adjustment.component.html',
  styleUrls: ['./manual-wallet-adjustment.component.css']
})
export class ManualWalletAdjustmentComponent implements OnInit, OnDestroy {

  search: string;
  formSubmitted = false;
  status = [];
  adjustmentTypeList = [];
  vendorId: number;
  dropdownSettings: IDropdownSettings;

  categorySubscript: ISubscription;
  vendorSearchSubscript: ISubscription;
  vendorStatusSubscript: ISubscription;
  adjustTypeSubscript: ISubscription;
  saveSubscript: ISubscription;

  constructor(private service: WalletServiceService) { }

  basicForm = new FormGroup({
    vendorId: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    adjustmentType: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    adjustmentAmount: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    vendorName: new FormControl(),
    category: new FormControl(),
    vendorStatus: new FormControl(),
    walletBalance: new FormControl(),
    remarks: new FormControl()
  });
  get form() {
    return this.basicForm.controls;
  }

  ngOnInit(): void {

    this.dropdownSettings = {
      singleSelection: true,
      itemsShowLimit: 7,
      idField: 'id',
      textField: 'value',
      allowSearchFilter: true
    };
    this.adjustTypeSubscript = this.service.getAllWalletMultidetails(Constants.AdjustmentType).subscribe((response) => {
      if (response) {
        this.adjustmentTypeList = response;
      }
    });
    // this.vendorStatusSubscript = this.service.getAllVendorMultidetails(Constants.UserStatus).subscribe((response) => {
    //   if (response) {
    //     this.status = response;
    //   }
    // });
  }
  ngOnDestroy() {
    if (this.categorySubscript) {
      this.categorySubscript.unsubscribe();
    }
    if (this.vendorSearchSubscript) {
      this.vendorSearchSubscript.unsubscribe();
    }
    if (this.saveSubscript) {
      this.saveSubscript.unsubscribe();
    }
    // if (this.vendorStatusSubscript) {
    //   this.vendorStatusSubscript.unsubscribe();
    // }
    if (this.adjustTypeSubscript) {
      this.adjustTypeSubscript.unsubscribe();
    }
  }

  searchList(search: string) {
    if (search) {
      this.vendorSearchSubscript = this.service.getVendorSearchDetails(search).subscribe((response) => {
        if (response) {
          this.basicForm.get('vendorId').setValue(response.userId);
          this.basicForm.get('vendorName').setValue(response.vendorName);
          this.basicForm.get('category').setValue(response.category);
          this.basicForm.get('vendorStatus').setValue(response.vendorStatus);
          this.basicForm.get('walletBalance').setValue(response.walletBalance);
        }
      });
    }
  }
  submit(basicForm) {
    debugger;
    this.formSubmitted = true;
    if (basicForm.valid) {
      const params = new ManualWalletAdjustModel();
      let temp = [];
      params.adjustmentAmount = Number(this.basicForm?.controls['adjustmentAmount'].value);
      temp = this.basicForm?.controls['adjustmentType'].value;
      params.adjustmentType = temp[0].id;
      params.createdBy = '1';
      params.vendorId = this.basicForm?.controls['vendorId'].value;
      params.remarks = this.basicForm?.controls['remarks'].value;

      this.formSubmitted = false;
      this.saveSubscript = this.service.saveManualAdjust(params).subscribe((response) => {
        if (response) {
          alert('Adjustment Created !');

        }
      });
    }
  }
}
