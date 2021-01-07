import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CreateLeadComponent } from "./components/create-lead/create-lead.component";
import { ViewLeadComponent } from "./components/view-lead/view-lead.component";
import { LeadDetailsComponent } from "./components/lead-details/lead-details.component";

const routes = [
    {
        path: '',
        component: CreateLeadComponent
    },
    {
        path: 'create-lead',
        component: CreateLeadComponent
    },
    {
        path: 'view-lead',
        component: ViewLeadComponent
    },
    {
        path: 'lead-details/:id',
        component: LeadDetailsComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class LeadManagementRoutingModule { }
