import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";



@Injectable({providedIn: 'root'})
export class LozinkaPromjeniEndpoint implements MyBaseEndpoint<LozinkaPromjeniRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: LozinkaPromjeniRequest): Observable<number> {
    let url = MojConfig.adresa_servera+'/kupac/promijeni/'+request.id;
    return this.httpClient.put<number>(url,request);
  }
}

export interface LozinkaPromjeniRequest {
  id: number,
  staralozinka: string,
  novalozinka: string
}
