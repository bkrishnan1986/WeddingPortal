import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CreateLeadComponent } from "./components/create-lead/create-lead.component";
import { ViewLeadComponent } from "./components/view-lead/view-lead.component";
import { LeadDetailsComponent } from "./components/lead-details/lead-details.component";
import { LeadApproveAuthViewComponent } from './components/lead-approve-auth-view/lead-approve-auth-view.component';
import { AssignLeadComponent } from './components/assign-lead/assign-lead.component';

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
    },
    {
        path: 'lead-details/:id/:authstatus',
        component: LeadDetailsComponent
    },
    {
        path:'lead-approve-auth',
        component:LeadApproveAuthViewComponent
    },
    
    {
        path:'assign-lead',
        component:AssignLeadComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class LeadManagementRoutingModule { }
