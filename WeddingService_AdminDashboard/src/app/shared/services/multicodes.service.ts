import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class MulticodesService extends HttpBaseService {

  baseUrl = environment.api.identityUrl;

  constructor(private http: HttpClient) { super(); }

  getMulticodes() {
    const url = `${this.baseUrl}/multicodes`;
    return this.http.get<any>(url)
    .pipe(catchError(this.handleError));
  }
}
