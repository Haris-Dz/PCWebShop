import { Component, OnInit } from '@angular/core';
import {
  GradGetallEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGradovi
} from "../../endpoints/grad-endpoints/grad-getall.endpoint";
import {MyAuthService} from "../../services/myAuthService";
import {KupacGetbyIdEndpoint, KupacGetbyIdResponse} from "../../endpoints/kupac-endpoints/kupac-getbyid.endpoint";
import {KupacUrediEndpoint} from "../../endpoints/kupac-endpoints/kupac-uredi.endpoint";
import {ErrorHandlerService} from "../../helper/error-handler.service";
import {LozinkaPromjeniEndpoint} from "../../endpoints/lozinka-endpoints/lozinka-promjeni.endpoint";
import {
  NarudzbaGetKupacEndpoint,
  NarudzbaGetKupacResponseNarudzbe
} from "../../endpoints/narudzba-endpoints/narudzbe-get-kupac.endpoint";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
@Component({
  selector: 'app-korisnik-profil',
  templateUrl: './korisnik-profil.component.html',
  styleUrls: ['./korisnik-profil.component.css']
})
export class KorisnikProfilComponent implements OnInit {

  constructor(private gradGetAllEndpoint:GradGetallEndpoint,
              private kupacGetbyIdEndpoint:KupacGetbyIdEndpoint,
              private kupacUrediEndpoint:KupacUrediEndpoint,
              private lozinkaPromjeniEndpoint:LozinkaPromjeniEndpoint,
              public myAuthService:MyAuthService,
              private errorHandlerService:ErrorHandlerService,
              private narudzbaGetKupacEndpoint:NarudzbaGetKupacEndpoint) { }
  gradovi: GradGetAllResponseGradovi[]=[];
  kupac: any;
  lozinkaPriprema:any = null;
  ponovljenaLozinka: string = "";
  listanarudzbe:NarudzbaGetKupacResponseNarudzbe[]=[];
  ukupnoPlaceno:number=0;
  ngOnInit(): void {
    this.fetchGradovi();
    this.fetchKupac();
    this.fetchNarudzbe();
  }
  fetchGradovi()
  {
    this.gradGetAllEndpoint.obradi().subscribe((x:GradGetAllResponse)=>{
      this.gradovi=x.gradovi
    })
  }
  fetchKupac(){
    this.kupacGetbyIdEndpoint.obradi(this.myAuthService.getId()).subscribe((x:KupacGetbyIdResponse)=>{
      this.kupac=x;
    })
  }
  fetchNarudzbe()
  {
    this.narudzbaGetKupacEndpoint.obradi(this.myAuthService.getId()).subscribe(x=>{
      this.listanarudzbe=x.narudzbe
      this.ukupnoPlaceno=x.ukupnoPlaceno
    })
  }
  uredi():void{
    this.kupacUrediEndpoint.obradi(this.kupac!).subscribe((x)=>{
        porukaSuccess('Profil Uredjen');
        this.ngOnInit();
      },
      (error)=>{
        porukaError(this.errorHandlerService.handleError(error))
      })
  }
  pripremiLozinku(){
    this.lozinkaPriprema ={
      id: this.myAuthService.getId(),
      staralozinka: "",
      novalozinka: ""
    }

  }
  promijeniPassword(){
    if (this.lozinkaPriprema.novalozinka != this.ponovljenaLozinka){
      alert("lozinke nisu iste")
      return;
    }
    this.lozinkaPromjeniEndpoint.obradi(this.lozinkaPriprema).subscribe((x)=>{
        alert("lozinka uspjesno promijenjena")
        this.lozinkaPriprema = null;
        this.ponovljenaLozinka = "";
        this.ngOnInit();
      },
      (error)=>{
        alert(this.errorHandlerService.handleError(error))
      })
  }

}
