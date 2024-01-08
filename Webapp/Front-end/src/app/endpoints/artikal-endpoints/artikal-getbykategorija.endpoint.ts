import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class ArtikalGetbyKategorijaEndpoint implements MyBaseEndpoint<number, ArtikalGetbyKategorijaResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<ArtikalGetbyKategorijaResponse> {
    let url = MojConfig.adresa_servera+`/artikal/get-by-kategorija?id=${request}`;

    return this.httpClient.get<ArtikalGetbyKategorijaResponse>(url);
  }
}
export interface ArtikalGetbyKategorijaResponse {
  artikal: ArtikalGetbyKategorijaArtikli[]
}
export interface ArtikalGetbyKategorijaArtikli {
  id: number
  naziv: string
  cijena: number
  opis: string
  kratkiOpis: string
  stanjeNaSkladistu: number
  slikaArtikla: string
  sifra: number
  model: string
  popust: any
  proizvodjac: any
  artikalKategorija: ArtikalKategorija
  skladiste: any
}

export interface ArtikalKategorija {
  id: number
  nazivKategorije: string
}
