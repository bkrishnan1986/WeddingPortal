import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UserFormComponent } from './components/user-form/user-form.component';
import { UsersListComponent } from "./components/users-list/users-list.component";

const routes = [
    {
        path: '',
        component: UsersListComponent
    },
    {
        path: 'create-user',
        component: UserFormComponent
    },
    {
        path: 'edit-user/:id',
        component: UserFormComponent
    },
    {
        path: 'view-user/:id',
        component: UserFormComponent
    },


];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminPanelRoutingModule { }
