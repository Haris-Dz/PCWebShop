import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";
import {Injectable} from "@angular/core";
@Injectable({providedIn: 'root'})
export class ZaposlenikGetallEndpoint implements MyBaseEndpoint<void, GetAllZaposleniciResponse>{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: void): Observable<GetAllZaposleniciResponse> {
    let url = MojConfig.adresa_servera+'/Zaposlenici/get-all';

    return this.httpClient.get<GetAllZaposleniciResponse>(url);
  }

}
export interface GetAllZaposleniciResponse{
  zaposlenik:ZaposlenikGetAllResponseZaposlenici[];
}
export interface ZaposlenikGetAllResponseZaposlenici {
  id: number,
  korisnickoIme: string,
  slikaKorisnika:string,
  ime: string,
  prezime: string,
  brojMobitela: string,
  ulica: string,
  email: string,
  grad:grad
}
export interface grad {
    id: number,
    naziv: string,
    isDeleted: boolean
}
