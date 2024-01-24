import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class ProizvodjacDodajEndpoint implements MyBaseEndpoint<ProizvodjacDodajRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: ProizvodjacDodajRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/proizvodjac/dodaj`;

    return this.httpClient.post<number>(url, request);
  }
}
export interface ProizvodjacDodajRequest {

  naziv: string;


}
