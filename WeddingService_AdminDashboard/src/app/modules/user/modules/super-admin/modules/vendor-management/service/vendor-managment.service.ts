import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { environment } from 'src/environments/environment';
import { ApiResponseModel } from 'src/app/shared/models/api-response.model';
import { CategoryModel } from '../model/category.model';
import { KycModel } from '../model/kyc.model';
import { DistrictModel } from '../model/district.model';

@Injectable({
  providedIn: 'root'
})
export class VendorManagmentService extends HttpBaseService {

  identityUrl = environment.api.identityUrl;
  baseUrl = environment.api.baseUrl;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  constructor(private http: HttpClient) { super(); }



  getAllCategory() {
    const url = `${this.baseUrl}/getAllCategory`;
    return this.http.get<CategoryModel>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getPackages(id) {
    const url = `${this.baseUrl}/api/v1/services/vendor/${id}`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getAllMultidetails(id: string) {
    const url = `${this.baseUrl}/multidetails_identity/${id}`;
    return this.http.get<DistrictModel>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getAllVendorMultidetails(id: string) {
    const url = `${this.baseUrl}/vendormultidetails/${id}`;
    return this.http.get<DistrictModel>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getWalletRulesDetails(id: number) {
    const url = `${this.baseUrl}/walletRule/${id}`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getAllWalletMultidetails(id: string) {
    const url = `${this.baseUrl}/multidetails_wallet/${id}`;
    return this.http.get<DistrictModel>(url)
      .pipe(catchError(this.handleError)
      );
  }
  getVendorNo() {
    const url = `${this.baseUrl}/api/v1/identity-management/profiles/userId?IsUser=false`;
    return this.http.get<any[]>(url)
      .pipe(catchError(this.handleError)
      );
  }
  GetAllServiceQuestionByServiceTypeId(categoryid: number) {
    const url = `${this.baseUrl}/servicequestion/servicequestions?Value=${categoryid}&SearchKeyword=ServiceType&IsForVendor=0&VendorLeadId=0`;
    return this.http.get<DistrictModel>(url)
      .pipe(catchError(this.handleError)
      );
  }
  saveBasicDetails(params: FormData) {
    const url = `${this.baseUrl}/api/v1/profiles`;
    return this.http.post<ApiResponseModel>(url, params)
      .pipe(catchError(this.handleError)
      );
  }
  saveBranchDetails(params) {

    const url = `${this.baseUrl}/api/v1/vendor/branches`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }

  saveQuestion(params) {
    const url = `${this.baseUrl}/servicequestion/createvendorquestioanswers`;
    return this.http.post<ApiResponseModel>(url, params)
      .pipe(catchError(this.handleError)
      );
  }
  saveCategoryDetails(params: FormData) {
    const url = `${this.baseUrl}/api/v1/vendor/vendorprofile/categoryDetails`;
    return this.http.post<ApiResponseModel>(url, params)
      .pipe(catchError(this.handleError)
      );
  }
  createKyc(KYCData: FormData) {
    const url = `${this.baseUrl}/profiles/21/kyc`;
    return this.http.post<ApiResponseModel>(url, KYCData)
      .pipe(catchError(this.handleError)
      );
  }

  sendOtpRequest(params,vendorID) {

    const url = `${this.baseUrl}/api/v1/profiles/${vendorID}/otpSend`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }
  verifyOtp(params,vendorID) {

    const url = `${this.baseUrl}/api/v1/profiles/${vendorID}/otpVerify`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }
  saveTopUp(params) {

    const url = `${this.baseUrl}/api/v1/vendor/servicetopup`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }
  savePackage(params) {

    const url = `${this.baseUrl}/api/v1/vendor/servicesubscriptions`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }

  savePackagePayment(params) {
    const url = `${this.baseUrl}/paymentBook`;
    return this.http.post<ApiResponseModel>(url, params, this.httpOptions)
      .pipe(catchError(this.handleError)
      );
  }
}
