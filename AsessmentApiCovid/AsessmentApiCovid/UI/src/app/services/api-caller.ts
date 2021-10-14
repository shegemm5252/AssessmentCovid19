import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationService } from './notification.service';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiCallService{

  baseUrl = `${environment.url}/api/CovidTracker/`;

  constructor(private http: HttpClient, private notifyService: NotificationService, private _router: Router) { }

  get(urlstr: string, data?: any) {
    let url: string = this.baseUrl + urlstr;
    if (data !== undefined) {
      url = `${url}?${data}`;
    }

    const headers = this.createRequestJsonHeader();

    return this.http.get(url, { headers }).pipe(catchError(err => this.handleError(err)));
  }

  post( urlstr: string, data: any) {
    const headers = this.createRequestJsonHeader();
    let url: string = this.baseUrl + urlstr;


    return this.http.post(url, data, { headers }).pipe(catchError(err => this.handleError(err)));
  }

  private createRequestJsonHeader() {

    let headers = new HttpHeaders({
      'Content-Type': 'application/json',

    });

    return headers;
  }

  handleError(error: any) {
    this.notifyService.LoaderHide();
    if (error.status === 401) {

    }
    return null;
  }
}
