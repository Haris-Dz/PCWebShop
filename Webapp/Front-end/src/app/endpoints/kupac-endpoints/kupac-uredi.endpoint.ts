import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";



@Injectable({providedIn: 'root'})
export class KupacUrediEndpoint implements MyBaseEndpoint<KupacUrediRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: KupacUrediRequest): Observable<number> {
    let url = MojConfig.adresa_servera+'/kupac/update/'+request.id;
    return this.httpClient.put<number>(url,request);
  }
}

export interface KupacUrediRequest {
  id: number,
  ime: string,
  prezime: string,
  brojMobitela: string,
  gradId: number
}
