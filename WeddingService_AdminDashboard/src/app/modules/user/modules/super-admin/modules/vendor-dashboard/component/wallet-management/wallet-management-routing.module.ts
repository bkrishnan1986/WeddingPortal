import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { VendorBookedDetailsComponent } from '../vendor-booked-details/vendor-booked-details.component';
import { VendorBookedComponent } from '../vendor-booked/vendor-booked.component';
import { ManualWalletAdjustmentComponent } from './manual-wallet-adjustment/manual-wallet-adjustment.component';
import { ManualWalletDeductionComponent } from './manual-wallet-deduction/manual-wallet-deduction.component';
import { PauseReleaseComponent } from './pause-release/pause-release.component';
import { VendorWalletComponent } from './vendor-wallet/vendor-wallet.component';
import { ViewWalletComponent } from './view-wallet/view-wallet.component';
import { WalletRuleComponent } from './wallet-rule/wallet-rule.component';
const walletRoutes = [
  {
    path: 'manual-wallet-adjustment',
    component: ManualWalletAdjustmentComponent
  },
  {
    path: 'manual-wallet-deduction',
    component: ManualWalletDeductionComponent
  },
  {
    path: 'pause-release',
    component: PauseReleaseComponent
  },
  {
    path: 'vendor-wallet',
    component: VendorWalletComponent
  },
  {
    path: 'view-wallet',
    component: ViewWalletComponent
  },
  {
    path: 'wallet-rule',
    component: WalletRuleComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(walletRoutes)],
  exports: [RouterModule]
})
export class WalletManagementRoutingModule { }
