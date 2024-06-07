import {Component, OnDestroy, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {
  KategorijeGetAllEndpoint, KategorijeGetAllResponse,
  KategorijeGetAllResponseKategorije
} from "./endpoints/kategorija-endpoints/kategorija-getall.endpoint";
import {LoginEndpoint} from "./endpoints/registracija-endpoints/login.endpoint";
import {LogoutEndpoint} from "./endpoints/registracija-endpoints/logout.endpoint";
import {MyAuthService} from "./services/myAuthService";
import {NarudzbaGetEndpoint, NarudzbaGetResponse} from "./endpoints/narudzba-endpoints/narudzba-get.endpoint";
import {RefreshService} from "./services/refresh.service";
import {Subscription} from "rxjs";
import {
  PopustGetAllEndpoint,
  PopustGetAllResponse,
  PopustGetAllResponsePopusti
} from "./endpoints/popust-endpoints/popust-getall.endpoint";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit,OnDestroy{
  private refreshSubscription: Subscription | undefined;

  constructor(public router: Router,private kategorijagetallendpoint:KategorijeGetAllEndpoint,
              private loginEndpoint:LoginEndpoint,
              private logoutEndpoint:LogoutEndpoint,
              private narudzbaGetEndpoint:NarudzbaGetEndpoint,
              public myAuthService:MyAuthService,
              private refreshService: RefreshService,
              private popustGetAllEndpoint:PopustGetAllEndpoint) {}
    error: any;
    naziv=" ";
    kategorije:KategorijeGetAllResponseKategorije[]=[];
    akcije: PopustGetAllResponsePopusti[]=[];
    isVidljivoRegister:boolean=false;
    logiranikorisnik:any;
    korisnickipodaci:any;
    narudzbareq : any=null;
    narudzbaresponse:any=null;
    ukupno:number=0;



fetchKategorije(){
  this.kategorijagetallendpoint.obradi().subscribe((x:KategorijeGetAllResponse)=>{
    this.kategorije = x.kategorije;
  })
}
  fetchAkcije(){
    this.popustGetAllEndpoint.obradi().subscribe((x:PopustGetAllResponse)=>{
      this.akcije = x.popusti;
    })
  }
fetchNarudzbe(){
  this.narudzbareq.kupacId=this.myAuthService.getId();
  this.narudzbaGetEndpoint.obradi(this.narudzbareq).subscribe((x)=>{
    this.narudzbaresponse = x;
    this.ukupno=x.ukupnoStavki;
  })
}

  ngOnInit(): void {
// Subscribe to the refresh observable
    this.refreshSubscription = this.refreshService.refresh$.subscribe(() => {
      this.refreshData();
    });
  this.narudzbareq={
    kupacId:1
  }
  if (this.myAuthService.isKupac()) {
    this.fetchNarudzbe();
  }
  this.fetchKategorije();
  this.fetchAkcije();
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
  reloadakcije(id:number) {
    this.router.navigate(["artikalGetByPopust/"+id]);
  }
  logirajse() {
    this.loginEndpoint.obradi(this.korisnickipodaci).subscribe((x)=>{
      this.logiranikorisnik = x;
      if (!this.logiranikorisnik.isLogiran )
      {
        if (this.myAuthService.isKupac()) {
          this.fetchNarudzbe();
        }
        return;
      }


      this.myAuthService.setUser(this.logiranikorisnik);
      this.isVidljivoRegister=false;
      porukaSuccess("Logiran korisnik:"+this.korisnickipodaci.korisnickoIme)
      this.ngOnInit();

    })
    if (this.myAuthService.isKupac()) {
      this.fetchNarudzbe();
    }
  }

  logout() {
    this.logoutEndpoint.obradi().subscribe((x)=>{
     porukaSuccess("Korisnik odjavljen")
    })
    window.localStorage.setItem("my-auth-token","");
    this.logiranikorisnik=null;
    this.router.navigate(["/home"]);
  }

  handleError($event: ErrorEvent) {
    // @ts-ignore
    event.target.src = "assets/blankprofimg.png"
  }
  ngOnDestroy() {
    // Unsubscribe to prevent memory leaks
    if (this.refreshSubscription) {
      this.refreshSubscription.unsubscribe();
    }
  }

  // Method to refresh data

  refreshData() {
    // Your refresh logic here, e.g., re-fetch data from an API
    this.fetchNarudzbe()
  }
}
