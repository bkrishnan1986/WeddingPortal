import { NgModule } from '@angular/core';

import { SharedModule } from 'src/app/shared/shared.module';
import { LeadManagementRoutingModule } from './lead-management-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { CreateLeadComponent } from "./components/create-lead/create-lead.component";
import { ViewLeadComponent } from "./components/view-lead/view-lead.component";
import { LeadDetailsComponent } from "./components/lead-details/lead-details.component";
import { FollowupDetailsModalComponent } from "./components/followup-details-modal/followup-details-modal.component";
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect'
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

const modules = [
  LeadManagementRoutingModule,
  SharedModule,
  ToastrModule,
  TableModule,
  DropdownModule,
  MultiSelectModule,
  OwlDateTimeModule,
  OwlNativeDateTimeModule
];
const providers = [];
const components = [CreateLeadComponent, ViewLeadComponent, LeadDetailsComponent, FollowupDetailsModalComponent];

@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})
export class LeadManagementModule { }
