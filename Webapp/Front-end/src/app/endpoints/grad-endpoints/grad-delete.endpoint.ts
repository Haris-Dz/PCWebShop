import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class GradDeleteEndpoint implements MyBaseEndpoint<GradDeleteRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: GradDeleteRequest): Observable<number> {
    let url = MojConfig.adresa_servera+'/grad/obrisi';
    return this.httpClient.put<number>(url,request);
  }
}


export interface GradDeleteRequest{
  id:number;
}
