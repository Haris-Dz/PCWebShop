import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class PretragaUsernameEndpoint implements MyBaseEndpoint<string, PretragaUsernameResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: string): Observable<PretragaUsernameResponse> {
    let url = MojConfig.adresa_servera+`/registracija/get-by-username?Username=${request}`;

    return this.httpClient.get<PretragaUsernameResponse>(url);
  }

}
export interface PretragaUsernameResponse {
  kNalog: string;
}

