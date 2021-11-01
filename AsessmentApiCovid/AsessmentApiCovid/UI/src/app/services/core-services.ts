import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiCallService } from './api-caller';
import { ApiManager } from './api-manager';

@Injectable({
  providedIn: 'root'
})
export class CoreService {

  constructor(private apiService: ApiCallService){}

  SummaryForFirstDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.SummaryForFirstDose, `code=${code}`);
  }

  SummaryForSecondDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.SummaryForSecondDose, `code=${code}`);
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

  SummaryDailyFirstDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.SummaryDailyFirstDose, `code=${code}&date=2021-10-08`);
  }

  SummaryDailySecondDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.SummaryDailySecondDose, `code=${code}&date=2021-10-08`);
  }



  SummarySecondDoseMonth(code: string): Observable<any>{
    return this.apiService.get(ApiManager.SummarySecondDoseMonth, `code=${code}&date=2021-10-08`);
  }

  SummaryFirstDoseMonth(code: string): Observable<any>{
    return this.apiService.get(ApiManager.SummaryFirstDoseMonth, `code=${code}&date=2021-10-08`);
  }



  SummaryMonthFirstDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryMonthFirstDose, `date=2021-10-08`);
  }

  SummaryMonthSecondDose(): Observable<any>{
    return this.apiService.get(ApiManager.SummaryMonthSecondDose, `date=2021-10-08`);
  }

  Nation(): Observable<any>{
    return this.apiService.get(ApiManager.Nation);
  }

  GetVaccinatedDataFirsDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.GetVaccinatedDataFirsDose, `code=${code}`);
  }

  GetVaccinatedDataSecondDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.GetVaccinatedDataSecondDose, `code=${code}`);
  }

  GetSummaryVaccinatedDataFirstDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.GetSummaryVaccinatedDataFirstDose, `code=${code}`);
  }

  GetSummaryVaccinatedDataSecondDose(code: string): Observable<any>{
    return this.apiService.get(ApiManager.GetSummaryVaccinatedDataSecondDose, `code=${code}`);
  }
}
