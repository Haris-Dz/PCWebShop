import { Component, OnInit } from '@angular/core';
import {
  ArtikalGetallEndpoint, ArtikalGetAllResponse,
  ArtikalGetAllResponseArtikli
} from "../endpoints/artikal-endpoints/artikal-getall.endpoint";
import {ArtikalObrisiEndpoint, ArtikalObrisiRequest} from "../endpoints/artikal-endpoints/artikal-obrisi.endpoint";
import {ArtikalUrediEndpoint, ArtikalUrediRequest} from "../endpoints/artikal-endpoints/artikal-uredi.endpoint";
@Component({
  selector: 'app-upravljanje-artiklima',
  templateUrl: './upravljanje-artiklima.component.html',
  styleUrls: ['./upravljanje-artiklima.component.css']
})

export class UpravljanjeArtiklimaComponent implements OnInit {

  constructor(
    private artikalgetalldendpoint:ArtikalGetallEndpoint,
    private artikalobrisiendpoint:ArtikalObrisiEndpoint,
    private artikalurediendpoint:ArtikalUrediEndpoint) { }

  public prikaziFormu: boolean = false;
  artikli: ArtikalGetAllResponseArtikli[] = [];
  public artikalzabrisanje: ArtikalObrisiRequest | null = null;
  public artikalzauredjivanje:any;
  ngOnInit(): void {
    this.artikalgetalldendpoint.obradi().subscribe((x:ArtikalGetAllResponse)=>{
      this.artikli = x.artikal;
      this.artikalzauredjivanje ={
        id: 0,
        naziv: "",
        cijena: 0,
        opis: "",
        kratkiOpis: "",
        stanjeNaSkladistu: 0,
        sifra: 0,
        model: ""

      }
    })

  }

  odaberiZaUredjivanje(item:any):void{
    this.artikalzauredjivanje ={
      id: item.id,
      naziv: item.naziv,
      cijena: item.cijena,
      opis: item.opis,
      kratkiOpis: item.kratkiOpis,
      stanjeNaSkladistu: item.stanjeNaSkladistu,
      sifra: item.sifra,
      model: item.model

    }
  }
  odaberiZaBrisanje(poslaniId:number): void{
    this.artikalzabrisanje ={
      id:poslaniId
    };
  }
  uredi():void{
    this.artikalurediendpoint.obradi(this.artikalzauredjivanje!).subscribe((x)=>{
      alert("Artikal Uređen")
      this.ngOnInit();
      this.artikalzauredjivanje = null;
    })
}
  obrisi():void{
    this.artikalobrisiendpoint.obradi(this.artikalzabrisanje!).subscribe((x)=>{
      alert("Artikal Obrisan")
      this.ngOnInit();
      this.artikalzabrisanje = null
    })
  }
  callbrisanje(id: number){
    this.odaberiZaBrisanje(id);
    this.obrisi();
  }

}
