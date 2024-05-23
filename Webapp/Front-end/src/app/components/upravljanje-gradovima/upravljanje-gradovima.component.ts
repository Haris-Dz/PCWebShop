import { Component, OnInit } from '@angular/core';
import {
  GradGetallEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGradovi
} from "../../endpoints/grad-endpoints/grad-getall.endpoint";
import {GradDeleteEndpoint} from "../../endpoints/grad-endpoints/grad-delete.endpoint";
import {GradDodajEndpoint} from "../../endpoints/grad-endpoints/grad-dodaj.endpoint";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-upravljanje-gradovima',
  templateUrl: './upravljanje-gradovima.component.html',
  styleUrls: ['./upravljanje-gradovima.component.css']
})
export class UpravljanjeGradovimaComponent implements OnInit {
  gradovi:GradGetAllResponseGradovi[] = [];
  gradZaDodavanje: any;
  gradzabrisanje: any;
  isVidljivoForm: boolean =false;

  constructor(
    private gradGetAllEndpoint:GradGetallEndpoint,
    private gradDeleteEndpoint:GradDeleteEndpoint,
    private gradDodajEndpoint:GradDodajEndpoint) { }

  fetchGradovi()
  {
    this.gradGetAllEndpoint.obradi().subscribe((x:GradGetAllResponse)=>{
      this.gradovi=x.gradovi
    })
  }
  ngOnInit(): void {
    this.fetchGradovi();
    this.gradZaDodavanje={
      naziv:""
    };
  }

  callbrisanje(primljenigrad: any) {
    this.gradzabrisanje =primljenigrad
    this.gradDeleteEndpoint.obradi(this.gradzabrisanje!).subscribe((x)=>{
      porukaSuccess("Grad Obrisan")
      this.ngOnInit();
      this.gradzabrisanje = null
    })
  }

  dodaj() {
    this.gradDodajEndpoint.obradi(this.gradZaDodavanje!).subscribe((x)=>{
      porukaSuccess("Grad Dodan")
      this.ngOnInit();
    })
  }
}
