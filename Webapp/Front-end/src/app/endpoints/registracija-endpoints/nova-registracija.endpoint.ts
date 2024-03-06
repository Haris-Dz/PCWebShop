import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class NovaRegistracijaEndpoint implements MyBaseEndpoint<RegistracijaRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: RegistracijaRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/registracija/nova`;

    return this.httpClient.post<number>(url, request);
  }
}
export interface RegistracijaRequest {

  korisnickoIme:string,
  lozinka: string,
  slikaKorisnika: string,
  ime: string,
  prezime: string,
  email: string,
  brojMobitela: string,
  gradId: number
}
