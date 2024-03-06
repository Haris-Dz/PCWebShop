import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {AutentifikacijaToken} from "../endpoints/registracija-endpoints/login.endpoint";

@Injectable({providedIn:"root"})
export class MyAuthService{
  constructor(private httpClient: HttpClient) {
  }
  isLoggedIn():boolean{
    return this.getAuthorizationToken() != null;
  }
  getAuthorizationToken():AutentifikacijaToken | null {
    let tokenString = window.localStorage.getItem("my-auth-token")??"";
    try {
      return JSON.parse(tokenString).autentifikacijaToken;
    }
    catch (e){
      return null;
    }
  }
  isAdmin():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isAdmin??false;
  }
  isKupac():boolean {
    return this.getAuthorizationToken()?.korisnickiNalog.isKupac??false;
  }
  isZaposlenik():boolean{
    return this.getAuthorizationToken()?.korisnickiNalog.isZaposlenik??false
  }
  setUser(x: AutentifikacijaToken | null) {

    if (x == null){
      window.localStorage.setItem("my-auth-token", '');
    }
    else {
      window.localStorage.setItem("my-auth-token", JSON.stringify(x));
    }
  }
}


