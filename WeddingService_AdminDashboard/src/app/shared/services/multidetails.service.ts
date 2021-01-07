import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { HttpBaseService } from 'src/app/core/services/http-base.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class MultidetailsService extends HttpBaseService {

  baseUrl = environment.api.identityUrl;

  constructor(private http: HttpClient) { super(); }

  getMultiDetails() {
    const url = `${this.baseUrl}/multidetails`;
    return this.http.get<any>(url)
    .pipe(catchError(this.handleError));
  }

  getMultiDetail(mutiDetailId: number) {
    const url = `${this.baseUrl}/multidetails/${mutiDetailId}`;
    return this.http.get<any>(url)
    .pipe(catchError(this.handleError));
  }
}
