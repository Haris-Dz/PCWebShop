import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class StavkaNarudzbeDodajEndpoint implements MyBaseEndpoint<StavkanarudzbeRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: StavkanarudzbeRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/stavka-narudzbe/dodaj-stavku`;

    return this.httpClient.post<number>(url, request);
  }
}
export interface StavkanarudzbeRequest {

  cijena: number,
  kolicina: number,
  artikalId: number,
  narudzbaId: number

}
