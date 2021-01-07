import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaymentManagementRoutingModule } from './payment-management-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { PaymentBookComponent } from './components/payment-book/payment-book.component';
import { PaymentDeskComponent } from './components/payment-desk/payment-desk.component';
import { PaymentRefundComponent } from './components/payment-refund/payment-refund.component';

const modules = [PaymentManagementRoutingModule, SharedModule];
const providers = [];
const components = [
  PaymentBookComponent,
  PaymentDeskComponent,
  PaymentRefundComponent
];

@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})
export class PaymentManagementModule { }
