import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { VendorManagmentService } from './service/vendor-managment.service';
import { VendorBasicDetailsComponent } from './components/vendor-basic-details/vendor-basic-details.component';
import { VendorSocialmediaDetailsComponent } from './components/vendor-socialmedia-details/vendor-socialmedia-details.component';
import { VendorAddressDetailsComponent } from './components/vendor-address-details/vendor-address-details.component';
import { VendorBudgetDetailsComponent } from './components/vendor-budget-details/vendor-budget-details.component';
import { VendorVideolinksDetailsComponent } from './components/vendor-videolinks-details/vendor-videolinks-details.component';
import { VendorManagementRoutingModule } from './vendor-management-routing.module';
import { VendorKYCFormComponent } from './components/vendor-kycform/vendor-kycform.component';
import { VendorSubscriptionComponent } from './components/vendor-subscription/vendor-subscription.component';
import { VendorCategoryDetailsComponent } from './components/vendor-category-details/vendor-category-details.component';
import { VendorPaymentSuccessComponent } from './components/vendor-subscription/vendor-payment-success/vendor-payment-success.component';
import { VendorOtpComponent } from './components/vendor-otp/vendor-otp.component';

const modules = [VendorManagementRoutingModule, SharedModule];
const providers = [VendorManagmentService];
const components = [
  VendorBasicDetailsComponent,
  VendorSocialmediaDetailsComponent,
  VendorAddressDetailsComponent,
  VendorBudgetDetailsComponent,
  VendorVideolinksDetailsComponent,
  VendorKYCFormComponent,
  VendorSubscriptionComponent,
  VendorCategoryDetailsComponent,
  VendorPaymentSuccessComponent,
  VendorOtpComponent
];

@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})

export class VendorManagementModule { }
