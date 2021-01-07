import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { VendorManagmentService } from '../../service/vendor-managment.service';
import { GstDetailModel } from '../../model/gst-detail.model';
import { KycModel } from '../../model/kyc.model';
import { PartialSaveService } from '../../service/partial-save.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';
import { Constants } from 'src/app/shared/constants/constants';
import { SubscriptionLike as ISubscription } from 'rxjs';

@Component({
  selector: 'app-vendor-kycform',
  templateUrl: './vendor-kycform.component.html',
  styleUrls: ['./vendor-kycform.component.css']
})
export class VendorKYCFormComponent implements OnInit, OnDestroy {

  getDocumentType: ISubscription;
  creatKyc: ISubscription;

  formData: FormData = new FormData();
  documentType = [];
  stateType = [];
  cityType = [];
  // documentType = [
  //   { id: 1, value: 'aadhar' },
  //   { id: 2, value: 'election' },
  //   { id: 3, value: 'passport' },
  //   { id: 4, value: 'pan' }];
  selectedDoc;
  selectedProof;
  dropdownSettings: IDropdownSettings;
  isGSTRegister = true;
  formSubmitted = false;

  image;
  gstdocument: any[] = [];
  kycdocument: any[] = [];
  proofdocument: any[] = [];

  kycForm = new FormGroup({
    documentId: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    documentType: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    fatherName: new FormControl(),
    dob: new FormControl(),
    isGSTRegister: new FormControl(),
    gstnumber: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    gststate: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    gstcity: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    businessName: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    address: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    proofType: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    proofID: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
    companyNameCheck: new FormControl(),
    addressCheck: new FormControl(),
  });

  get form() {
    return this.kycForm.controls;
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
    this.getDocumentType = this.service.getAllMultidetails(Constants.DocumentType)
      .subscribe((response) => {
        if (response) {
          this.documentType = response;
        }
      });
    this.getDocumentType = this.service.getAllMultidetails(Constants.State)
      .subscribe((response) => {
        if (response) {
          this.stateType = response;
        }
      });
    this.getDocumentType = this.service.getAllMultidetails(Constants.City)
      .subscribe((response) => {
        if (response) {
          this.cityType = response;
        }
      });
    this.kycForm?.controls['isGSTRegister'].setValue(false);
  }
  ngOnDestroy() {
    if (this.getDocumentType) {
      this.getDocumentType.unsubscribe();
    }
    if (this.creatKyc) {
      this.creatKyc.unsubscribe();
    }

  }
  nextStep(kycForm) {
    this.formSubmitted = true;

    if (kycForm.valid) {
      // const formData: FormData = new FormData();
      const KYCCreateData = new Array<KycModel>();
      // KYCCreateData.gstDetails = new GstDetailModel();
      let kycparams = new KycModel();
      let proofParams = new KycModel();
      let gstParams = new KycModel();
      let temp;
      const gstDet = new GstDetailModel();



      proofParams.documentId = this.kycForm?.controls['proofID'].value;

      temp = this.kycForm?.controls['proofType'].value;
      proofParams.kycid = temp[0].id;
      kycparams.documentId = this.kycForm?.controls['documentId'].value;
      temp = this.kycForm?.controls['documentType'].value;
      kycparams.kycid = temp[0].id;
      kycparams.kycstatus = 34;
      kycparams.fatherName = this.kycForm?.controls['fatherName'].value;
      kycparams.dob = this.kycForm?.controls['dob'].value;
      kycparams.createdBy = 1;
      gstDet.gstnumber = this.kycForm?.controls['gstnumber'].value;
      temp = this.kycForm?.controls['gststate'].value;
      gstDet.gststate = temp[0].id;
      temp = this.kycForm?.controls['gstcity'].value;
      gstDet.gstcity = temp[0].id;

      gstDet.address = this.kycForm?.controls['address'].value;
      gstDet.businessName = this.kycForm?.controls['businessName'].value;

      proofParams.kycstatus = 34;
      proofParams.createdBy = 1;

      gstParams.gstdetailstring = JSON.stringify(gstDet);
      gstParams.kycid = 45;
      gstParams.kycstatus = 34;
      gstParams.createdBy = 1;
      KYCCreateData.push(kycparams);
      KYCCreateData.push(proofParams);
      KYCCreateData.push(gstParams);

      const model = JSON.stringify(KYCCreateData);
      if (model) {
        this.formData.append('KYCData', model);
      }

      this.creatKyc = this.service.createKyc(this.formData)
        .subscribe((response) => {
          if (response) {
            this.router.navigate([`/app/superadmin/vendor-management/otp`]);
          }
        });
      this.router.navigate([`/app/superadmin/vendor-management/otp`]);
    }
  }
  selected() {

  }

  prepareGstdocument(files: Array<any>) {
    this.gstdocument = [];
    for (const item of files) {
      const reader = new FileReader();
      reader.onload = (event: any) => {
        this.image = event.target.result;
        this.gstdocument.push({ 'image': this.image, 'fileName': item.name });

      };
      reader.readAsDataURL(item);
    }
    for (let i = 0; i < files.length; i++) {
      this.formData.append('GstDoc', files[i]);
    }
  }
  preparekycdocument(files: Array<any>) {
    this.kycdocument = [];
    for (const item of files) {
      const reader = new FileReader();
      reader.onload = (event: any) => {
        this.image = event.target.result;
        this.kycdocument.push({ 'image': this.image, 'fileName': item.name });

      };
      reader.readAsDataURL(item);
    }
    for (let i = 0; i < files.length; i++) {
      this.formData.append('KycDoc', files[i]);
    }
  }
  prepareproofdocument(files: Array<any>) {
    this.proofdocument = [];
    for (const item of files) {
      const reader = new FileReader();
      reader.onload = (event: any) => {
        this.image = event.target.result;
        this.proofdocument.push({ 'image': this.image, 'fileName': item.name });

      };
      reader.readAsDataURL(item);
    }
    for (let i = 0; i < files.length; i++) {
      this.formData.append('ProofDoc', files[i]);
    }
  }
  deleteproofdocument(index: number) {
    this.proofdocument.splice(index, 1);
  }
  deletekycdocument(index: number) {
    this.kycdocument.splice(index, 1);
  }
  deleteGstdocument(index: number) {
    this.gstdocument.splice(index, 1);
  }
  hideForm() {
    this.isGSTRegister = this.kycForm?.controls['isGSTRegister'].value;
    if (this.isGSTRegister) {
      this.kycForm?.controls['address'].setValidators(Validators.required);
      this.kycForm?.controls['address'].updateValueAndValidity();
      this.kycForm?.controls['businessName'].setValidators(Validators.required);
      this.kycForm?.controls['businessName'].updateValueAndValidity();
      this.kycForm?.controls['gstcity'].setValidators(Validators.required);
      this.kycForm?.controls['gstcity'].updateValueAndValidity();
      this.kycForm?.controls['gstnumber'].setValidators(Validators.required);
      this.kycForm?.controls['gstnumber'].updateValueAndValidity();
      this.kycForm?.controls['gststate'].setValidators(Validators.required);
      this.kycForm?.controls['gststate'].updateValueAndValidity();
    } else {
      this.kycForm?.controls['address'].clearValidators();
      this.kycForm?.controls['address'].updateValueAndValidity();
      this.kycForm?.controls['businessName'].clearValidators();
      this.kycForm?.controls['businessName'].updateValueAndValidity();
      this.kycForm?.controls['gstcity'].clearValidators();
      this.kycForm?.controls['gstcity'].updateValueAndValidity();
      this.kycForm?.controls['gstnumber'].clearValidators();
      this.kycForm?.controls['gstnumber'].updateValueAndValidity();
      this.kycForm?.controls['gststate'].clearValidators();
      this.kycForm?.controls['gststate'].updateValueAndValidity();
    }
  }

  sameAsCompany() {

    const obj = this.partialService.getPartialBasicDetails();
    const check = this.kycForm?.controls['companyNameCheck'].value;
    if (check) {
      this.form.businessName.enable();
    } else {
      this.form.businessName.disable();

      if (obj.companyName) {
        const companyName = obj.companyName;
        this.kycForm?.controls['businessName'].setValue(companyName);
      }

    }
    this.kycForm?.controls['companyNameCheck'].setValue(!check);
  }
  sameAsAddress() {
    const obj = this.partialService.getPartialBasicDetails();
    const check = this.kycForm?.controls['addressCheck'].value;
    if (check) {
      this.form.address.enable();
    } else {
      this.form.address.disable();

      if (obj.companyAddress) {
        const companyAddres = obj.companyAddress;
        this.kycForm?.controls['address'].setValue(companyAddres);
      }

    }
    this.kycForm?.controls['addressCheck'].setValue(!check);
  }


}
