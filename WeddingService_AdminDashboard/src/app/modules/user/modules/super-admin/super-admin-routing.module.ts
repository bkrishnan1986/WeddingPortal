import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'admin-panel',
        loadChildren: () => import('./modules/admin-panel/admin-panel.module').then(m => m.AdminPanelModule),
    },
    {
        path: 'vendor-management',
        loadChildren: () => import('./modules/vendor-management/vendor-management.module').then(m => m.VendorManagementModule),
    },
    {
        path: 'vendor-dashboard',
        loadChildren: () => import('./modules/vendor-dashboard/vendor-dashboard.module').then(m => m.VendorDashboardModule),
    },
    {
        path: 'lead-management',
        loadChildren: () => import('./modules/lead-management/lead-management.module').then(m => m.LeadManagementModule),
    },
    {
        path: 'payment',
        loadChildren: () => import('./modules/payment-management/payment-management.module').then(m => m.PaymentManagementModule),
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class SuperAdminRoutingModule { }
