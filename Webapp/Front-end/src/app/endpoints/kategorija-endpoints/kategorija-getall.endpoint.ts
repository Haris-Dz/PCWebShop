import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class KategorijeGetAllEndpoint implements MyBaseEndpoint<void, KategorijeGetAllResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: void): Observable<KategorijeGetAllResponse> {
    let url = MojConfig.adresa_servera+'/kategorija/get-all';
    return this.httpClient.get<KategorijeGetAllResponse>(url);
  }
}
export interface KategorijeGetAllResponse {
  kategorije: KategorijeGetAllResponseKategorije[]
}

export interface KategorijeGetAllResponseKategorije {
  id: number
  naziv: string
}
