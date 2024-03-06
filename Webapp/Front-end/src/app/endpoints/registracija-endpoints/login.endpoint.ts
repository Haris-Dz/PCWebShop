import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {catchError, Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
import {ErrorHandlerService} from "../../helper/error-handler.service";
@Injectable({providedIn: 'root'})
export class LoginEndpoint implements MyBaseEndpoint<LoginRequest, LoginResponse>{
  constructor(public httpClient:HttpClient,private errorHandler: ErrorHandlerService) {
  }
  obradi(request: LoginRequest): Observable<LoginResponse> {
    let url = MojConfig.adresa_servera+`/registracija/login`;

    return this.httpClient.post<LoginResponse>(url,request);
  }

}

export interface LoginRequest {
  korisnickoIme:string,
  lozinka:string
}
export interface LoginResponse {
  autentifikacijaToken: AutentifikacijaToken
  isLogiran: boolean
}

export interface AutentifikacijaToken {
  id: number
  vrijednostTokena: string
  korisnickiNalogId: number
  korisnickiNalog: KorisnickiNalog
  vrijemeEvidentiranja: string
  ipAdresa: any
}

export interface KorisnickiNalog {
  id: number
  korisnickoIme: string
  slikaKorisnika: string
  isAdmin: boolean
  isZaposlenik: boolean
  isKupac: boolean
}
