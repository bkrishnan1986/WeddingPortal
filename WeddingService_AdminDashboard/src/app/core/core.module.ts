import { NgModule, Optional, SkipSelf, ModuleWithProviders } from '@angular/core';
import { HttpBaseService } from './services/http-base.service';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './services/auth.service';
import { BrowserModule } from '@angular/platform-browser';

const modules = [HttpClientModule, BrowserModule];
const providers = [HttpBaseService, AuthService];

@NgModule({
  declarations: [],
  imports: [modules],
  exports: [modules]
})

export class CoreModule {

  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(`${parentModule} has already been loaded. Import Core modules in the AppModule only.`);
    }
  }

  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers
    };
  }
}
