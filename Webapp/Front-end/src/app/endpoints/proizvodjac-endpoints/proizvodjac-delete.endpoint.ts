import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class ProizvodjacDeleteEndpoint implements MyBaseEndpoint<ProizvodjacDeleteRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: ProizvodjacDeleteRequest): Observable<number> {
    let url = MojConfig.adresa_servera+'/Proizvodjac/Obrisi';
    return this.httpClient.put<number>(url,request);
  }
}


export interface ProizvodjacDeleteRequest{
  id:number;
}
