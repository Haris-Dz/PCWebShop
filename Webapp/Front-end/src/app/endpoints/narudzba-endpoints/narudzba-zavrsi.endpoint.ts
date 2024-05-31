import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class NarudzbaZavrsiEndpoint implements MyBaseEndpoint<number, NarudzbaZavrsiResponse>
{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number ): Observable<NarudzbaZavrsiResponse>
  {let url = MojConfig.adresa_servera+'/narudzba-zavrsi/'+request;
    return this.httpClient.put<NarudzbaZavrsiResponse>(url,request);
  }
}


export interface NarudzbaZavrsiResponse {
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
