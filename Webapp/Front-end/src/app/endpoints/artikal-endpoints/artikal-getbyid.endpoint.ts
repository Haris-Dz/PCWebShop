import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ArtikalGetbyIdEndpoint implements MyBaseEndpoint<number, ArtikalGetbyIdResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<ArtikalGetbyIdResponse> {
    let url = MojConfig.adresa_servera+`/artikal/get-by-id?id=${request}`;

    return this.httpClient.get<ArtikalGetbyIdResponse>(url);
  }

}
export interface ArtikalGetbyIdResponse {
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
  artikalKategorija: any
  skladiste: any
}

