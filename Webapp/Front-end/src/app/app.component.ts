import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {
  KategorijeGetAllEndpoint, KategorijeGetAllResponse,
  KategorijeGetAllResponseKategorije
} from "./endpoints/kategorija-endpoints/kategorija-getall.endpoint";
import {LoginEndpoint} from "./endpoints/registracija-endpoints/login.endpoint";
import {LogoutEndpoint} from "./endpoints/registracija-endpoints/logout.endpoint";
import {MyAuthService} from "./services/myAuthService";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
   error: any;

  constructor(public router: Router,private kategorijagetallendpoint:KategorijeGetAllEndpoint,
              private loginEndpoint:LoginEndpoint,
              private logoutEndpoint:LogoutEndpoint,
              public myAuthService:MyAuthService) {}
    naziv=" ";
    kategorije:KategorijeGetAllResponseKategorije[]=[];
    isVidljivoRegister:boolean=false;
    logiranikorisnik:any;
    korisnickipodaci:any;


fetchKategorije(){
  this.kategorijagetallendpoint.obradi().subscribe((x:KategorijeGetAllResponse)=>{
    this.kategorije = x.kategorije;
  })
}


  ngOnInit(): void {
  this.fetchKategorije();
    this.korisnickipodaci={
      korisnickoIme:"",
      lozinka:""
    }
  }

  preuzmiPodatke($event:Event){
    // @ts-ignore
    this.naziv = $event.target.value;

  }

  reloadnaziv() {
    this.router.navigate(["/pretraganaziv/"+this.naziv]);
  }
  reloadkategorija(id:number) {
    this.router.navigate(["artikalGetByKategorija/"+id]);
  }

  logirajse() {
    this.loginEndpoint.obradi(this.korisnickipodaci).subscribe((x)=>{
      this.logiranikorisnik = x;
      if (!this.logiranikorisnik.isLogiran)
      {
        return;
      }
      this.myAuthService.setUser(this.logiranikorisnik);
      this.isVidljivoRegister=false;
      this.ngOnInit();
    })
  }

  logout() {
    this.logoutEndpoint.obradi().subscribe((x)=>{

    })
    window.localStorage.setItem("my-auth-token","");
    this.logiranikorisnik=null;
    this.router.navigate(["/home"]);
  }
}
