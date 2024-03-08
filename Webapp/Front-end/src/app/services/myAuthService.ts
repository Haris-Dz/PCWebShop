import {Injectable} from "@angular/core";
import {AutentifikacijaToken} from "../endpoints/registracija-endpoints/login.endpoint";
import {HttpClient} from "@angular/common/http";


@Injectable({providedIn:"root"})
export class MyAuthService{
  constructor(private httpClient:HttpClient) {
  }

  isLoggedIn()
  {
    return this.getAuthorizationToken()!=null;
  }

  getAuthorizationToken():AutentifikacijaToken | null
  {
     let tokenString = window.localStorage.getItem("my-auth-token")??"";
     try {
       return JSON.parse(tokenString).autentifikacijaToken;
     }
     catch (e)
     {
       return null;
     }
  }
  isAdmin()
  {
    return this.getAuthorizationToken()?.korisnickiNalog.isAdmin??false;
  }
  isZaposlenik()
  {
    return this.getAuthorizationToken()?.korisnickiNalog.isZaposlenik??false;
  }
  isKupac()
  {
    return this.getAuthorizationToken()?.korisnickiNalog.isKupac??false;
  }
  setUser(x:AutentifikacijaToken | null){
    if(x==null)
    {
      window.localStorage.setItem("my-auth-token",'');
    }
    else
    {
      window.localStorage.setItem("my-auth-token",JSON.stringify(x));
    }
  }


}
