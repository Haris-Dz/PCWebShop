import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class NarudzbaGetKupacEndpoint implements MyBaseEndpoint<number, NarudzbaGetKupacResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<NarudzbaGetKupacResponse> {
    let url = MojConfig.adresa_servera+'/narudzba/get-by-idKupca/'+request;

    return this.httpClient.get<NarudzbaGetKupacResponse>(url);
  }

}
export interface NarudzbaGetKupacResponse{
  ukupnoPlaceno:number
  narudzbe:NarudzbaGetKupacResponseNarudzbe[];
}
export interface NarudzbaGetKupacResponseNarudzbe {
  id: number,
  ukupnaCijena: number,
  ukupnoStavki: number,
  datumKupovine: any,
  stavkaNarudzbe: StavkaNarudzbeResponse
}
export interface StavkaNarudzbeResponse
{
  cijena: number,
  kolicina: number,
  artikal: ArtikalResponse
}
export interface  ArtikalResponse
{
  naziv: string,
  cijena: number,
  slikaArtikla: string,

}
