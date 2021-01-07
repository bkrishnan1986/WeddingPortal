import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { VendorDashboardService } from '../../../services/vendor-dashboard.service';
import { WalletServiceService } from '../services/wallet-service.service';
import { WalletBalance } from '../../../models/wallet-balance.model';
import { TransactionDetails } from '../model/transaction-details.model';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { WalletVendorDetails, servicesubscription } from '../model/wallet-vendor-detail.model'

@Component({
  selector: 'app-pause-release',
  templateUrl: './pause-release.component.html',
  styleUrls: ['./pause-release.component.css']
})
export class PauseReleaseComponent implements OnInit {

  constructor(private service: WalletServiceService, 
    private vendorDashboardService: VendorDashboardService, 
    private modalService: BsModalService) { }

    id: number;
    walletId: number = 0;
    referenceNo: string;
    particulars: string;
    transactionDate: Date;
    transactionType: number;
    mode: string;
    amount: number;
    walletBalance: number;
    createdBy: number;
    createdAt: Date;
    updatedBy: number;
    updatedAt: Date;
    transDetails: TransactionDetails[];
    WalletStatusId: number;
    WalletStatus: number;
    walletBalanceDetail: WalletBalance;
    isDisplayDetails: boolean = false;
    closeResult: string;
    bsModalRef: BsModalRef;
    Reason: string;
    vendorIdNumber: number;
    IsPaused: boolean = false;
    IsReleased: boolean = false;
    IsChurned: boolean = false;
    walletVendorDetails: WalletVendorDetails[];
    walletVendorId: number;
    walletVendorName: string;
    vendorServiceSubscription: servicesubscription[];

    @ViewChild('mymodal') elementView: ElementRef;
    openModalWithComponent(status: number) { 
      this.IsPaused = status == 4 ? true : false;
      this.IsReleased = status == 5 ? true : false;
      this.IsChurned = status == 6 ? true : false;
        this.bsModalRef = this.modalService.show(this.elementView);

    }
    closeModalWithComponent() {    
      this.modalService.hide();
  }

  ngOnInit(): void {

  }

  getTransactionDetails() {
    this.walletId = 0;
    if(Number.isInteger(Number(this.vendorIdNumber)) && this.vendorIdNumber != 0)
    {
      this.service.getTransactionsDetails(this.vendorIdNumber).subscribe((response) => {
        if (response) {
          this.transDetails = response;
          this.walletId = this.transDetails[0].walletId;
          this.getwalletBalanceStatus(this.vendorIdNumber);
        }
      });
    }
  }

  getVendorWalletDetailsByVendorId()
  {
    this.isDisplayDetails = false;
    this.service.getVendorWalletDetailsByVendorId(this.vendorIdNumber.toString()).subscribe((response) => {
      if (response) {
         this.walletVendorDetails = response;
         this.vendorServiceSubscription = [];
         for(let i=0; i < this.walletVendorDetails.length; i++)
         {
            for(let j=0; j < this.walletVendorDetails[i].servicesubscription.length; j++)
            {
              this.walletVendorDetails[i].servicesubscription[j].vendorId = this.walletVendorDetails[i].vendorId;
              this.walletVendorDetails[i].servicesubscription[j].vendorName = this.walletVendorDetails[i].vendorName;
              this.vendorServiceSubscription.push(this.walletVendorDetails[i].servicesubscription[j]);
            }
         }
         this.isDisplayDetails = true;
         this.getTransactionDetails();
         
      }
    });
  }

  getwalletBalanceStatus(vendorId: number)
  {
    this.vendorDashboardService.getWalletBalanceDetails(vendorId).subscribe((response) => {
      if (response) {
        this.walletBalanceDetail = response;

        if(this.walletBalanceDetail != null)
        {
          this.WalletStatusId = this.walletBalanceDetail.Status;
        }
      }
    });
  }

  SaveWalletStatus()
  {
    console.log(this.walletId);

    if(this.walletId != 0)
    {
      if(this.WalletStatus == 4)
      this.service.updateWalletStatus(this.walletId, this.IsPaused, this.IsReleased, this.IsChurned).subscribe((response =>
        {
          if(response)
          {
            this.getTransactionDetails();
          }
          this.modalService.hide();
        }))
    }
    else
    {
      this.modalService.hide();
    }
    
  }

}
