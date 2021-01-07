import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { environment } from 'src/environments/environment';
import { KycDashboardModel } from '../../vendor-management/model/kyc.model';
import { CategoryDetails } from '../models/category-details.model';
import { LeadCount } from '../models/leadcount.model';
import { LeadDetails, Leads } from '../models/leads.model';
import { LeadTotalAmount } from '../models/leadtotalamt.model';
import { MultiDetailModel } from '../models/multidetails.model';
import { PackageDetails } from '../models/package-details.model';
import { VendorProfile } from '../models/user-profile.model';
import { VendorQuestionAnswers } from '../models/vendor-question-answer.model';
import { WalletBalance } from '../models/wallet-balance.model';
import { WalletRule } from '../models/wallet-rule.model';

@Injectable()
export class VendorDashboardService extends HttpBaseService {

  identityUrl = environment.api.identityUrl;
  vendorUrl = environment.api.baseUrl;
  leadUrl = environment.api.leadUrl;
  constructor(private http: HttpClient) {
    super();
  }

  getAllUserProfiles() {
    const url = `${this.vendorUrl}/api/v1/profiles`;
    return this.http.get<VendorProfile>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getVendorBasicDetailsByVendorId(vendorId: number) {
    const url = `${this.vendorUrl}/api/v1/profiles/${vendorId}`;
    return this.http.get<VendorProfile>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getCategoryDetailsByVendorId(vendorId: number) {
    const url = `${this.vendorUrl}/api/v1/vendor/vendorprofile/${vendorId}`;
    return this.http.get<CategoryDetails>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getWalletBalanceDetails(vendorId: number) {
    const url = `${this.vendorUrl}/wallet?VendorId=${vendorId}`;
    return this.http.get<WalletBalance>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getWalletRuleById(serviceId: number) {
    const url = `${this.vendorUrl}/walletRule?Value=${serviceId}&IsForServiceCategory=true`;
    return this.http.get<WalletRule>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getKYCDetailsByVendorId(vendorId: number) {
    const url = `${this.vendorUrl}/api/v1/profiles/${vendorId}/kyc`;
    return this.http.get<Array<KycDashboardModel>>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getmultiDetailsByServiceId(serviceId: number) {
    const url = `${this.vendorUrl}/vendormultidetails?Id=${serviceId}`;
    return this.http.get<MultiDetailModel>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getPackagesByVendorId(vendorId: number) {
    const url = `${this.vendorUrl}/api/v1/services/vendor/${vendorId}`;
    return this.http.get<PackageDetails>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getLeadDetailsByVendorId(vendorId: string) {
    const url = `${this.leadUrl}/leads/GetLeadsByVendor?VendorId=${vendorId}`;
    return this.http.get<Array<LeadDetails>>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getQuestionaireByVendorId(vendorId: number) {
    const url = `${this.vendorUrl}/servicequestion/${vendorId}/vendorquestionanswers`;
    return this.http.get<VendorQuestionAnswers>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getLeadCount(vendorId: string, IsForCPCLeadAssigned: boolean, IsForCommisionLeadAssigned: boolean) {
    const url = `${this.leadUrl}/leads/${vendorId}/GetLeadCount?IsForCPCLeadAssigned=${IsForCPCLeadAssigned}&IsForCommisionLeadAssigned=${IsForCommisionLeadAssigned}`;
    return this.http.get<LeadCount>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getLeadTotalAmount(vendorId: string, IsForCPCLeadAssigned: boolean, IsForCommisionLeadAssigned: boolean) {
    const url = `${this.leadUrl}/leads/${vendorId}/GetLeadTotalAmount?IsForCPCLeadAssigned=${IsForCPCLeadAssigned}&IsForCommisionLeadAssigned=${IsForCommisionLeadAssigned}`;
    return this.http.get<LeadTotalAmount>(url)
      .pipe(catchError(this.handleError)
      );
  }
}
