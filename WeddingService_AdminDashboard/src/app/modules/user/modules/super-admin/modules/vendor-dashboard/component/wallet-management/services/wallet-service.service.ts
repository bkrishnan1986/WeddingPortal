import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { environment } from 'src/environments/environment';
import { ApiResponseModel } from 'src/app/shared/models/api-response.model';
import { WalletLeadDetails } from '../model/wallet-lead-details';
import { TransactionDetails } from '../model/transaction-details.model';
import { WalletVendorDetails } from '../model/wallet-vendor-detail.model';

@Injectable({
  providedIn: 'root'
})
export class WalletServiceService extends HttpBaseService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };
  leadUrl = environment.api.leadUrl;
  identityUrl = environment.api.identityUrl;
  baseUrl = environment.api.baseUrl;

  constructor(private http: HttpClient) { super(); }

  getAllWalletMultidetails(id: string) {
    const url = `${this.baseUrl}/multidetails_wallet/${id}`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getAllWalletRules() {
    const url = `${this.baseUrl}/walletRule?IsForServiceCategory=true`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getAllVendorMultidetails(id: string) {
    const url = `${this.baseUrl}/vendormultidetails/${id}`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getVendorSearchDetails(id: string) {
    const url = `${this.baseUrl}//${id}`;  // url unknown
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getWalletRulesDetails(id: number) {
    const url = `${this.baseUrl}/walletRule/${id}`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  gettWalletRulesByCategory(id: number) {
    const url = `${this.baseUrl}/walletRule?Value=${id}&IsForServiceCategory=true`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  saveWalletRule(params) {
    const url = `${this.baseUrl}/walletRule`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }
  updateWalletRule(params, id) {
    const url = `${this.baseUrl}/walletRule/${id}`;
    return this.http.put<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }
  deleteWalletRule( id) {
    const url = `${this.baseUrl}/walletRule/${id}`;
    return this.http.delete<ApiResponseModel>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getLeadDetails(leadId: string) {
    const url = `${this.leadUrl}/leads/${leadId}`;
    return this.http.get<WalletLeadDetails>(url)
      .pipe(catchError(this.handleError)
      );
  }
  saveWalletDeduction(params) {
    const url = `${this.baseUrl}/walletDeduction`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }
  saveManualAdjust(params) {
    const url = `${this.baseUrl}/walletAdjustment`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }

  getTransactionsDetails(vendorId: number) {
    const url = `${this.baseUrl}/transactions?Value=${vendorId}&IsForVendor=true`;
    return this.http.get<Array<TransactionDetails>>(url)
      .pipe(catchError(this.handleError)
      );
  }

  updateWalletStatus(id, IsPaused, IsReleased, IsChurned) {
    const url = `${this.baseUrl}/wallet/${id}/${IsPaused}/${IsReleased}/${IsChurned}`;
    return this.http.put<ApiResponseModel>(url, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
}

  getVendorWalletDetailsByVendorId(vendorId: string) {
    const url = `${this.baseUrl}/api/v1/services?Value=${vendorId}`;
    return this.http.get<Array<WalletVendorDetails>>(url)
      .pipe(catchError(this.handleError)
      );
  }
}