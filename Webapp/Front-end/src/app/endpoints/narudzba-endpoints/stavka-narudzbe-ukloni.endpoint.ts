import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class StavkaNarudzbeUkloniEndpoint implements MyBaseEndpoint<number, void>
{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number ): Observable<void>
  {let url = MojConfig.adresa_servera+`/stavka-narudzbe/ukloni-stavku?request=${request}`;
    return this.httpClient.delete<void>(url);
  }
}



