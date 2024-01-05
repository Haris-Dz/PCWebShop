import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ArtikalObrisiEndpoint implements MyBaseEndpoint<ArtikalObrisiRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: ArtikalObrisiRequest): Observable<number> {
    let url = MojConfig.adresa_servera+'/artikal/obrisi';
    return this.httpClient.put<number>(url,request);
  }
}
export interface ArtikalObrisiRequest{
  id:number;
}
