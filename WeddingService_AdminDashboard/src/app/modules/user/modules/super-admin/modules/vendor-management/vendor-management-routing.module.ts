import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { VendorAddressDetailsComponent } from './components/vendor-address-details/vendor-address-details.component';
import { VendorBasicDetailsComponent } from './components/vendor-basic-details/vendor-basic-details.component';
import { VendorBudgetDetailsComponent } from './components/vendor-budget-details/vendor-budget-details.component';
import { VendorSocialmediaDetailsComponent } from './components/vendor-socialmedia-details/vendor-socialmedia-details.component';
import { VendorVideolinksDetailsComponent } from './components/vendor-videolinks-details/vendor-videolinks-details.component';
import { VendorKYCFormComponent } from './components/vendor-kycform/vendor-kycform.component';
import { VendorSubscriptionComponent } from './components/vendor-subscription/vendor-subscription.component';
import { VendorCategoryDetailsComponent } from './components/vendor-category-details/vendor-category-details.component';
import { VendorOtpComponent } from './components/vendor-otp/vendor-otp.component';
import { VendorPaymentSuccessComponent } from './components/vendor-subscription/vendor-payment-success/vendor-payment-success.component';

const routes = [
    {
        path: 'vendor-dashboard',
        component: VendorBasicDetailsComponent
    },
    {
        path: 'basic-details',
        component: VendorBasicDetailsComponent
    },
    {
        path: 'socialmedia-details',
        component: VendorSocialmediaDetailsComponent
    },
    {
        path: 'address-details',
        component: VendorAddressDetailsComponent
    },
    {
        path: 'budget-details',
        component: VendorBudgetDetailsComponent
    },
    {
        path: 'videolinks',
        component: VendorVideolinksDetailsComponent
    },
    {
        path: 'KYCForm',
        component: VendorKYCFormComponent
    },
    {
        path: 'subscription',
        component: VendorSubscriptionComponent
    },
    {
        path: 'CategoryDetails',
        component: VendorCategoryDetailsComponent
    },
    {
        path: 'otp',
        component: VendorOtpComponent
    },
    {
        path: 'payment-success',
        component: VendorPaymentSuccessComponent
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class VendorManagementRoutingModule { }
