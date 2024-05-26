import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class NarudzbaGetEndpoint implements MyBaseEndpoint<NarudzbaGetRequest, NarudzbaGetResponse>
{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: NarudzbaGetRequest ): Observable<NarudzbaGetResponse>
  {let url = MojConfig.adresa_servera+'/narudzba/get-narudzba';
    return this.httpClient.post<NarudzbaGetResponse>(url, request);
  }
}

export interface NarudzbaGetRequest{
  kupacId:number
}
export interface NarudzbaGetResponse {
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
