import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";



@Injectable({providedIn: 'root'})
export class PopustDodajEndpoint implements MyBaseEndpoint<PopustDodajRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: PopustDodajRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/popust/dodaj`;

    return this.httpClient.post<number>(url, request);
  }
}

export interface PopustDodajRequest {
  id: number
  naziv: string
  datumDo: string
  datumOd: string
  procenat: number
}
