import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class GradDodajEndpoint implements MyBaseEndpoint<GradDodajRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: GradDodajRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/grad/dodaj`;

    return this.httpClient.post<number>(url, request);
  }
}
export interface GradDodajRequest {

  naziv: string;


}
