import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class PosaljiSmsEndpoint implements MyBaseEndpoint<PosaljiSmsRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: PosaljiSmsRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/api/Vonage/send-sms`;
    return this.httpClient.post<number>(url, request);
  }
}
export interface PosaljiSmsRequest {

  to: string,
  text: string
}
