import { NgModule, ModuleWithProviders } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { MulticodesService } from './services/multicodes.service';
import { MultidetailsService } from './services/multidetails.service';
import { BsModalService } from 'ngx-bootstrap/modal';

const modules = [
    FormsModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    CommonModule,
    TabsModule.forRoot(),
    NgMultiSelectDropDownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    PaginationModule.forRoot(),
    ToastrModule.forRoot()
];
const components = [];
const providers = [DatePipe, MulticodesService, MultidetailsService, BsModalService];

@NgModule({
    imports: modules,
    declarations: components,
    exports: [components, modules]
})

export class SharedModule {

    static forRoot(): ModuleWithProviders<SharedModule> {
        return {
            ngModule: SharedModule,
            providers
        };
    }
}
