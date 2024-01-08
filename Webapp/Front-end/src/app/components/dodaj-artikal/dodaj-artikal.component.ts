import { Component, OnInit } from '@angular/core';
import {ArtikalDodajEndpoint, ArtikaldodajRequest} from "../../endpoints/artikal-endpoints/artikal-dodaj.endpoint";
import {
  KategorijeGetAllEndpoint, KategorijeGetAllResponse,
  KategorijeGetAllResponseKategorije
} from "../../endpoints/kategorija-endpoints/kategorija-getall.endpoint";


@Component({
  selector: 'app-dodaj-artikal',
  templateUrl: './dodaj-artikal.component.html',
  styleUrls: ['./dodaj-artikal.component.css']
})
export class DodajArtikalComponent implements OnInit {
  public artikal: any;
  constructor(private dodajEndpoint:ArtikalDodajEndpoint,private kategorijagetallendpoint:KategorijeGetAllEndpoint) { }
  kategorije:KategorijeGetAllResponseKategorije[]=[];
  ngOnInit(): void {
    this.kategorijagetallendpoint.obradi().subscribe((x:KategorijeGetAllResponse)=>{
      this.kategorije = x.kategorije;
    })
    this.artikal = {
      naziv: "",
      cijena: "",
      opis: "",
      kratkiOpis: "",
      stanjeNaSkladistu: "",
      sifra: "",
      model: "",
      artikalKategorijaId: null,
    } ;

  }
  getid($event:Event){
    // @ts-ignore
    this.artikal.artikalKategorijaId = $event.target.value;
  }

  dodaj(): void {

    this.dodajEndpoint.obradi(this.artikal!).subscribe((x)=>{
      alert("Artikal Dodan")
      this.ngOnInit();
    })
  }
}
