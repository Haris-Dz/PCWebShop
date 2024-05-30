import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {ArtikalGetbyIdEndpoint, ArtikalGetbyIdResponse} from "../../endpoints/artikal-endpoints/artikal-getbyid.endpoint";
import {StavkaNarudzbeDodajEndpoint} from "../../endpoints/narudzba-endpoints/stavka-narudzbe-dodaj.endpoint";
import {NarudzbaGetEndpoint} from "../../endpoints/narudzba-endpoints/narudzba-get.endpoint";
import {MyAuthService} from "../../services/myAuthService";
import {RefreshService} from "../../services/refresh.service";
import {ArtikalLikeEndpoint} from "../../endpoints/artikal-endpoints/artikal-like.endpoint";
import {
  KomentariGetArtikalEndpoint,
  KomentariGetArtikalResponseKomentari
} from "../../endpoints/komentari-endpoints/komentari-get-artikal.enpoint";
import {KomentarDodajEndpoint} from "../../endpoints/komentari-endpoints/Komentar-dodaj-novi.endpoint";

@Component({
  selector: 'app-artikal-get-by-id',
  templateUrl: './artikal-get-by-id.component.html',
  styleUrls: ['./artikal-get-by-id.component.css']
})
export class ArtikalGetByIdComponent implements OnInit {

  constructor(private activatedroute:ActivatedRoute,
              private artikalgetbyidendpoint:ArtikalGetbyIdEndpoint,
              private stavkaNarudzbeDodajEndpoint:StavkaNarudzbeDodajEndpoint,
              private narudzbaGetEndpoint:NarudzbaGetEndpoint,
              private artikalLikeEndpoint:ArtikalLikeEndpoint,
              private komentariGetArtikalEndpoint:KomentariGetArtikalEndpoint,
              private komentarDodajEndpoint:KomentarDodajEndpoint,
              public myAuthService:MyAuthService,
              private refreshService: RefreshService) {

  }
   id = this.activatedroute.snapshot.params["id"];
  artikal:any;
  novaStavka: any;
  narudzbareq : any=null;
  narudzbaresponse:any=null;
  likecount:number= 0;
  komentari:KomentariGetArtikalResponseKomentari[]=[];
  noviKomentar:any;
  fetchArtikal(){
    this.artikalgetbyidendpoint.obradi(this.id).subscribe((x:ArtikalGetbyIdResponse)=>{
      this.artikal=x;
    })
    this.narudzbareq={
      kupacId:1
    }
    this.fetchNarudzbe()
    this.novaStavka ={
      cijena: 0,
      kolicina: 0,
      artikalId: 1,
      narudzbaId: 1
    }
  }
  fetchKomentari(){
    this.komentariGetArtikalEndpoint.obradi(this.id).subscribe(x=>{
      this.komentari = x.komentari;
    })
  }

  ngOnInit(): void {
    this.fetchArtikal();
    this.fetchKomentari();
    this.artikal={}
    this.noviKomentar ={
      komentari: "",
      kupacId: 0,
      artikalId: 0
    }
  }

  isEmpty(element:any) {
    if (element == null) {
      return "Nije Pronađeno";
    }
    else
    {
      return element;
    }

  }
  fetchNarudzbe(){
    this.narudzbareq.kupacId=this.myAuthService.getId();
    this.narudzbaGetEndpoint.obradi(this.narudzbareq).subscribe((x)=>{
      this.narudzbaresponse = x;
    })
  }
  dodajnovustavku(cijena:number,) {
    this.novaStavka.kolicina+=1;
    this.novaStavka.artikalId = this.id;
    this.novaStavka.cijena = cijena;
    this.novaStavka.narudzbaId=this.narudzbaresponse.id;

    this.stavkaNarudzbeDodajEndpoint.obradi(this.novaStavka!).subscribe((x)=>{
      this.novaStavka = null;
      this.ngOnInit();
      this.refreshComponent1()
      alert("dodano u korpu")

    })
  }
  refreshComponent1() {
    this.refreshService.triggerRefresh();
  }


  likeArtikla() {
    if (this.likecount>0){
      return;
    }
    this.artikalLikeEndpoint.obradi(this.artikal.id).subscribe(x=>{
      this.likecount++;
      this.fetchArtikal();
    })
  }

  komentarisi() {
    this.noviKomentar.artikalId = this.id;
    this.noviKomentar.kupacId = this.myAuthService.getId();
    this.komentarDodajEndpoint.obradi(this.noviKomentar).subscribe(x=>{
      alert("Novi Komentar");
      this.ngOnInit();
    })
  }
}
