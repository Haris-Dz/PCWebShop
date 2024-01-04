import { Component, OnInit } from '@angular/core';
import {ArtikalDodajEndpoint, ArtikaldodajRequest} from "../endpoints/artikal-endpoints/artikal-dodaj.endpoint";


@Component({
  selector: 'app-dodaj-artikal',
  templateUrl: './dodaj-artikal.component.html',
  styleUrls: ['./dodaj-artikal.component.css']
})
export class DodajArtikalComponent implements OnInit {
  public artikal: any;
  array = [{ "value": 1, "text": "Prva" }, { "value": 2, "text": "Druga" },{ "value": 3, "text": "Treca" }];
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
