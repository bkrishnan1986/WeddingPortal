import { NgModule } from '@angular/core';
import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { LoginComponent } from './components/login/login.component';
import { LoginService } from './services/login.service';


const modules = [AuthRoutingModule, SharedModule];
const components = [LoginComponent];
const providers = [LoginService];

@NgModule({
    imports: modules,
    declarations: components,
    providers
})

export class AuthModule { }
