import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";



@Injectable({providedIn: 'root'})
export class PopustUrediEndpoint implements MyBaseEndpoint<PopustUrediRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: PopustUrediRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/popust/izmijeni`;

    return this.httpClient.put<number>(url, request);
  }
}

export interface PopustUrediRequest {
  id: number
  naziv: string
  datumDo: string
  datumOd: string
  procenat: number

}
