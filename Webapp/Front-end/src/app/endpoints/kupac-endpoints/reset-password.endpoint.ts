import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";



@Injectable({providedIn: 'root'})
export class ResetPasswordEndpoint implements MyBaseEndpoint<ResetPasswordRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: ResetPasswordRequest): Observable<number> {
    let url = MojConfig.adresa_servera+'/Lozinka/reset';
    return this.httpClient.post<number>(url,request);
  }
}

export interface ResetPasswordRequest {
  email: string
}
