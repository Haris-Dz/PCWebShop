import { Component, OnInit } from '@angular/core';
import {ArtikalDodajEndpoint, ArtikaldodajRequest} from "../../endpoints/artikal-endpoints/artikal-dodaj.endpoint";


@Component({
  selector: 'app-dodaj-artikal',
  templateUrl: './dodaj-artikal.component.html',
  styleUrls: ['./dodaj-artikal.component.css']
})
export class DodajArtikalComponent implements OnInit {
  public artikal: any;
  constructor(private dodajEndpoint:ArtikalDodajEndpoint) { }

  ngOnInit(): void {
    this.artikal = {
      naziv: "",
      cijena: "",
      opis: "",
      kratkiOpis: "",
      stanjeNaSkladistu: "",
      sifra: "",
      model: "",
    } ;
  }

  dodaj(): void {

    this.dodajEndpoint.obradi(this.artikal!).subscribe((x)=>{
      alert("Artikal Dodan")
      this.ngOnInit();
      this.artikal = null
    })
  }
}
