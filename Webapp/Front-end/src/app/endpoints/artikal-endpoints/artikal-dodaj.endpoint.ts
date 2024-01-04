import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ArtikalDodajEndpoint implements MyBaseEndpoint<ArtikaldodajRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: ArtikaldodajRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/artikal/dodaj`;

    return this.httpClient.post<number>(url, request);
  }
}
export interface ArtikaldodajRequest {

  naziv: string;
  cijena: number;
  opis: string;
  kratkiOpis: string;
  stanjeNaSkladistu: number;
  sifra: number;
  model: string;
  popustId?:number;
  proizvodjacId?:number;
  artikalKategorijaId?:number;
  skladisteId?:number;

}
