import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { VendorBookedComponent } from './component/vendor-booked/vendor-booked.component';
import { VendorBookedDetailsComponent } from './component/vendor-booked-details/vendor-booked-details.component';

const routes = [
    {
        path: 'vendor-booked-view',
        component: VendorBookedComponent
    },
    {
        path: 'vendor-booked-details',
        component: VendorBookedDetailsComponent
    },
    {
        path: 'wallet-management',
        loadChildren: () => import('./component/wallet-management/wallet-management.module').then(m => m.WalletManagementModule)
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class VendorDashboardRoutingModule { }
