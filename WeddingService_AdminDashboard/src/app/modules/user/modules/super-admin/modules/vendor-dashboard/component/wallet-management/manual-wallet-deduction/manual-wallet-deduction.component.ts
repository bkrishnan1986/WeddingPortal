import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';
import { Constants } from 'src/app/shared/constants/constants';
import { WalletLeadDetails } from '../model/wallet-lead-details';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { VendorDashboardService } from '../../../services/vendor-dashboard.service';
import { WalletServiceService } from '../services/wallet-service.service';
import { WalletBalance } from '../../../models/wallet-balance.model';
import { WalletDeduction } from '../model/wallet-deduction';
import {formatDate} from '@angular/common';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { datepickerAnimation } from 'ngx-bootstrap/datepicker/datepicker-animations';

@Component({
  selector: 'app-manual-wallet-deduction',
  templateUrl: './manual-wallet-deduction.component.html',
  styleUrls: ['./manual-wallet-deduction.component.css']
})
export class ManualWalletDeductionComponent implements OnInit {

  constructor(private service: WalletServiceService, 
    private vendorDashboardService: VendorDashboardService) { 
    
  }

  SaveSubscript: ISubscription;
  getListSubscript: ISubscription;
  walletLeadDetails: WalletLeadDetails;
  walletBalance: WalletBalance;
  CreatedDate: string;
  CreatedTime: string;
  LeadOwner: string;
  ApprovedDate: string;
  AuthorizedDate: string;
  CustomerName: string;
  Location: string;
  Eventtype: string;
  EventDate: string
  Budgetproposed: number;
  CategoryName: string;
  VendorID: number;
  VendorName: string;
  VendorCategory: string;
  LeadMode: string;
  Value: number;
  Walletstatus: string;
  InvoiceNumber: string;
  Invoicedate: string;
  ActualInvoiceamount: number;
  WalletBalanceAmount: number;
  Amounttobededucted: number;
  Deducteddate: string; 
  LeadId: number;
  LeadIdNumber: string;
  CustomerId: number;
  WalletStatusId: number;
  isleadExists: boolean = false;
  formSubmitted: boolean = false;

  walletDeducationForm = new FormGroup({
    invoicenumber: new FormControl('',
      Validators.compose([Validators.required, Validators.pattern(/^[0-9]*$/), CustomFormValidator.cannotContainSpace])),
      invoicedate: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace])),
      actualinvoiceamount: new FormControl('',
      Validators.compose([Validators.required, Validators.pattern(/^[0-9]*$/), CustomFormValidator.cannotContainSpace])),
      walletbalanceamount: new FormControl('',
      Validators.compose([Validators.required, Validators.pattern(/^[0-9]*$/), CustomFormValidator.cannotContainSpace])),
      amounttobededucted: new FormControl('',
      Validators.compose([Validators.required, Validators.pattern(/^[0-9]*$/), CustomFormValidator.cannotContainSpace])),
  });

  get form() {
    return this.walletDeducationForm.controls;
  }

  @ViewChild('leadId') myInputVariable: ElementRef;

  ngOnInit(): void {

    this.getWalletLeadDetails("");
  }

  getWalletLeadDetails(leadId: string) {
    this.isleadExists = false;
    this.walletLeadDetails = null;
    this.formSubmitted = false;
    if(leadId != "")
    {

      this.service.getLeadDetails(leadId).subscribe((response) => {
        if (response) {
          this.walletLeadDetails = response;
          this.updateResult(this.walletLeadDetails);
        }
      });
    }
  }

  updateResult(leadDetails: WalletLeadDetails) {

    if(leadDetails != null && leadDetails.leadassign.length > 0)
    {
      this.isleadExists = true;
      this.vendorDashboardService.getWalletBalanceDetails(leadDetails.leadassign[0].vendorId).subscribe((response) => {
        if (response) {
          this.walletBalance = response;

          if(this.walletBalance != null)
          {
            this.walletDeducationForm.controls.walletbalanceamount.setValue(this.walletBalance.Balance);
            this.WalletBalanceAmount = this.walletBalance.Balance;
            this.WalletStatusId = this.walletBalance.Status;
            this.Walletstatus = this.walletBalance.StatusValue;
          }

        }
      });

      this.CreatedDate = leadDetails.createdAt != null ? formatDate(leadDetails.createdAt, 'dd/MM/yyyy', 'en') : "";
      this.CreatedTime = leadDetails.createdAt != null ? formatDate(leadDetails.createdAt, 'hh:mm', 'en') : "";
      this.LeadOwner= leadDetails.owner;
      let ApprovedDateTime = leadDetails.leadstatus.find(x=>x.statusName == "Approved Date") != null ?
                          leadDetails.leadstatus.find(x=>x.statusName == "Approved Date").date: null;
      let AuthorizedDateTime = leadDetails.leadstatus.find(x=>x.statusName == "Authorized Date") != null ?
                            leadDetails.leadstatus.find(x=>x.statusName == "Authorized Date").date : null;

      if(ApprovedDateTime != null)
      {
        this.ApprovedDate = formatDate(ApprovedDateTime, 'dd/MM/yyyy', 'en');
      }            
      if(AuthorizedDateTime != null)
      {
        this.AuthorizedDate = formatDate(AuthorizedDateTime, 'dd/MM/yyyy', 'en');
      }  
      this.WalletBalanceAmount = 0;               
      this.CustomerName = leadDetails.customerName;
      this.Location = leadDetails.eventLocationName;
      this.Eventtype = leadDetails.eventTypeName;
      this.EventDate = formatDate(leadDetails.eventDate, 'dd/MM/yyyy', 'en');
      this.Budgetproposed = leadDetails.budget;
      this.CategoryName = leadDetails.categoryName;
      this.VendorID = leadDetails.leadassign[0].vendorId;
      this.VendorName = leadDetails.leadassign[0].vendorName;
      this.VendorCategory = leadDetails.leadassign[0].categoryName;
      this.LeadMode = leadDetails.leadModeName;
      this.Value = leadDetails.cplvalue;
      this.InvoiceNumber = "0";

      this.Invoicedate = formatDate(new Date(), 'dd/MM/yyyy', 'en');
      this.ActualInvoiceamount = 0;
      this.Amounttobededucted = 0;
      this.Deducteddate = formatDate(new Date(), 'dd/MM/yyyy', 'en'); 
      this.LeadId = leadDetails.id;
      this.LeadIdNumber = leadDetails.leadId;
      this.walletDeducationForm.controls.invoicenumber.setValue(this.InvoiceNumber);
      this.walletDeducationForm.controls.invoicedate.setValue(this.Invoicedate);
      this.walletDeducationForm.controls.actualinvoiceamount.setValue(this.ActualInvoiceamount);
      this.walletDeducationForm.controls.amounttobededucted.setValue(this.Amounttobededucted);
    }
  }

  SubmitDeduction(walletDeducationForm) {
    this.formSubmitted = true;
    if(this.walletDeducationForm.valid)
    {
      const params = new WalletDeduction();
      params.leadId = this.LeadId;
      params.leadIdNumber = this.LeadIdNumber;
      params.vendorId = this.VendorID;
      params.leadMode = this.LeadMode;
      params.customerId = 0;
      params.categoryValue = this.VendorCategory;
      params.invoiceNumber = this.walletDeducationForm?.controls['invoicenumber'].value;
      params.invoiceDate = new Date(this.walletDeducationForm?.controls['invoicedate'].value);
      if(params.invoiceDate.toString() == "Invalid Date")
      {
      var iDateNumber = this.walletDeducationForm?.controls['invoicedate'].value.split("/");
      params.invoiceDate = new Date(iDateNumber[1] + "-" + iDateNumber[0] + "-" + iDateNumber[2]);
      }
      params.invoiceAmount = Number(this.walletDeducationForm?.controls['actualinvoiceamount'].value);
      params.walletBalance = Number(this.walletDeducationForm?.controls['walletbalanceamount'].value);
      params.walletStatus = this.WalletStatusId;
      params.deductedAmount = Number(this.walletDeducationForm?.controls['amounttobededucted'].value);
      let dDateNumber = this.Deducteddate.split("/");
      params.deductedDate = new Date(dDateNumber[1] + "-" + dDateNumber[0] + "-" + dDateNumber[2]);
      params.createdBy = 1;

      this.SaveSubscript = this.service.saveWalletDeduction(params).subscribe((response) => {
          if (response) {
            alert('Wallet Deduction Created!');
            this.isleadExists = false;
            this.myInputVariable.nativeElement.value = '';
          }
        });
      }
  }

}
