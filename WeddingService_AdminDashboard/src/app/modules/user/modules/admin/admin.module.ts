import { NgModule } from '@angular/core';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
// import { HomeComponent } from './components/home/home.component';

const modules = [AdminRoutingModule, SharedModule];
const providers = [];
const components = [];

@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})
export class SuperAdminModule { }
