import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class  PopustDeleteEndpoint implements MyBaseEndpoint<PopustDeleteRequest, number>
{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request:PopustDeleteRequest):Observable<number>
  {
    let url =MojConfig.adresa_servera+'/popust/obrisi';
    return this.httpClient.put<number>(url,request);
  }

}


export interface PopustDeleteRequest
{
  id:number;
}
