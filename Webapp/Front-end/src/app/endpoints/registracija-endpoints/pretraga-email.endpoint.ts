import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class PretragaEmailEndpoint implements MyBaseEndpoint<string, PretragaEmailResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: string): Observable<PretragaEmailResponse> {
    let url = MojConfig.adresa_servera+`/registracija/get-by-email?Email=${request}`;

    return this.httpClient.get<PretragaEmailResponse>(url);
  }

}
export interface PretragaEmailResponse {
  email: string;
}

