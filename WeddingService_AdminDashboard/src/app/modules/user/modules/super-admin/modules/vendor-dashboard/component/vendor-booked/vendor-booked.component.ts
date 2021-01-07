import { Component, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { VendorDashboardService } from '../../services/vendor-dashboard.service';
import { WalletServiceService } from '../wallet-management/services/wallet-service.service';
import { WalletVendorDetails, servicesubscription } from '../wallet-management/model/wallet-vendor-detail.model'

@Component({
  selector: 'app-vendor-booked',
  templateUrl: './vendor-booked.component.html',
  styleUrls: ['./vendor-booked.component.css']
})
export class VendorBookedComponent implements OnInit {
  walletVendorDetails: WalletVendorDetails[];
  walletVendorId: number;
  walletVendorName: string;
  vendorServiceSubscription: servicesubscription[]; 
  isDisplayDetails: boolean = false; 
  vendorIdNumber: string = '';
  vendorNameList: any[] = [];
  vendorCategory: any[] = [];
  vendorPackage: any[] = [];
  vendorLocation: any[] = [];
  vendorStatusNames: any[] = [];
  vendorWalletStatus: any[] = [];
  constructor(
    private router: Router,
    private vendorDashboardService: VendorDashboardService,
    private service: WalletServiceService
  ) { }

  ngOnInit(): void {
    this.getVendorWalletDetailsByVendorId();
  }

  getVendorWalletDetailsByVendorId()
  {
    this.isDisplayDetails = false;
    this.service.getVendorWalletDetailsByVendorId(this.vendorIdNumber.toString()).subscribe((response) => {
      if (response) {
         this.walletVendorDetails = response;
         //console.log(response);
         this.vendorServiceSubscription = [];
         for(let i=0; i < this.walletVendorDetails.length; i++)
         {
            //console.log(this.walletVendorDetails[i]);
            if(this.walletVendorDetails[i].servicesubscription.length == 0)
            {
              let serviceSub = new servicesubscription;
              serviceSub.vendorId = this.walletVendorDetails[i].vendorId;
              serviceSub.vendorName = this.walletVendorDetails[i].vendorName;
              serviceSub.locationId = this.walletVendorDetails[i].locationId;
              serviceSub.locationName = this.walletVendorDetails[i].locationName;
              serviceSub.vendorStatusName = this.walletVendorDetails[i].vendorStatusName;
              this.vendorServiceSubscription.push(serviceSub);
            }
            else
            {
              for(let j=0; j < this.walletVendorDetails[i].servicesubscription.length; j++)
              {
                this.walletVendorDetails[i].servicesubscription[j].vendorId = this.walletVendorDetails[i].vendorId;
                this.walletVendorDetails[i].servicesubscription[j].vendorName = this.walletVendorDetails[i].vendorName;
                this.walletVendorDetails[i].servicesubscription[j].locationId = this.walletVendorDetails[i].locationId;
                this.walletVendorDetails[i].servicesubscription[j].locationName = this.walletVendorDetails[i].locationName;
                this.walletVendorDetails[i].servicesubscription[j].vendorStatusName = this.walletVendorDetails[i].vendorStatusName;
                this.vendorServiceSubscription.push(this.walletVendorDetails[i].servicesubscription[j]);
                this.vendorCategory.push({label : this.walletVendorDetails[i].servicesubscription[j].serviceName, value : this.walletVendorDetails[i].servicesubscription[j].serviceName});
                this.vendorPackage.push({label : this.walletVendorDetails[i].servicesubscription[j].subscriptionName, value : this.walletVendorDetails[i].servicesubscription[j].subscriptionName});
                this.vendorLocation.push({label : this.walletVendorDetails[i].servicesubscription[j].locationName, value : this.walletVendorDetails[i].servicesubscription[j].locationName});
                this.vendorStatusNames.push({label : this.walletVendorDetails[i].servicesubscription[j].vendorStatusName, value : this.walletVendorDetails[i].servicesubscription[j].vendorStatusName});
                this.vendorWalletStatus.push({label : this.walletVendorDetails[i].servicesubscription[j].walletStatusName, value : this.walletVendorDetails[i].servicesubscription[j].walletStatusName});
              }
            }
            this.vendorNameList.push({label : this.walletVendorDetails[i].vendorName, value : this.walletVendorDetails[i].vendorName})
         }
         this.isDisplayDetails = true;
         //console.log(this.vendorServiceSubscription);
         this.vendorNameList = this.vendorNameList.reduce((acc, val) => {
          if (!acc.find(el => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);


        this.vendorCategory = this.vendorCategory.reduce((acc, val) => {
          if (!acc.find(el => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);


        this.vendorPackage = this.vendorPackage.reduce((acc, val) => {
          if (!acc.find(el => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);

        this.vendorLocation = this.vendorLocation.reduce((acc, val) => {
          if (!acc.find(el => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);

        this.vendorStatusNames = this.vendorStatusNames.reduce((acc, val) => {
          if (!acc.find(el => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);

        this.vendorWalletStatus = this.vendorWalletStatus.reduce((acc, val) => {
          if (!acc.find(el => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);
        
      }
    });
  }

  viewVendorDetails(id: number) {
    let navigationExtras: NavigationExtras;
    navigationExtras = {
      queryParams: { vendorId: id },
    };
    this.router.navigate(['app/superadmin/vendor-dashboard/vendor-booked-details'], navigationExtras);
  }
}
