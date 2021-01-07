import { NgModule } from '@angular/core';
import { AdminPanelRoutingModule } from './admin-panel-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { UsersListComponent } from './components/users-list/users-list.component';
import { UserFormComponent } from './components/user-form/user-form.component';
import { UserCreationService } from './services/user-creation.service';

const modules = [AdminPanelRoutingModule, SharedModule];
const providers = [UserCreationService];
const components = [
  UsersListComponent,
  UserFormComponent
];

@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})

export class AdminPanelModule { }
