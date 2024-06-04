import { Component, OnInit } from '@angular/core';
import {GradGetallEndpoint} from "../../endpoints/grad-endpoints/grad-getall.endpoint";
import {LozinkaPromjeniEndpoint} from "../../endpoints/lozinka-endpoints/lozinka-promjeni.endpoint";
import {MyAuthService} from "../../services/myAuthService";
import {ErrorHandlerService} from "../../helper/error-handler.service";
import {
  AdministratorGetbyIdEndpoint,
  AdministratorGetbyIdResponse
} from "../../endpoints/administrator-endpoints/administrator-getbyid.endpoint";
import {AdministratorUrediEndpoint} from "../../endpoints/administrator-endpoints/administrator-uredi.endpoint";
import {ZaposlenikGetbyIdResponse} from "../../endpoints/zaposlenik-endpoint/zaposlenik-getbyid.endpoint";

@Component({
  selector: 'app-administrator-profil',
  templateUrl: './administrator-profil.component.html',
  styleUrls: ['./administrator-profil.component.css']
})
export class AdministratorProfilComponent implements OnInit {

  constructor(private administratorUrediEndpoint:AdministratorUrediEndpoint,
    private administratorGetbyIdEndpoint:AdministratorGetbyIdEndpoint,
    private lozinkaPromjeniEndpoint:LozinkaPromjeniEndpoint,
    public myAuthService:MyAuthService,
    private errorHandlerService:ErrorHandlerService) { }

  administrator: any;
  lozinkaPriprema:any = null;
  ponovljenaLozinka: string = "";
  ngOnInit(): void {
    this.fetchAdmin();
  }
  fetchAdmin(){
    this.administratorGetbyIdEndpoint.obradi(this.myAuthService.getId()).subscribe((x:AdministratorGetbyIdResponse)=>{
      this.administrator=x;
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
    this.administratorUrediEndpoint.obradi(this.administrator!).subscribe((x)=>{
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
