import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { environment } from 'src/environments/environment';

@Injectable()

export class UserCreationService extends HttpBaseService {

  baseUrl = environment.api.identityUrl;

  constructor(private http: HttpClient) { super(); }

  getAllActiveUsers() {
    const url = `${this.baseUrl}/profiles`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getUserId() {
    const url = `${this.baseUrl}/profiles/userId`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllActiveRoles() {
    const url = `${this.baseUrl}/multidetails/role`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getAllUserRights() {
    const url = `${this.baseUrl}/multidetails/permission`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  getUserDetailsbyID(profileId: number) {
    const url = `${this.baseUrl}/profiles/${profileId}`;
    return this.http.get<any>(url)
      .pipe(catchError(this.handleError)
      );
  }

  deleteUserbyID(profileId: number) {
    const url = `${this.baseUrl}/profiles/${profileId}`;
    return this.http.delete<any>(url, { observe: 'response' })
      .pipe(catchError(this.handleError)
      );
  }

  saveUser(params: any) {
    const url = `${this.baseUrl}/profiles`;
    return this.http.post<any>(url, params)
      .pipe(catchError(this.handleError)
      );
  }

  updateUser(params: any, id: number) {
    const url = `${this.baseUrl}/profiles/${id}`;
    return this.http.put<any>(url, params, { observe: 'response' })
      .pipe(catchError(this.handleError)
      );
  }

}