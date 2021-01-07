import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PaymentBookComponent } from './components/payment-book/payment-book.component';
import { PaymentDeskComponent } from './components/payment-desk/payment-desk.component';
import { PaymentRefundComponent } from './components/payment-refund/payment-refund.component';

const routes = [
    {
        path: 'payment-book',
        component: PaymentBookComponent
    },
    {
        path: 'payment-desk',
        component: PaymentDeskComponent
    },
    {
        path: 'payment-refund',
        component: PaymentRefundComponent
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class PaymentManagementRoutingModule { }
