import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class ArtikalGetbyPopustEndpoint implements MyBaseEndpoint<number, ArtikalGetbyPopustResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<ArtikalGetbyPopustResponse> {
    let url = MojConfig.adresa_servera+`/artikal/get-by-popust?id=${request}`;

    return this.httpClient.get<ArtikalGetbyPopustResponse>(url);
  }
}
export interface ArtikalGetbyPopustResponse {
  artikal: ArtikalGetbyPopustArtikli[]
}
export interface ArtikalGetbyPopustArtikli {
  id: number
  naziv: string
  cijena: number
  opis: string
  kratkiOpis: string
  stanjeNaSkladistu: number
  slikaArtikla: string
  sifra: number
  model: string
  popust: ArtikalPopust
  proizvodjac: any
  artikalKategorija: any
  skladiste: any
}

export interface ArtikalPopust {
  id: number
  naziv: string
  procenat: number
}
