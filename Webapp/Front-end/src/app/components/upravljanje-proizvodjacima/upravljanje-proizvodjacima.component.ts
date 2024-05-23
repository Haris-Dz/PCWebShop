import { Component, OnInit } from '@angular/core';
import {
  ProizvodjacGetallEndpoint, ProizvodjacGetAllResponse,
  ProizvodjacGetAllResponseProizvodjaci
} from "../../endpoints/proizvodjac-endpoints/proizvodjac-getall.endpoint";
import {ProizvodjacDeleteEndpoint} from "../../endpoints/proizvodjac-endpoints/proizvodjac-delete.endpoint";
import {ProizvodjacDodajEndpoint} from "../../endpoints/proizvodjac-endpoints/proizvodjac-dodaj.endpoint";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-upravljanje-proizvodjacima',
  templateUrl: './upravljanje-proizvodjacima.component.html',
  styleUrls: ['./upravljanje-proizvodjacima.component.css']
})
export class UpravljanjeProizvodjacimaComponent implements OnInit {
  isVidljivoForm: boolean = false;
  proizvodjaci: ProizvodjacGetAllResponseProizvodjaci[]=[];
  proizvodjaczadodavanje: any;
   proizvodjaczabrisanje: any;

  constructor(private proizvodjacGetallEndpoint:ProizvodjacGetallEndpoint,
              private proizvodjacDeleteEndpoint:ProizvodjacDeleteEndpoint,
              private proizvodjacDodajEndpoint:ProizvodjacDodajEndpoint) { }

  fetchProizvodjaci()
  {
    this.proizvodjacGetallEndpoint.obradi().subscribe((x:ProizvodjacGetAllResponse)=>{
      this.proizvodjaci=x.proizvodjaci
    })
  }

  ngOnInit(): void {
    this.fetchProizvodjaci();
    this.proizvodjaczadodavanje={
      naziv:""
    }
  }

  callbrisanje(primljeniproizvodjac: any) {
    this.proizvodjaczabrisanje =primljeniproizvodjac
    this.proizvodjacDeleteEndpoint.obradi(this.proizvodjaczabrisanje!).subscribe((x)=>{
      porukaSuccess("Proizvodjac Obrisan")
      this.ngOnInit();
      this.proizvodjaczabrisanje = null
    })
  }

  dodaj() {
    this.proizvodjacDodajEndpoint.obradi(this.proizvodjaczadodavanje!).subscribe((x)=>{
      porukaSuccess("Proizvodjac Dodan")
      this.ngOnInit();
    })
  }
}
