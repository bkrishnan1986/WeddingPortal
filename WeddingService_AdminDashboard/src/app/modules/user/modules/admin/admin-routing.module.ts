import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
// import { HomeComponent } from './components/home/home.component';

const routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        // component: HomeComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminRoutingModule { }
