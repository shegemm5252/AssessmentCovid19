import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiCallService } from './api-caller';
import { ApiManager } from './api-manager';

@Injectable({
  providedIn: 'root'
})
export class CoreService {

  constructor(private apiService: ApiCallService){}

  SummaryForFirstDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryForFirstDose);
  }

  SummaryForSecondDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryForSecondDose);
  }

  SummaryForFirstnationDose(areaCode: string): Observable<any>{
    return this.apiService.get(ApiManager.SummaryForFirstnationDose, `AreaCode=${areaCode}`);
  }

  SummaryForSecondnationDose(areaCode: string): Observable<any>{
    return this.apiService.get(ApiManager.SummaryForSecondnationDose, `AreaCode=${areaCode}`);
  }

  SecondDose(): Observable<any>{
    return this.apiService.get(ApiManager.SecondDose);
  }

  FirstDose(): Observable<any>{
    return this.apiService.get(ApiManager.FirstDose);
  }

  GetArea(): Observable<any>{
    return this.apiService.get(ApiManager.GetArea);
  }

  SummaryDailyFirstDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryDailyFirstDose, `date=2021-10-08`);
  }

  SummaryDailySecondDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryDailySecondDose, `date=2021-10-08`);
  }

  SummaryMonthFirstDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryMonthFirstDose, `year=2021&month=10`);
  }

  SummaryMonthSecondDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryMonthSecondDose, `year=2021&month=10`);
  }
}
