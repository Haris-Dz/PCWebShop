import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class ArtikalPretragaNazivEndpoint implements MyBaseEndpoint<string, ArtikalPretragaNazivResponse> {
  constructor(public httpClient: HttpClient) {
  }

  obradi(request: string): Observable<ArtikalPretragaNazivResponse> {
    let url = MojConfig.adresa_servera + `/artikal/get-by-naziv?Naziv=${request}`;

    return this.httpClient.get<ArtikalPretragaNazivResponse>(url);
  }
}
  export interface ArtikalPretragaNazivResponse{
    artikal:ArtikalPretragaNazivArtikli[]
  }

export interface ArtikalPretragaNazivArtikli {
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
