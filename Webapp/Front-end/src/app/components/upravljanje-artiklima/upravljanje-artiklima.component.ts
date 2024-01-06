import { Component, OnInit } from '@angular/core';
import {
  ArtikalGetallEndpoint, ArtikalGetAllResponse,
  ArtikalGetAllResponseArtikli
} from "../../endpoints/artikal-endpoints/artikal-getall.endpoint";
import {ArtikalObrisiEndpoint, ArtikalObrisiRequest} from "../../endpoints/artikal-endpoints/artikal-obrisi.endpoint";
import {ArtikalUrediEndpoint, ArtikalUrediRequest} from "../../endpoints/artikal-endpoints/artikal-uredi.endpoint";
import {MojConfig} from "../../moj-config";
import {
  ArtikalPretragaNazivEndpoint,
  ArtikalPretragaNazivResponse
} from "../../endpoints/artikal-endpoints/artika-pretraganaziv.endpoint";
import {HttpClient} from "@angular/common/http";
@Component({
  selector: 'app-upravljanje-artiklima',
  templateUrl: './upravljanje-artiklima.component.html',
  styleUrls: ['./upravljanje-artiklima.component.css']
})

export class UpravljanjeArtiklimaComponent implements OnInit {

  constructor(
    private artikalgetalldendpoint:ArtikalGetallEndpoint,
    private artikalobrisiendpoint:ArtikalObrisiEndpoint,
    private artikalurediendpoint:ArtikalUrediEndpoint,
    private httpClient:HttpClient) { }

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
  preuzmiNovePodatke($event: Event) {

    // @ts-ignore
    let pretrazivaniArtikal = $event.target.value;
    let url = MojConfig.adresa_servera +`/artikal/get-by-naziv?Naziv=${pretrazivaniArtikal}`
    this.httpClient.get<ArtikalPretragaNazivResponse>(url).subscribe((x:ArtikalPretragaNazivResponse)=>{
      this.artikli=x.artikal;
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
