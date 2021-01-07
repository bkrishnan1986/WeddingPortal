import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardLayoutComponent } from './dashboard-layout/dashboard-layout.component';

const routes = [
    {
        path: '',
        component: DashboardLayoutComponent,
        children: [
            {
                path: 'superadmin',
                loadChildren: () => import('./modules/super-admin/super-admin.module').then(m => m.SuperAdminModule),
            },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class UserRoutingModule { }
