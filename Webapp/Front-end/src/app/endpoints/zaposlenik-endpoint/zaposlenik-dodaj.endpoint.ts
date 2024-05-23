import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ZaposlenikDodajEndpoint implements MyBaseEndpoint<ZaposlenikdodajRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: ZaposlenikdodajRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/Zaposlenici/dodaj`;

    return this.httpClient.post<number>(url, request);
  }
}
export interface ZaposlenikdodajRequest {

  korisnickoIme: string,
  slika_base64_format: string,
  ime: string,
  prezime: string,
  ulica: string,
  email: string,
  brojMobitela: string,
  gradId: number

}
