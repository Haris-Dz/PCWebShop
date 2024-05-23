import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ZaposlenikUrediEndpoint implements MyBaseEndpoint<ZaposlenikUrediRequest, number>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: ZaposlenikUrediRequest): Observable<number> {
    let url=MojConfig.adresa_servera+`/Zaposlenici/uredi/`+request.id;

    return this.httpClient.put<number>(url, request);
  }
}
export interface ZaposlenikUrediRequest {

  id: number,
  ime: string,
  prezime: string,
  ulica: string,
  brojMobitela: string,
  gradId: number

}
