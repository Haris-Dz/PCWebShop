import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class KomentarDodajEndpoint implements MyBaseEndpoint<KomentarDodajRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: KomentarDodajRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/komentar/dodaj`;
    return this.httpClient.post<number>(url, request);
  }
}
export interface KomentarDodajRequest {
  komentari: string,
  kupacId: number,
  artikalId: number
}
