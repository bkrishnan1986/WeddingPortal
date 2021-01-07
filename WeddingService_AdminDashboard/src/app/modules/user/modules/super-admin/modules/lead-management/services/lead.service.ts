import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { ApiResponseModel } from 'src/app/shared/models/api-response.model';
import { environment } from 'src/environments/environment';
import { MultiDetailModel } from '../../vendor-dashboard/models/multidetails.model';
import { VendorQuestionAnswers } from '../../vendor-dashboard/models/vendor-question-answer.model';

@Injectable({
  providedIn: 'root'
})
export class LeadService extends HttpBaseService {

  baseUrl = `${environment.api.baseUrl}/api/v1/lead-management`;

  constructor(private http: HttpClient) { super(); }

  getLeadId() {
    const url = `${this.baseUrl}/leads/leadId`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllLeadTypes() {
    const url = `${this.baseUrl}/multidetails/leadtype`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllEventTypes() {
    const url = `${this.baseUrl}/multidetails/eventtype`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllCategories() {
    const url = `${this.baseUrl}/multidetails/category`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllLeadModes() {
    const url = `${this.baseUrl}/multidetails/leadmode`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllLeadStatus() {
    const url = `${this.baseUrl}/multidetails/leadstatus`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllLeadLocation() {
    const url = `${this.baseUrl}/multidetails/location`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllLeads() {
    const url = `${this.baseUrl}/leads`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getLeadDatabyId(leadId: number) {
    const url = `${this.baseUrl}/leads/${leadId}`;
    return this.http.get<ApiResponseModel>(url)
      .pipe(catchError(this.handleError)
      );
  }

  saveLead(params) {
    const url = `${this.baseUrl}/leads`;
    return this.http.post<ApiResponseModel>(url, params, { observe: 'response' })
      .pipe(catchError(this.handleError)
      );
  }

  updateLead(params, leadId) {
    const url = `${this.baseUrl}/leads/${leadId}`;
    return this.http.put<ApiResponseModel>(url, params, { observe: 'response' })
      .pipe(catchError(this.handleError)
      );
  }

  getQuestionaireByCategory(categoryId: number) {
    const url = `${this.baseUrl}/servicequestion/${categoryId}/vendorquestionanswers?IsForVendor=false`;
    return this.http.get<VendorQuestionAnswers>(url)
      .pipe(catchError(this.handleError)
      );
  }

  changeLeadStatus(id, params) {
    const url = `${this.baseUrl}/leads/${id}`;
    return this.http.patch<ApiResponseModel>(url, params)
      .pipe(catchError(this.handleError)
      );
  }

  deleteLead(id) {
    const url = `${this.baseUrl}/leads/${id}`;
    return this.http.delete<ApiResponseModel>(url)
      .pipe(catchError(this.handleError)
      );
  }

  saveNewFollowUp(leadId, params){
    const url = `${this.baseUrl}/leads/${leadId}/followlead`;
    return this.http.post<ApiResponseModel>(url, params, { observe: 'response' })
      .pipe(catchError(this.handleError)
      );
  }

}
