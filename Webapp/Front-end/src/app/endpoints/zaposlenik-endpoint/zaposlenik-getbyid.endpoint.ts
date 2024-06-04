import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ZaposlenikGetbyIdEndpoint implements MyBaseEndpoint<number, ZaposlenikGetbyIdResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<ZaposlenikGetbyIdResponse> {
    let url = MojConfig.adresa_servera+`/Zaposlenici/get-by-id/`+request;

    return this.httpClient.get<ZaposlenikGetbyIdResponse>(url);
  }

}
export interface ZaposlenikGetbyIdResponse {
  id: number,
  korisnickoIme: string,
  slikaKorisnika: string,
  ulica:string,
  ime: string,
  prezime: string,
  email: string,
  brojMobitela: string,
  gradId: number
}

