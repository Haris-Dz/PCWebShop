import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class KupacGetallEndpoint implements MyBaseEndpoint<void, KupacGetAllResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: void): Observable<KupacGetAllResponse> {
    let url = MojConfig.adresa_servera+'/kupac/kupac-get-all';

    return this.httpClient.get<KupacGetAllResponse>(url);
  }

}
export interface KupacGetAllResponse{
  kupci:KupacGetAllResponseKupci[];
}
export interface KupacGetAllResponseKupci {
  id: number,
  korisnickoIme: string,
  slikaKorisnika: string,
  ime: string,
  prezime: string,
  email: string,
  brojMobitela: string,
  gradId: number
}
