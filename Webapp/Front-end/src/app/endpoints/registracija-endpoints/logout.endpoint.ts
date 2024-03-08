import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {catchError, Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
import {ErrorHandlerService} from "../../helper/error-handler.service";
@Injectable({providedIn: 'root'})
export class LogoutEndpoint implements MyBaseEndpoint<{}, LogoutResponse>{
  constructor(public httpClient:HttpClient,private errorHandler: ErrorHandlerService) {
  }
  obradi(): Observable<LogoutResponse> {
    let url = MojConfig.adresa_servera+`/registracija/logout`;

    return this.httpClient.post<LogoutResponse>(url, {});
  }
}

export class LogoutResponse{

}

