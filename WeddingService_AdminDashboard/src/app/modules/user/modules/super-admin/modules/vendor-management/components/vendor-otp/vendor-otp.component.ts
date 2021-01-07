import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { PartialSaveService } from '../../service/partial-save.service';
import { VendorManagmentService } from '../../service/vendor-managment.service';
import { SubscriptionLike as ISubscription } from 'rxjs';

@Component({
  selector: 'app-vendor-otp',
  templateUrl: './vendor-otp.component.html',
  styleUrls: ['./vendor-otp.component.css']
})
export class VendorOtpComponent implements OnInit, OnDestroy {

  sendOptReq: ISubscription;
  verifyReq: ISubscription;

  mobileNo;
  district;
  otp;
  vendorID;
  checkOtp: boolean;

  constructor(
    private router: Router,
    private service: VendorManagmentService,
    private partialService: PartialSaveService
  ) { }

  ngOnInit(): void {
    debugger;
    this.checkOtp = false;
    // this.vendorID = this.partialService.getVendorId;
    this.vendorID = 27;
    const obj = this.partialService.getPartialBasicDetails();
    // this.mobileNo = obj.primaryMobileNumber;
    this.mobileNo = '+918129201900';
    // this.district = obj.companyLocation;
    this.district = 'TVM';

  }
  ngOnDestroy() {
    if (this.sendOptReq) {
      this.sendOptReq.unsubscribe();
    }
    if (this.verifyReq) {
      this.verifyReq.unsubscribe();
    }

  }
  verifyOtp() {
    const params = {
      otp: this.otp,
      profileId: this.vendorID,
    };
    this.sendOptReq = this.service.verifyOtp(params, this.vendorID).subscribe((Response) => {
     
        this.checkOtp = true;
     
    });
  }
  sendOtp() {
    const params = {
      mobileNumber: this.mobileNo,
      profileId: this.vendorID,
      createdBy: '1'
    };
    this.sendOptReq = this.service.sendOtpRequest(params, this.vendorID).subscribe((Response) => {
      if (Response) {

      } else {
        alert('Please try again');
      }
    });
  }
  next() {
    this.router.navigate([`app/superadmin/vendor-management/subscription`]);
  }
}
