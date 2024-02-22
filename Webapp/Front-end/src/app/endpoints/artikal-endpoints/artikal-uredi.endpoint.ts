import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class ArtikalUrediEndpoint implements MyBaseEndpoint<ArtikalUrediRequest, number> {
  constructor(public httpClient: HttpClient) {
  }
  obradi(request: ArtikalUrediRequest): Observable<number> {
    let url = MojConfig.adresa_servera+'/artikal/update/'+request.id;
    return this.httpClient.put<number>(url,request);
  }
}
export interface ArtikalUrediRequest{
  id: number
  naziv: string
  cijena: number
  opis: string
  kratkiOpis: string
  stanjeNaSkladistu: number
  sifra: number
  model: string
  artikalKategorijaId: number
  popustId:number
  proizvodjacId:number
}
