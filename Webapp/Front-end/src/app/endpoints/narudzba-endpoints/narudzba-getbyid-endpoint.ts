import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class NarudzbaGetByIdEndpoint implements MyBaseEndpoint<number, NarudzbaGetByIdResponse>
{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number ): Observable<NarudzbaGetByIdResponse>
  {let url = MojConfig.adresa_servera+'/narudzba/narudzba-get-by-id/'+request;
    return this.httpClient.get<NarudzbaGetByIdResponse>(url);
  }
}


export interface NarudzbaGetByIdResponse {
  id: number,
  ukupnaCijena: number,
  ukupnoStavki: number,
  stavkaNarudzbe: GetStavke[]
}
export interface GetStavke {
  id: number,
  cijena: number,
  kolicina: number,
  artikalId: number,
}
