import { Component, OnInit, OnDestroy, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { CustomFormValidator } from 'src/app/shared/validators/custom-form.validator';
import { Constants } from 'src/app/shared/constants/constants';
import { PaymentModel } from '../../model/paymentModel';
import { PartialSaveService } from '../../service/partial-save.service';
import { VendorManagmentService } from '../../service/vendor-managment.service';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { IPayPalConfig } from 'ngx-paypal';
declare var paypal;
@Component({
  selector: 'app-vendor-subscription',
  templateUrl: './vendor-subscription.component.html',
  styleUrls: ['./vendor-subscription.component.css']
})
export class VendorSubscriptionComponent implements OnInit, OnDestroy {
  @ViewChild('paypal', { static: true }) paypalElement: ElementRef;
  netBanking: boolean = false
  product = {
    price: 777.77,
    description: 'used couch, decent condition',
    img: 'assets/couch.jpg'
  };
  vendorId ;
  paidFor = false;
  constructor(
    private router: Router,
    private service: VendorManagmentService,
    private partialService: PartialSaveService
  ) { }
  public payPalConfig?: IPayPalConfig;
  buttonText: string = '';
  districtPackage = new Array();
  selectedPackage = [];
  paymentMode = [];
  totalAmount = 0;
  paymentModeId;
  formSubmitted = false;
  getPackageSubscript: ISubscription;
  getPaymentSubscript: ISubscription;
  saveSubscript: ISubscription;
  savePackageSubcript: ISubscription;
  saveTopUpSubcript: ISubscription;


  subForm = new FormGroup({
    TDSisapplicable: new FormControl(),
    Paymentmethod: new FormControl('',
      Validators.compose([Validators.required, CustomFormValidator.cannotContainSpace]))
  });

  get form() {
    return this.subForm.controls;
  }

  ngOnInit(): void {
    this.loadStripe();
    // this.vendorId = this.partialService.getVendorNo();
    this.vendorId = 1;
    this.buttonText = 'Select this package';
    this.getPackageSubscript = this.service.getPackages(this.vendorId)
      .subscribe((response) => {
        if (response) {
          this.districtPackage = response;
        }
      });
    // this.districtPackage = [{ "servicesubscription": [{ "id": 10, "serviceId": 4, "serviceName": "Bridal Wear", "subscription": 4, "subscriptionName": "Ruby", "subscribedOn": "2020-05-16T15:11:16", "expiry": "2021-05-16T15:11:16", "paidAmount": 2500.00, "paymentStatus": 47, "paymentStatusValue": "Pending", "valletBalance": null, "aprovalStatus": 0, "aprovalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-12-16T15:16:12", "updatedBy": null, "updatedAt": null }], "subscriptionLocation": [{ "id": 3, "subscriptionId": 4, "locationId": 18, "locationName": "TVM", "categoryId": 14, "categoryName": "Bridal Wear", "packageType": 45, "packageName": "Generic", "mode": 32, "modeName": "CPL", "registrationFee": 4500.00, "serviceFee": 500.00, "cgstRatePercentage": 0, "cgstamount": 0.00, "sgstRatePercentage": 0, "sgstamount": 0.00, "igstRatePercentage": 0, "igstamount": 0.00, "gstRatePercentage": 0, "gstamount": 0.00, "cplamount": 0.00, "commissionAmount": 0.00, "totalPrice": 5000.00, "active": 1, "createdBy": 1, "createdAt": "2020-12-16T15:09:50", "updatedBy": null, "updatedAt": null }], "subscriptionPlan": [{ "id": 4, "parentsubscriptionId": null, "name": "Ruby", "description": "Ruby", "mode": 32, "modeName": "CPL", "registrationFee": 8000.00, "serviceFee": 1500.00, "cgstRatePercentage": null, "cgstamount": null, "sgstRatePercentage": null, "sgstamount": null, "igstRatePercentage": null, "igstamount": null, "gstRatePercentage": null, "gstamount": null, "cplamount": null, "commissionAmount": null, "totalPrice": 9500.00, "validity": 6, "validityUnit": 38, "validityUnitName": "Months", "approvalStatus": 39, "approvalStatusName": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-05-20T00:00:00", "updatedBy": null, "updatedAt": null }], "subscriptionbenefit": [{ "id": 11, "subscriptionId": 4, "subscriptionValue": "Ruby", "benefit": 41, "benefitValue": "Cost Per Lead", "count": 0, "approvalStatus": 39, "approvalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-05-02T00:00:00", "updatedBy": null, "updatedAt": null }, { "id": 12, "subscriptionId": 4, "subscriptionValue": "Ruby", "benefit": 42, "benefitValue": "Photos", "count": 2, "approvalStatus": 39, "approvalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-05-02T00:00:00", "updatedBy": null, "updatedAt": null }, { "id": 13, "subscriptionId": 4, "subscriptionValue": "Ruby", "benefit": 43, "benefitValue": "Videos", "count": 1, "approvalStatus": 39, "approvalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-05-02T00:00:00", "updatedBy": null, "updatedAt": null }], "servicetopup": [{ "id": 9, "serviceId": 4, "serviceName": "Bridal Wear", "topUpId": 7, "topUpName": "Ruby TopUp", "topUpOn": "2020-05-16T16:33:13", "expiry": "2021-12-16T16:33:13", "paidAmount": 1500.00, "paymentStatus": 49, "paymentStatusValue": "Pending", "valletBalance": null, "approvalStatus": 39, "approvalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-12-16T16:34:44", "updatedBy": null, "updatedAt": null }], "topUp": [{ "id": 7, "topUpType": 51, "topUpTypeName": "Weekly", "name": "Ruby TopUp", "description": "Ruby TopUp", "mode": 32, "modeName": "CPL", "price": 3000.00, "cgstRatePercentage": 0, "cgstamount": 0.00, "sgstRatePercentage": 0, "sgstamount": 0.00, "igstRatePercentage": 0, "igstamount": 0.00, "gstRatePercentage": 0, "gstamount": 0.00, "cplamount": 2500.00, "commissionAmount": 0.00, "totalPrice": 55000.00, "active": 1, "createdBy": 1, "createdAt": "2020-12-16T16:24:49", "updatedBy": null, "updatedAt": null }], "topupbenefit": [{ "id": 11, "topUpId": 7, "topUpName": "Ruby TopUp", "benefit": 42, "benefitName": "Photos", "count": 2, "approvalStatus": 49, "approvalStatusName": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-12-16T16:29:11", "updatedBy": null, "updatedAt": null }, { "id": 12, "topUpId": 7, "topUpName": "Ruby TopUp", "benefit": 43, "benefitName": "Videos", "count": 2, "approvalStatus": 49, "approvalStatusName": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-12-16T16:29:21", "updatedBy": null, "updatedAt": null }], "id": 4, "serviceType": 14, "serviceName": "Bridal Wear", "description": "Bridal Wear", "experience": 5.00, "experienceUnit": 28, "award": null, "rateType": 35, "priceRangeStart": 15000.00, "priceRangeEnd": 35000.00, "currency": 30, "currencyName": "Rupees", "vendorId": 1, "active": 1, "createdBy": 1, "createdAt": "2020-05-20T00:00:00", "updatedBy": null, "updatedAt": null }, { "servicesubscription": [{ "id": 11, "serviceId": 5, "serviceName": "Groom Wear", "subscription": 5, "subscriptionName": "Sapphire", "subscribedOn": "2020-05-16T15:11:16", "expiry": "2021-05-16T15:11:16", "paidAmount": 2500.00, "paymentStatus": 47, "paymentStatusValue": "Pending", "valletBalance": null, "aprovalStatus": 0, "aprovalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-12-16T15:16:28", "updatedBy": null, "updatedAt": null }], "subscriptionLocation": [{ "id": 4, "subscriptionId": 5, "locationId": 19, "locationName": "Kollam", "categoryId": 15, "categoryName": "Groom Wear", "packageType": 46, "packageName": "Specific", "mode": 32, "modeName": "CPL", "registrationFee": 4500.00, "serviceFee": 500.00, "cgstRatePercentage": 0, "cgstamount": 0.00, "sgstRatePercentage": 0, "sgstamount": 0.00, "igstRatePercentage": 0, "igstamount": 0.00, "gstRatePercentage": 0, "gstamount": 0.00, "cplamount": 0.00, "commissionAmount": 0.00, "totalPrice": 5000.00, "active": 1, "createdBy": 1, "createdAt": "2020-12-16T15:10:14", "updatedBy": null, "updatedAt": null }], "subscriptionPlan": [{ "id": 5, "parentsubscriptionId": null, "name": "Sapphire", "description": "Sapphire", "mode": 32, "modeName": "CPL", "registrationFee": 8000.00, "serviceFee": 1500.00, "cgstRatePercentage": null, "cgstamount": null, "sgstRatePercentage": null, "sgstamount": null, "igstRatePercentage": null, "igstamount": null, "gstRatePercentage": null, "gstamount": null, "cplamount": null, "commissionAmount": null, "totalPrice": 9500.00, "validity": 6, "validityUnit": 38, "validityUnitName": "Months", "approvalStatus": 39, "approvalStatusName": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-05-20T00:00:00", "updatedBy": null, "updatedAt": null }], "subscriptionbenefit": [{ "id": 14, "subscriptionId": 5, "subscriptionValue": "Sapphire", "benefit": 42, "benefitValue": "Photos", "count": 2, "approvalStatus": 39, "approvalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-05-02T00:00:00", "updatedBy": null, "updatedAt": null }, { "id": 15, "subscriptionId": 5, "subscriptionValue": "Sapphire", "benefit": 43, "benefitValue": "Videos", "count": 2, "approvalStatus": 39, "approvalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-05-02T00:00:00", "updatedBy": null, "updatedAt": null }], "servicetopup": [{ "id": 10, "serviceId": 5, "serviceName": "Groom Wear", "topUpId": 8, "topUpName": "Ruby TopUp", "topUpOn": "2020-05-16T16:33:13", "expiry": "2021-12-16T16:33:13", "paidAmount": 1500.00, "paymentStatus": 49, "paymentStatusValue": "Pending", "valletBalance": null, "approvalStatus": 39, "approvalStatusValue": "Pending", "active": 1, "createdBy": 1, "createdAt": "2020-12-16T16:34:55", "updatedBy": null, "updatedAt": null }], "topUp": [{ "id": 8, "topUpType": 52, "topUpTypeName": "Monthly", "name": "Ruby TopUp", "description": "Ruby TopUp", "mode": 32, "modeName": "CPL", "price": 4500.00, "cgstRatePercentage": 0, "cgstamount": 0.00, "sgstRatePercentage": 0, "sgstamount": 0.00, "igstRatePercentage": 0, "igstamount": 0.00, "gstRatePercentage": 0, "gstamount": 0.00, "cplamount": 2500.00, "commissionAmount": 0.00, "totalPrice": 75000.00, "active": 1, "createdBy": 1, "createdAt": "2020-12-16T16:25:39", "updatedBy": null, "updatedAt": null }], "topupbenefit": [], "id": 5, "serviceType": 15, "serviceName": "Groom Wear", "description": "Bridal Wear", "experience": 5.00, "experienceUnit": 28, "award": null, "rateType": 35, "priceRangeStart": 20000.00, "priceRangeEnd": 30000.00, "currency": 30, "currencyName": "Rupees", "vendorId": 1, "active": 1, "createdBy": 1, "createdAt": "2020-05-20T00:00:00", "updatedBy": null, "updatedAt": null }, { "servicesubscription": [], "subscriptionLocation": null, "subscriptionPlan": null, "subscriptionbenefit": null, "servicetopup": [], "topUp": null, "topupbenefit": null, "id": 6, "serviceType": 16, "serviceName": "Photography", "description": "Bridal Wear", "experience": 5.00, "experienceUnit": 28, "award": null, "rateType": 35, "priceRangeStart": 20000.00, "priceRangeEnd": 30000.00, "currency": 30, "currencyName": "Rupees", "vendorId": 1, "active": 1, "createdBy": 1, "createdAt": "2020-05-20T00:00:00", "updatedBy": null, "updatedAt": null }, { "servicesubscription": [], "subscriptionLocation": null, "subscriptionPlan": null, "subscriptionbenefit": null, "servicetopup": [], "topUp": null, "topupbenefit": null, "id": 7, "serviceType": 16, "serviceName": "Bridal Wear", "description": "Bridal Wear", "experience": 5.00, "experienceUnit": 28, "award": null, "rateType": 35, "priceRangeStart": 20000.00, "priceRangeEnd": 30000.00, "currency": 30, "currencyName": "Rupees", "vendorId": 1, "active": 1, "createdBy": 1, "createdAt": "2020-05-20T00:00:00", "updatedBy": null, "updatedAt": null }]

    this.getPaymentSubscript = this.service.getAllWalletMultidetails(Constants.PaymentMode)
      .subscribe((response) => {
        if (response) {
          this.paymentMode = response;
        }
      });
    this.paymentMode = [{ id: 1, value: 'Online' }, { id: 2, value: 'Cash' }, { id: 3, value: 'Cheque' }]
  }

  pay(amount) {
    //Stripe
    var handler = (<any>window).StripeCheckout.configure({
      key: 'pk_test_51HoOwWHliYr5pqSBZbmsyH1zZP0nkDGeJYO8YLcjfW4AD1RUtTLzMOtwRwHq3fNpHhO2ibgf9i4yjh6T50xi1TWj00jDsCfBAq',
      locale: 'auto',
      token: function (token: any) {
        // You can access the token ID with `token.id`.
        // Get the token ID to your server-side code for use.
        console.log(token)
        alert('Token Created!!');
        this.router.navigate([`/app/superadmin/vendor-management/payment-success`]);
      }
    });

    handler.open({
      name: 'Demo Site',
      description: '2 widgets',
      amount: amount * 100
    });

  }
  loadStripe() {
    //Stripe
    if (!window.document.getElementById('stripe-script')) {
      var s = window.document.createElement("script");
      s.id = "stripe-script";
      s.type = "text/javascript";
      s.src = "https://checkout.stripe.com/checkout.js";
      window.document.body.appendChild(s);
    }
  }

  addPackage(x, k, index: number, p, type: string) {

    debugger;
    if (p) {
      x.locationName = p.locationName;
      if (this.selectedPackage.length > 0 && this.selectedPackage.some(x => x.locationName == p.locationName) && type === 'package')
        alert('Only a single package can  be selected under a location')
      // else if (this.selectedPackage.length > 0 && this.selectedPackage.some(p => p.id == x.id))
      //   alert('Only a single package can  be selected under a location')
      else {
        let serviceId; let subscription; let expiryDate;


        if (type === 'package') {
          k.servicesubscription.forEach(i => {
            if (x.id === i.subscription) {
              serviceId = i.serviceId;
              subscription = i.subscription;
            }
          });
          if (x.validityUnitName === "Months") {
            expiryDate = new Date(new Date().getTime() + ((x.validityUnit * 30) * 24 * 60 * 60 * 1000));
          }
          this.selectedPackage.push({
            locationName: p.locationName,
            serviceId: serviceId,
            subscription: subscription,
            Category: k.serviceName,
            Package: x.name,
            Amount: x.totalPrice,
            TopUpAmount: 0,
            Total: x.totalPrice,
            payableTaxes: x.cgstamount + x.gstamount,
            Netpayable: 0,
            subscribedOn: new Date(),
            paymentStatus: 39,
            approvalStatus: 39,
            paidAmount: x.totalPrice,
            createdBy: '1',
            type: type,
            PackageType: 56,// wallet
            expiry: expiryDate,
            gstamount: x.gstamount,
            cgstamount: x.cgstamount,
            cplamount: x.cplamount,
            igstamount: x.igstamount,
            sgstamount: x.sgstamount
          });
        } else {
          k.servicetopup.forEach(i => {
            if (x.id === i.topUpId) {
              serviceId = i.serviceId;
              subscription = i.topUpId;
            }
          });
          this.selectedPackage.push({
            locationName: p.locationName,
            serviceId: serviceId,
            topUpId: subscription,
            Category: k.serviceName,
            Package: x.name,
            Amount: x.totalPrice,
            TopUpAmount: 0,
            Total: x.totalPrice,
            payableTaxes: x.cgstamount + x.gstamount,
            Netpayable: 0,
            subscribedOn: new Date(),
            paymentStatus: 39,
            approvalStatus: 39,
            paidAmount: x.totalPrice,
            createdBy: '1',
            type: type,
            PackageType: 57,// wallet
            expiry: null,
            gstamount: x.gstamount,
            cgstamount: x.cgstamount,
            cplamount: x.cplamount,
            igstamount: x.igstamount,
            sgstamount: x.sgstamount
          });
        }

        this.totalAmount = 0;
        this.selectedPackage.forEach(t => {
          t.Netpayable = t.TopUpAmount + t.payableTaxes + t.Total;
          t.paidAmount = t.Netpayable;
          this.totalAmount = this.totalAmount + t.TopUpAmount + t.Total + t.payableTaxes;

        });
      }
    } else {
      this.selectedPackage.splice(index, 1);
      this.totalAmount = 0;
      this.selectedPackage.forEach(t => {
        this.totalAmount = this.totalAmount + t.TopUpAmount + t.Total + t.payableTaxes;
      });
    }
  }
  save(subForm) {
    this.formSubmitted = true;
    if (subForm.valid) {
      let params;
      params.TDSisapplicable = this.subForm?.controls['TDSisapplicable'].value;
      params.Paymentmethod = this.subForm?.controls['Paymentmethod'].value;
    }
    if (!this.netBanking) {
      this.packageDetailsSave();
      this.savePayment('offline', 'offline', 'offline')
    }

  }

  nextStep() {
    // this.router.navigate([`/app/superadmin/vendor-management/subscription`]);
  }
  paymentMethodChange(event: any, id) {
    this.paymentModeId = id;
    var value = event.target.innerText;
    if (value == "Online" && this.totalAmount > 0) {
      this.netBanking = true;
      // Paypal
      paypal
        .Buttons({
          createOrder: (data, actions) => {
            return actions.order.create({
              purchase_units: [
                {
                  description: `Vendorid ${this.vendorId} package price`,
                  amount: {
                    currency_code: 'USD',
                    value: 1
                  }
                }
              ]
            });
          },
          onApprove: async (data, actions) => {
            debugger
            const order = await actions.order.capture();
            this.paidFor = true;
            alert(order.status);
            if (order.status == "COMPLETED") {
              this.packageDetailsSave();
              this.savePayment(order.id, order.payer.payer_id, order.payer.name.given_name);
            }

          },
          onError: err => {
            console.log(err);
            alert('Please Try Again !');
          }
        })
        .render(this.paypalElement.nativeElement);

    } else {
      this.netBanking = false;
    }
  }
  ngOnDestroy() {
    if (this.getPackageSubscript) {
      this.getPackageSubscript.unsubscribe();
    }
    if (this.saveSubscript) {
      this.saveSubscript.unsubscribe();
    }
    if (this.savePackageSubcript) {
      this.saveSubscript.unsubscribe();
    }
    if (this.saveTopUpSubcript) {
      this.saveSubscript.unsubscribe();
    }
    if (this.getPaymentSubscript) {
      this.getPaymentSubscript.unsubscribe();
    }
  }

  private savePayment(id, payer_id, name) {
    const payment_Book = new Array<PaymentModel>();
    const objArray = { payment_Book: [] };

    this.selectedPackage.forEach(x => {
      const payment = new PaymentModel();

      payment.entryDate = new Date();
      payment.vendorId = this.vendorId;
      payment.package = x.serviceId;
      payment.packageType = x.PackageType;
      payment.paymentType = this.paymentModeId;
      payment.paymentAmount = x.paidAmount;
      payment.paymentStatus = 53;
      payment.gst = x.gstamount;
      payment.vendorStatus = 30;
      payment.paymentDate = new Date();
      payment.paymentMode = this.paymentModeId;
      payment.paymentRefNumber = id;
      payment.payeeName = name;
      payment.tidNumber = payer_id;
      payment.createdBy = '1';

      payment_Book.push(payment);
    });
    objArray.payment_Book = payment_Book;

    this.savePackageSubcript = this.service.savePackagePayment(objArray)
      .subscribe((response) => {
        if (response) {
          this.router.navigate([`/app/superadmin/vendor-management/payment-success`]);
        }
      });
  }
  private packageDetailsSave() {
    const savePackageParams = { serviceSubscription: [] };
    const saveTopUpParams = { serviceTopup: [] };

    this.selectedPackage.forEach(x => {
      let params;
      if (x.type === 'package') {
        params = {
          serviceId: x.serviceId,
          subscription: x.subscription,
          subscribedOn: x.subscribedOn,
          expiry: x.expiry,
          paidAmount: x.paidAmount,
          paymentStatus: x.paymentStatus,
          approvalStatus: x.approvalStatus,
          createdBy: x.createdBy
        };
        savePackageParams.serviceSubscription.push(params);
      } else {
        this.selectedPackage.forEach(t => {
          if (t.locationName === x.locationName && t.type === 'package') {
            x.expiry = t.expiry;
          }
        });
        params = {
          serviceId: x.serviceId,
          topUpId: x.topUpId,
          topUpOn: x.topUpOn,
          expiry: x.expiry,
          paidAmount: x.paidAmount,
          paymentStatus: x.paymentStatus,
          approvalStatus: x.approvalStatus,
          createdBy: x.createdBy
        };

        saveTopUpParams.serviceTopup.push(params);
      }
    });
    this.savePackageSubcript = this.service.savePackage(savePackageParams)
      .subscribe((response) => {
        if (response) {

        }
      });
    this.saveTopUpSubcript = this.service.saveTopUp(saveTopUpParams)
      .subscribe((response) => {
        if (response) {

        }
      });
  }
}
