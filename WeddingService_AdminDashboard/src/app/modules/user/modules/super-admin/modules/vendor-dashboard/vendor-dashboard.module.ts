import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/shared.module';
import { VendorDashboardRoutingModule } from './vendor-dashboard-routing.module';

import { VendorBookedComponent } from './component/vendor-booked/vendor-booked.component';
import { VendorBookedDetailsComponent } from './component/vendor-booked-details/vendor-booked-details.component';
import { VendorDashboardService } from './services/vendor-dashboard.service';
import { GroupByPipe } from 'src/app/shared/pipe/group-by.pipe';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect'

const modules = [VendorDashboardRoutingModule, SharedModule, TableModule,  DropdownModule, MultiSelectModule];
const providers = [VendorDashboardService];
const components = [VendorBookedComponent, VendorBookedDetailsComponent, GroupByPipe];
@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})
export class VendorDashboardModule { }
