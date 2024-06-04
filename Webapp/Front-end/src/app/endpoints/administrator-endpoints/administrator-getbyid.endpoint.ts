import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class AdministratorGetbyIdEndpoint implements MyBaseEndpoint<number, AdministratorGetbyIdResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<AdministratorGetbyIdResponse> {
    let url = MojConfig.adresa_servera+`/Administrator/get-by-id/`+request;

    return this.httpClient.get<AdministratorGetbyIdResponse>(url);
  }

}
export interface AdministratorGetbyIdResponse {
  id: number,
  korisnickoIme: string,
  slikaKorisnika: string,
  ime: string,
  prezime: string,
  email: string,
}

