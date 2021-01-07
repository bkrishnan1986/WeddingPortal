import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { WalletManagementRoutingModule } from './wallet-management-routing.module';
import { ManualWalletAdjustmentComponent } from './manual-wallet-adjustment/manual-wallet-adjustment.component';
import { ManualWalletDeductionComponent } from './manual-wallet-deduction/manual-wallet-deduction.component';
import { PauseReleaseComponent } from './pause-release/pause-release.component';
import { VendorWalletComponent } from './vendor-wallet/vendor-wallet.component';
import { ViewWalletComponent } from './view-wallet/view-wallet.component';
import { WalletRuleComponent } from './wallet-rule/wallet-rule.component';
import { WalletServiceService } from './services/wallet-service.service';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect'


const modules = [WalletManagementRoutingModule, SharedModule, TableModule, DropdownModule, MultiSelectModule];
const providers = [WalletServiceService];
const components = [ManualWalletAdjustmentComponent, ManualWalletDeductionComponent, PauseReleaseComponent, VendorWalletComponent,
  ViewWalletComponent,
  WalletRuleComponent];
@NgModule({
  imports: modules,
  declarations: components,
  exports: components,
  providers
})
export class WalletManagementModule { }
