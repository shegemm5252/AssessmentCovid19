export class Responses<T>{
  public responseCode: string;
  public responseStatus: string;
  public responseMessage: string;
  public detail: T;

  constructor(responseCode: string, responseStatus: string, responseMessage: string, detail: T){
    this.responseCode = responseCode;
    this.responseMessage = responseMessage;
    this.responseStatus = responseStatus;
    this.detail = detail;
  }
  // tslint:disable-next-line: variable-name
  static GetResponses<T>(responseCode: string, responseStatus: string, responseMessage: string, detail: T): Responses<T>{
    return new Responses<T>(responseCode, responseStatus, responseMessage, detail);
  }

}
