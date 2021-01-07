import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { UserRoutingModule } from './user-routing.module';
import { DashboardLayoutComponent } from './dashboard-layout/dashboard-layout.component';
import { SidebarMenuComponent } from './dashboard-layout/sidebar-menu/sidebar-menu.component';
import { ControlSidebarComponent } from './dashboard-layout/control-sidebar/control-sidebar.component';
import { HeaderComponent } from "./dashboard-layout/header/header.component";

const modules = [UserRoutingModule, SharedModule];
const components = [DashboardLayoutComponent, SidebarMenuComponent, ControlSidebarComponent, HeaderComponent];
const providers = [];

@NgModule({
    imports: modules,
    declarations: components,
    exports: components,
    providers
})

export class UserModule { }
