import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class AdministratorUrediEndpoint implements MyBaseEndpoint<AdministratorUrediRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: AdministratorUrediRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/Administrator/uredi`;

    return this.httpClient.put<number>(url, request);
  }
}
export interface AdministratorUrediRequest {

  id: number,
  ime: string,
  prezime: string,

}
