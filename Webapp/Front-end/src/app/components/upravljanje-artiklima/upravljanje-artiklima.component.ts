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
import {
  ProizvodjacGetallEndpoint,
  ProizvodjacGetAllResponse, ProizvodjacGetAllResponseProizvodjaci
} from "../../endpoints/proizvodjac-endpoints/proizvodjac-getall.endpoint";
import {
  PopustGetAllEndpoint, PopustGetAllResponse,
  PopustGetAllResponsePopusti
} from "../../endpoints/popust-endpoints/popust-getall.endpoint";
import {
  KategorijeGetAllEndpoint,
  KategorijeGetAllResponse,
  KategorijeGetAllResponseKategorije
} from "../../endpoints/kategorija-endpoints/kategorija-getall.endpoint";
import {ArtikalDodajEndpoint, ArtikaldodajRequest} from "../../endpoints/artikal-endpoints/artikal-dodaj.endpoint";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

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
    private proizvodjacGetallEndpoint:ProizvodjacGetallEndpoint,
    private popustGetAllEndpoint:PopustGetAllEndpoint,
    private kategorijeGetAllEndpoint:KategorijeGetAllEndpoint,
    private artikalDodajEndpoint:ArtikalDodajEndpoint,
    private httpClient:HttpClient) { }

  public prikaziFormu: boolean = false;
  artikli: ArtikalGetAllResponseArtikli[] = [];
  proizvodjaci: ProizvodjacGetAllResponseProizvodjaci[]=[];
  popusti:PopustGetAllResponsePopusti[]=[];
  kategorije: KategorijeGetAllResponseKategorije[]=[];
  public artikalzabrisanje: ArtikalObrisiRequest | null = null;
  public artikalzauredjivanje:any;
  artikalzadodavanje: any = null;

  fetchArtikli(){
    this.artikalgetalldendpoint.obradi().subscribe((x:ArtikalGetAllResponse)=>{
      this.artikli = x.artikal;
    })
  }
  fetchProizvodjaci(){
    this.proizvodjacGetallEndpoint.obradi().subscribe((x:ProizvodjacGetAllResponse)=>{
      this.proizvodjaci = x.proizvodjaci;
    })
  }
  fetchPopusti(){
    this.popustGetAllEndpoint.obradi().subscribe((x:PopustGetAllResponse)=>{
      this.popusti = x.popusti;
    })
  }
  fetchKategorije(){
    this.kategorijeGetAllEndpoint.obradi().subscribe((x:KategorijeGetAllResponse)=>{
      this.kategorije = x.kategorije;
    })
  }
  ngOnInit(): void {
  this.fetchArtikli();
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
    this.artikalzauredjivanje =item;
    this.fetchProizvodjaci();
    this.fetchPopusti();
    this.fetchKategorije();
  }
  odaberiZaBrisanje(poslaniId:number): void{
    this.artikalzabrisanje ={
      id:poslaniId
    };
  }
  uredi():void{
    this.artikalurediendpoint.obradi(this.artikalzauredjivanje!).subscribe((x)=>{
      this.artikalzauredjivanje = null;
      porukaSuccess('Artikal Uredjen');
      this.ngOnInit();

    })


}
  obrisi():void{
    this.artikalobrisiendpoint.obradi(this.artikalzabrisanje!).subscribe((x)=>{
      porukaSuccess("Artikal Obrisan")
      this.ngOnInit();
      this.artikalzabrisanje = null
    })
  }
  callbrisanje(id: number){
    this.odaberiZaBrisanje(id);
    this.obrisi();
  }

  pripremi() {
    this.artikalzadodavanje = {
      naziv: "",
      cijena: 0,
      opis: "",
      kratkiOpis: "",
      stanjeNaSkladistu: 0,
      sifra: 0,
      model: "",
      artikalKategorijaId: null,
      popustId:null,
      proizvodjacId: null,
      slika_base64_format: ""
    } ;
    this.fetchProizvodjaci();
    this.fetchPopusti();
    this.fetchKategorije();
  }

  dodaj() {
    this.artikalDodajEndpoint.obradi(this.artikalzadodavanje!).subscribe((x)=>{
      porukaSuccess("Artikal Dodan")
      this.artikalzadodavanje = null;
      this.ngOnInit();
    })
  }

  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file && this.artikalzadodavanje) {
      var reader = new FileReader();
      reader.onload = () => {
        this.artikalzadodavanje!.slika_base64_format = reader.result?.toString();
      }
      reader.readAsDataURL(file)
    }
  }
}
