import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class KupacGetbyIdEndpoint implements MyBaseEndpoint<number, KupacGetbyIdResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<KupacGetbyIdResponse> {
    let url = MojConfig.adresa_servera+`/kupac/get-by-id?id=${request}`;

    return this.httpClient.get<KupacGetbyIdResponse>(url);
  }

}
export interface KupacGetbyIdResponse {
  id: number,
  korisnickoIme: string,
  slikaKorisnika: string,
  ime: string,
  prezime: string,
  email: string,
  brojMobitela: string,
  gradId: number
}

