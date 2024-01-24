import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class ProizvodjacGetallEndpoint implements MyBaseEndpoint<void, ProizvodjacGetAllResponse>
{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: void ): Observable<ProizvodjacGetAllResponse>
  {let url = MojConfig.adresa_servera+'/proizvodjac/get-all';
    return this.httpClient.get<ProizvodjacGetAllResponse>(url);
  }

}
export interface ProizvodjacGetAllResponse {
  proizvodjaci: ProizvodjacGetAllResponseProizvodjaci[]
}

export interface ProizvodjacGetAllResponseProizvodjaci {
  id: number
  naziv: string
}
