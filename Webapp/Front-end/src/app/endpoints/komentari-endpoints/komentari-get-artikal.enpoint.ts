import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class KomentariGetArtikalEndpoint implements MyBaseEndpoint<number, KomentariGetArtikalResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<KomentariGetArtikalResponse> {
    let url = MojConfig.adresa_servera+'/get-komentari/'+request;

    return this.httpClient.get<KomentariGetArtikalResponse>(url);
  }

}
export interface KomentariGetArtikalResponse{
  komentari:KomentariGetArtikalResponseKomentari[];
}
export interface KomentariGetArtikalResponseKomentari {
  komentari:string
  korisnickoIme:string
}
