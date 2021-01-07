import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Button } from 'primeng/button';
import { groupBy } from 'rxjs/operators';
import { KycDashboardModel } from '../../../vendor-management/model/kyc.model';
import { CategoryDetails } from '../../models/category-details.model';
import { LeadDetails, Leads } from '../../models/leads.model';
import { MultiDetailModel } from '../../models/multidetails.model';
import { PackageDetails } from '../../models/package-details.model';
import { VendorProfile } from '../../models/user-profile.model';
import { VendorQuestionAnswers } from '../../models/vendor-question-answer.model';
import { WalletBalance } from '../../models/wallet-balance.model';
import { WalletRule } from '../../models/wallet-rule.model';
import { VendorDashboardService } from '../../services/vendor-dashboard.service';
import { WalletServiceService } from '../wallet-management/services/wallet-service.service'
import { TransactionDetails } from '../wallet-management/model/transaction-details.model';

@Component({
  selector: 'app-vendor-booked-details',
  templateUrl: './vendor-booked-details.component.html',
  styleUrls: ['./vendor-booked-details.component.css']
})
export class VendorBookedDetailsComponent implements OnInit {
  questions: any;
  walletRule = new Array<WalletRule>();
  questionaireIndex: number;
  walletBalance = new Array<WalletBalance>();
  valuesAlreadySeen = [];
  serviceTypes = [];
  packageDetails = new Array<PackageDetails>();
  questionAnswers: Array<VendorQuestionAnswers>;
  cplDetails = [];
  serviceSubscription = [];
  leadValue: string;
  vendorId: number;
  subscriptionPlan: any;
  vendorBasicDetails: VendorProfile;
  multiDetails = new Array<MultiDetailModel>();
  kycDetails = new Array<KycDashboardModel>();
  categoryDetails = new Array<CategoryDetails>();
  leadDetails = new Array<LeadDetails>();
  isFromWallet: boolean = false;
  transDetails: TransactionDetails[];
  cpcLeadCount: number;
  cpcTotalAmount: number;
  commLeadCount: number;
  commTotalAmount: number;

  @ViewChild('waba') waba: ElementRef;
  constructor(
    private route: ActivatedRoute,
    private vendorDashboardService: VendorDashboardService,
    private walletService: WalletServiceService
  ) { }

  ngOnInit(): void {
    this.vendorBasicDetails = {} as VendorProfile;
    this.vendorId = this.route.snapshot.queryParams.vendorId;
    this.isFromWallet = this.route.snapshot.queryParams.isFromWallet;
    this.getVendorBasicDetailsById();
    this.getWalletBalanceDetails();
    this.getCategoryDetailsByVendorId();
    this.getKYCDetailsByVendorId();
    this.getPackagesByVendorId();
    this.getLeadDetailsByVendorId();
    this.getQuestionaireByVendorId();
    this.getTransactionDetails();
	this.getLeadTotalCountAmount();
    //this.getWalletRuleById(14);
    if(this.isFromWallet)
    {
      setTimeout(() => {
        this.waba.nativeElement.click();
        }, 200);
    }
  }

  private getVendorBasicDetailsById() {
    this.vendorDashboardService.getVendorBasicDetailsByVendorId(this.vendorId)
      .subscribe((response) => {
        if (response) {
          this.vendorBasicDetails = response;
          var parts = this.vendorBasicDetails.photo.split('\\', 4);
          this.vendorBasicDetails.photo = parts.pop();
        }
      });
  }
  getWalletBalanceDetails() {
    this.vendorDashboardService.getWalletBalanceDetails(this.vendorId)
      .subscribe((response) => {
        if (response) {
          this.walletBalance = response;
        }
      });
  }
  getKYCDetailsByVendorId() {
    this.vendorDashboardService.getKYCDetailsByVendorId(this.vendorId)
      .subscribe((response) => {
        if (response) {
          this.kycDetails = response;
          this.kycDetails.forEach(x => {
            x.kycdetails.forEach(z => {
              var parts = z.kycdocPath.split('\\', 4);
              z.kycdocPath = parts.pop();

            })
            x.gstdetails.forEach(z => {
              var parts = z.gstdocument.split('\\', 4);
              z.gstdocument = parts.pop();
            })
          })
        }
      });
  }
  getCategoryDetailsByVendorId() {
    this.vendorDashboardService.getCategoryDetailsByVendorId(this.vendorId)
      .subscribe((response) => {
        if (response) {
          this.categoryDetails = response;
          this.categoryDetails.forEach(c => {
            c.branchserviceoffered.forEach(bs => {
              this.getWalletRuleById(bs.serviceId)
            })
          })

        }
      })
  }
  getWalletRuleById(serviceId: number) {
    this.vendorDashboardService.getWalletRuleById(serviceId)
      .subscribe((response) => {
        if (response) {
          this.walletRule.push(response[0]);
        }
      });
  }
  getPackagesByVendorId() {
    this.vendorDashboardService.getPackagesByVendorId(this.vendorId)
      .subscribe((response) => {
        if (response) {
          this.packageDetails = response;
          this.packageDetails.forEach(x => {
            this.serviceSubscription = x.servicesubscription;
            this.subscriptionPlan = x.subscriptionPlan;
            var subscriptionLocation = x.subscriptionLocation;
            this.categoryDetails.forEach(c => {
              this.cplDetails = subscriptionLocation.filter(s => s.categoryId === c.categoryId)
              if (this.cplDetails.length > 0 && this.serviceSubscription.length > 0) {
                var cpl = this.cplDetails;
                cpl.forEach(cp=>{
                  this.serviceSubscription = this.serviceSubscription.filter(ss => ss.subscription == cp.subscriptionId)
                })
             
              }
            })
          })
        }
      });
  }
  getLeadDetailsByVendorId() {
    this.vendorDashboardService.getLeadDetailsByVendorId(this.vendorId.toString())
      .subscribe((response) => {
        if (response) {
          this.leadDetails = response;
        }
      });
  }
  getmultiDetailsByServiceId(serviceId: number) {
    this.serviceTypes = [];
    this.vendorDashboardService.getmultiDetailsByServiceId(serviceId)
      .subscribe((response) => {
        if (response) {
          this.serviceTypes.push(response[0])
        }
      });
  }
  getQuestionaireByVendorId() {
    this.vendorDashboardService.getQuestionaireByVendorId(this.vendorId)
      .subscribe((response) => {
        if (response) {
          this.questionAnswers = response;
          this.questionAnswers.forEach(x => {
            this.getmultiDetailsByServiceId(x.question.serviceType);
          })
        }
      });
  }

  getTransactionDetails() {
    if(Number.isInteger(Number(this.vendorId)) && this.vendorId != 0)
    {
      this.walletService.getTransactionsDetails(this.vendorId).subscribe((response) => {
        if (response) {
          this.transDetails = response;
        }
      });
    }
  }

  getLeadTotalCountAmount() {
      this.vendorDashboardService.getLeadCount(this.vendorId.toString(), true, false).subscribe((response) => {
        if (response) {
          this.cpcLeadCount = response.count;
        }
      });
      this.vendorDashboardService.getLeadCount(this.vendorId.toString(), false, true).subscribe((response) => {
        if (response) {
          this.commLeadCount = response.count;
        }
      });
      this.vendorDashboardService.getLeadTotalAmount(this.vendorId.toString(), true, false).subscribe((response) => {
        if (response) {
          this.cpcTotalAmount = response.totalAmt;
        }
      });
      this.vendorDashboardService.getLeadTotalAmount(this.vendorId.toString(), false, true).subscribe((response) => {
        if (response) {
          this.commTotalAmount = response.totalAmt;
        }
      });
  }

}
