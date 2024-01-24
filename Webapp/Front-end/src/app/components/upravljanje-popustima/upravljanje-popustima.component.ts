import { Component, OnInit } from '@angular/core';
import {
  PopustGetAllEndpoint, PopustGetAllResponse,
  PopustGetAllResponsePopusti
} from "../../endpoints/popust-endpoints/popust-getall.endpoint";
import {PopustDeleteEndpoint} from "../../endpoints/popust-endpoints/popust-delete.endpoint";
import {PopustDodajEndpoint} from "../../endpoints/popust-endpoints/popust-dodaj.endpoint";
import {PopustUrediEndpoint} from "../../endpoints/popust-endpoints/popust-uredi.endpoint";

@Component({
  selector: 'app-upravljanje-popustima',
  templateUrl: './upravljanje-popustima.component.html',
  styleUrls: ['./upravljanje-popustima.component.css']
})
export class UpravljanjePopustimaComponent implements OnInit {

  constructor(private popustGetAllEndpoint:PopustGetAllEndpoint,
              private popustDeleteendpoint:PopustDeleteEndpoint,
              private popustDodajEndpoint:PopustDodajEndpoint,
              private popustUrediEndpoint:PopustUrediEndpoint) { }
 popusti:PopustGetAllResponsePopusti[]=[];
  isVidljivoForm: boolean = false;
  popustZabrisanje:any
  popustZadodavanje: any;
  isVidljivoFormuredi: boolean=false;

    ngOnInit(): void {
    this.popustiGetALL();
    this.popustZadodavanje=null;

  }
popustiGetALL()
{
  this.popustGetAllEndpoint.obradi().subscribe((p:PopustGetAllResponse)=>{
    this.popusti=p.popusti;
  })

}

  callbrisanje(primljenipopust:any) {
    this.popustZabrisanje=primljenipopust
    this.popustDeleteendpoint.obradi(this.popustZabrisanje!).subscribe((x)=>{
      alert("Popust obrisan");
      this.ngOnInit();
      this.popustZabrisanje=null;
      })

  }

  dodaj() {
    this.popustZadodavanje={
      id: 0,
      naziv: "",
      datumDo: new Date(),
      datumOd: new Date(),
      procenat: 0,
    }
  }

  spasipromjene() {
    this.popustDodajEndpoint.obradi(this.popustZadodavanje).subscribe(x=>{
      alert("Popust dodan")
      this.ngOnInit();
    })
  }

  spasipromjeneuredi() {
    this.popustUrediEndpoint.obradi(this.popustZadodavanje).subscribe(x=>{
      alert("Popust uredjen");
      this.ngOnInit();
    })


  }

  proslijedi(zauredi:any) {
    this.popustZadodavanje=zauredi
  }
}
