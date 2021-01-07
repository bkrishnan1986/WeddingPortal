import { Injectable } from '@angular/core';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from '../models/login.model';
import { catchError } from 'rxjs/operators';
import { OtpDetails } from '../models/otp-details.model';
import { ChangePasswordModel } from '../models/change-password.model';
import { ApiResponseModel } from 'src/app/shared/models/api-response.model';
import { UserStorageDetailsModel } from 'src/app/core/models/user-storage-details.model';

@Injectable()
export class LoginService extends HttpBaseService {

  baseUrl = environment.api.baseUrl;

  constructor(private http: HttpClient) {

    super();
  }

  login(model: LoginModel) {

    const url = `${this.baseUrl}/login`;
    return this.http.post<UserStorageDetailsModel>(url, model)
      .pipe(catchError(this.handleError)
      );
  }

  sendSecurityCode(email: string) {

    const url = `${this.baseUrl}/login/SendOTP/${email}`;
    return this.http.get<OtpDetails>(url)
      .pipe(catchError(this.handleError)
      );
  }

  changePassword(model: ChangePasswordModel){
    const url = `${this.baseUrl}/login/UpdatePassword`;
    return this.http.post<ApiResponseModel>(url, model)
      .pipe(catchError(this.handleError)
      );
  }
}
