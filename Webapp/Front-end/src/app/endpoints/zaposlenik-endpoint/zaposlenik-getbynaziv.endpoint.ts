import {Injectable} from "@angular/core";
import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";

@Injectable({providedIn: 'root'})
export class ZaposlenikGetByNazivEndpoint implements MyBaseEndpoint<string, ZaposlenikGetByNazivResponse> {
  constructor(public httpClient: HttpClient) {
  }

  obradi(request: string): Observable<ZaposlenikGetByNazivResponse> {
    let url = MojConfig.adresa_servera + `/Zaposlenici/get-by-naziv?Naziv=${request}`;

    return this.httpClient.get<ZaposlenikGetByNazivResponse>(url);
  }
}
export interface ZaposlenikGetByNazivResponse{
  zaposlenik:ZaposlenikGetByNazivResponseZaposlenici[]
}

export interface ZaposlenikGetByNazivResponseZaposlenici {
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
