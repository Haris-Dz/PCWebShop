import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ZaposlenikObrisiEndpoint implements MyBaseEndpoint<number, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: number): Observable<number> {
    let url=MojConfig.adresa_servera+`/Zaposlenici/obrisi/`+request;

    return this.httpClient.put<number>(url, request);
  }
}

