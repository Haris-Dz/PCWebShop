import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ArtikalGetallEndpoint implements MyBaseEndpoint<void, ArtikalGetAllResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: void): Observable<ArtikalGetAllResponse> {
      let url = MojConfig.adresa_servera+'/artikal/get-all';

    return this.httpClient.get<ArtikalGetAllResponse>(url);
  }

}
export interface ArtikalGetAllResponse{
  artikal:ArtikalGetAllResponseArtikli[];
}
export interface ArtikalGetAllResponseArtikli {
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
