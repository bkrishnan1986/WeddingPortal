import { NgModule } from '@angular/core';
import { SuperAdminRoutingModule } from './super-admin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { HomeComponent } from './home/home.component';

const modules = [SuperAdminRoutingModule, SharedModule];
const providers = [];
const components = [HomeComponent];

@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})
export class SuperAdminModule { }
