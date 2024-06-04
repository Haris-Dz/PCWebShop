import { Component, OnInit } from '@angular/core';
import {
  ZaposlenikGetbyIdEndpoint,
  ZaposlenikGetbyIdResponse
} from "../../endpoints/zaposlenik-endpoint/zaposlenik-getbyid.endpoint";
import {ZaposlenikUrediEndpoint} from "../../endpoints/zaposlenik-endpoint/zaposlenik-uredi.endpoint";
import {
  GradGetallEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGradovi
} from "../../endpoints/grad-endpoints/grad-getall.endpoint";
import {LozinkaPromjeniEndpoint} from "../../endpoints/lozinka-endpoints/lozinka-promjeni.endpoint";
import {MyAuthService} from "../../services/myAuthService";
import {ErrorHandlerService} from "../../helper/error-handler.service";
import {KupacGetbyIdResponse} from "../../endpoints/kupac-endpoints/kupac-getbyid.endpoint";

@Component({
  selector: 'app-zaposlenik-profil',
  templateUrl: './zaposlenik-profil.component.html',
  styleUrls: ['./zaposlenik-profil.component.css']
})
export class ZaposlenikProfilComponent implements OnInit {

  constructor(private zaposlenikGetbyIdEndpoint:ZaposlenikGetbyIdEndpoint,
              private zaposlenikUrediEndpoint:ZaposlenikUrediEndpoint,
              private gradGetAllEndpoint:GradGetallEndpoint,
              private lozinkaPromjeniEndpoint:LozinkaPromjeniEndpoint,
              public myAuthService:MyAuthService,
              private errorHandlerService:ErrorHandlerService) { }
  gradovi: GradGetAllResponseGradovi[]=[];
  zaposlenik: any;
  lozinkaPriprema:any = null;
  ponovljenaLozinka: string = "";
  ngOnInit(): void {
    this.fetchGradovi();
    this.fetchZaposlenik()
  }
  fetchGradovi()
  {
    this.gradGetAllEndpoint.obradi().subscribe((x:GradGetAllResponse)=>{
      this.gradovi=x.gradovi
    })
  }
  fetchZaposlenik(){
    this.zaposlenikGetbyIdEndpoint.obradi(this.myAuthService.getId()).subscribe((x:ZaposlenikGetbyIdResponse)=>{
      this.zaposlenik=x;
    })
  }
  pripremiLozinku(){
    this.lozinkaPriprema ={
      id: this.myAuthService.getId(),
      staralozinka: "",
      novalozinka: ""
    }

  }
  uredi():void{
    this.zaposlenikUrediEndpoint.obradi(this.zaposlenik!).subscribe((x)=>{
        alert('Profil Uredjen');
        this.ngOnInit();
      },
      (error)=>{
        alert(this.errorHandlerService.handleError(error))
      })
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
