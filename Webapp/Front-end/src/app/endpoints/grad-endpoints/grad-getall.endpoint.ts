import {MyBaseEndpoint} from "../MyBaseEndpoint";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MojConfig} from "../../moj-config";


@Injectable({providedIn: 'root'})
export class GradGetallEndpoint implements MyBaseEndpoint<void, GradGetAllResponse>
{
  constructor(public httpClient:HttpClient) {
  }
  obradi(request: void ): Observable<GradGetAllResponse>
  {let url = MojConfig.adresa_servera+'/grad/get-all';
    return this.httpClient.get<GradGetAllResponse>(url);
}

}
export interface GradGetAllResponse {
  gradovi: GradGetAllResponseGradovi[]
}

export interface GradGetAllResponseGradovi {
  id: number
  naziv: string
}
