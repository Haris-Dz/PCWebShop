import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class PopustGetAllEndpoint implements MyBaseEndpoint<void, PopustGetAllResponse>
{
  constructor(public httpClient: HttpClient) {
  }
  obradi(request:void) :Observable<PopustGetAllResponse>
  {
    let url=MojConfig.adresa_servera+'/popust/get-all';
    return this.httpClient.get<PopustGetAllResponse>(url);
  }
}
export interface PopustGetAllResponse {
  popusti: PopustGetAllResponsePopusti[]
}

export interface PopustGetAllResponsePopusti {
  id: number
  naziv: string
  datumDo: string
  datumOd: string
  procenat: number
  isDeleted: boolean
}
