import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';


@Injectable({
  providedIn: 'root'
})
export class  NotificationService {

  constructor(private toastr: ToastrService, private spinner: NgxSpinnerService) { }

  showSuccess(message, title) {
    this.toastr.success(message, title);
  }

  showError(message, title) {
    this.toastr.error(message, title);
  }

  showWarning(message, title) {
    this.toastr.warning(message, title);
  }

  showInfo(message, title) {
    this.toastr.info(message, title, {
      timeOut:40000
    });
  }

  showNotification(res: any) {
    try {
      if (res['responseType'] === 'error') {
        this.showError(res['responseCode'] + ' - ' + res['responseMessage'], 'Error');
      }

      if (res['responseType'] === 'warning') {
        this.showWarning(res['responseCode'] + ' - ' + res['responseMessage'], 'Warning');
      }

      if (res['responseType'] === 'success') {
        this.showSuccess(res['responseCode'] + ' - ' + res['responseMessage'], 'Success');
      }
    } catch (error) {
        this.showWarning('Un-identify error, please kindly verify the operation  performed because this can be cause by network or server error', 'Warning')
    }

  }

  LoaderShow() {
    this.spinner.show();

  }



 async LoaderHide() {
    this.spinner.hide();


  }

  loadSpinner(){

  }

  IsSpinner(): boolean {
    let value = false;
    this.spinner.getSpinner(this.spinner.getSpinner.name).subscribe(res => value = res.show);
    return value;
  }
}
