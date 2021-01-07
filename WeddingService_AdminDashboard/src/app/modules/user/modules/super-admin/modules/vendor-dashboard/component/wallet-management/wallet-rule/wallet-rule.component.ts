import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';
import { Constants } from 'src/app/shared/constants/constants';
import { WalletRuleModel } from '../model/wallet-rule-model';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { WalletServiceService } from '../services/wallet-service.service';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'app-wallet-rule',
  templateUrl: './wallet-rule.component.html',
  styleUrls: ['./wallet-rule.component.css']
})
export class WalletRuleComponent implements OnInit, OnDestroy {

  constructor(
    private service: WalletServiceService
  ) { }

  bigTotalItems: number;
  bigCurrentPage = 1;
  maxSize = 30;
  pageSize = 10;
  mode = [];
  category = [];
  walletList = [];
  formSubmitted = false;
  buttonString = 'Create';
  isEdit = false;
  currentId;
  autoServiceName: string;

  dropdownSettings: IDropdownSettings;

  categorySubscript: ISubscription;
  modeSubscript: ISubscription;
  SaveSubscript: ISubscription;
  getListSubscript: ISubscription;
  getUpdateDetailsSubscript: ISubscription;
  updateSubscript: ISubscription;
  deleteSubscript: ISubscription;
  checkCategory: ISubscription;

  basicForm = new FormGroup({
    serviceCode: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    serviceCategory: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    mode: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    cplAmount: new FormControl(),
    commissionAmount: new FormControl()
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

    this.modeSubscript = this.service.getAllWalletMultidetails(Constants.Mode).subscribe((response) => {
      if (response) {
        this.mode = response;
      }
    });
    this.categorySubscript = this.service.getAllWalletMultidetails(Constants.WalletCategory).subscribe((response) => {
      if (response) {
        this.category = response;
      }
    });
    this.getWalletRules();

  }
  ngOnDestroy() {
    if (this.categorySubscript) {
      this.categorySubscript.unsubscribe();
    }
    if (this.modeSubscript) {
      this.modeSubscript.unsubscribe();
    }
    if (this.SaveSubscript) {
      this.SaveSubscript.unsubscribe();
    }
    if (this.getListSubscript) {
      this.getListSubscript.unsubscribe();
    }
    if (this.updateSubscript) {
      this.updateSubscript.unsubscribe();
    }
    if (this.getUpdateDetailsSubscript) {
      this.getUpdateDetailsSubscript.unsubscribe();
    }
    if (this.deleteSubscript) {
      this.deleteSubscript.unsubscribe();
    }
    if (this.checkCategory) {
      this.checkCategory.unsubscribe();
    }
  }
  saveWalletRule(basicForm) {
    this.formSubmitted = true;

    if (basicForm.valid) {
      const params = new WalletRuleModel();
      let temp = [];
      params.commissionAmount = Number(this.basicForm?.controls['commissionAmount'].value);
      params.cplAmount = Number(this.basicForm?.controls['cplAmount'].value);
      temp = this.basicForm?.controls['mode'].value;
      params.mode = temp[0].id;
      temp = this.basicForm?.controls['serviceCategory'].value;
      params.serviceCategory = temp[0].id;
      params.serviceCategoryName = temp[0].value;
      params.serviceCode = this.basicForm?.controls['serviceCode'].value;
      this.formSubmitted = false;
      if (!this.isEdit) {
        params.createdBy = '1';
        this.checkCategory = this.service.gettWalletRulesByCategory(params.serviceCategory).subscribe((checkRes) => {
          if (checkRes.length > 0) {
            alert('Wallet Rule Alredy Created For Service Category!');
          } else {
            this.SaveSubscript = this.service.saveWalletRule(params).subscribe((response) => {
              if (response) {
                alert('Wallet Rule Created!');
                this.getWalletRules();
              }
            });
          }
        });
      } else if (this.currentId) {
        params.updatedBy = '1';
        this.SaveSubscript = this.service.updateWalletRule(params, this.currentId).subscribe((response) => {
          if (response) {
            alert('Wallet Rule Updated!');
            this.getWalletRules();
          }
        });
      }
    } else {
      this.getWalletRules();
    }
  }
  editDetails(x) {
    this.isEdit = true;
    this.buttonString = 'Update';
    this.currentId = x.id;
    this.getListSubscript = this.service.getWalletRulesDetails(x.id).subscribe((response) => {
      if (response) {
        const mode = { id: response.mode, value: response.modeName };
        const category = { id: response.serviceCategory, value: response.serviceCategoryName };
        this.basicForm.get('serviceCode').setValue(response.serviceCode);
        this.basicForm.get('serviceCategory').setValue(category);
        this.basicForm.get('mode').setValue(mode);
        this.basicForm.get('cplAmount').setValue(response.cplAmount);
        this.basicForm.get('commissionAmount').setValue(response.commissionAmount);
      }
    });
  }
  delete(x) {
    if (x.id) {
      const r = confirm('Press ok for delete');
      if (r === true) {
        this.deleteSubscript = this.service.deleteWalletRule(x.id).subscribe((response) => {

          alert('Wallet rule deleted !');
          this.getWalletRules();

        });
      }
    }

  }
  private getWalletRules() {
    this.getListSubscript = this.service.getAllWalletRules().subscribe((response) => {
      if (response.length > 0) {
        this.walletList = response;
        // for auto service code
        let highestValue = 0;
        for (var i = 0, len = response.length; i < len; i++) {
          let value = Number(response[i]['id']);
          if (value > highestValue) {
            highestValue = value;
          }
        }

        this.walletList.forEach(x => {
          if (x.id === highestValue) {
            this.autoServiceName = x.serviceCode;
          }
        });
        const tempString2 = String.fromCharCode(this.autoServiceName.charCodeAt(this.autoServiceName.length - 1) + 1);
        const tempString1 = this.autoServiceName.substring(0, this.autoServiceName.length - 1);
        this.autoServiceName = tempString1 + tempString2;

        if (this.autoServiceName) {
          this.basicForm.get('serviceCode').setValue(this.autoServiceName);
        }

      }
    });
  }
  clear() {
    this.basicForm.reset();

    this.isEdit = false;
    this.currentId = undefined;
    this.buttonString = 'Create';
  }
}
