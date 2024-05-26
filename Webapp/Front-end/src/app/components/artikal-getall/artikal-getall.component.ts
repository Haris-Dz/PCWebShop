import { Component, OnInit } from '@angular/core';
import {
  ArtikalGetallEndpoint, ArtikalGetAllResponse,
  ArtikalGetAllResponseArtikli
} from "../../endpoints/artikal-endpoints/artikal-getall.endpoint";
import {MyAuthService} from "../../services/myAuthService";
import {StavkaNarudzbeDodajEndpoint} from "../../endpoints/narudzba-endpoints/stavka-narudzbe-dodaj.endpoint";
import {NarudzbaGetEndpoint} from "../../endpoints/narudzba-endpoints/narudzba-get.endpoint";
import {RefreshService} from "../../services/refresh.service";


@Component({
  selector: 'app-artikal-getall',
  templateUrl: './artikal-getall.component.html',
  styleUrls: ['./artikal-getall.component.css']
})
export class ArtikalGetallComponent implements OnInit {


  constructor(private artikalgetalldendpoint:ArtikalGetallEndpoint,
              private stavkaNarudzbeDodajEndpoint:StavkaNarudzbeDodajEndpoint,
              private narudzbaGetEndpoint:NarudzbaGetEndpoint,
              public myAuthService:MyAuthService,
              private refreshService: RefreshService) {

  }
  artikli: ArtikalGetAllResponseArtikli[] = [];
  novaStavka: any;
  narudzbareq : any=null;
  narudzbaresponse:any=null;
  ngOnInit(): void {

    this.narudzbareq={
      kupacId:1
    }
      this.artikalgetalldendpoint.obradi().subscribe((x:ArtikalGetAllResponse)=>{
        this.artikli = x.artikal
    })
    this.fetchNarudzbe()
    this.novaStavka ={
      cijena: 0,
      kolicina: 0,
      artikalId: 1,
      narudzbaId: 1
    }
  }

  handleError($event: ErrorEvent) {
    // @ts-ignore
    event.target.src = "assets/prazno.jpg"
  }
  fetchNarudzbe(){
    this.narudzbareq.kupacId=this.myAuthService.getId();
    this.narudzbaGetEndpoint.obradi(this.narudzbareq).subscribe((x)=>{
      this.narudzbaresponse = x;
    })
  }
  dodajnovustavku(id:number,cijena:number,) {
    this.novaStavka.kolicina+=1;
    this.novaStavka.artikalId = id;
    this.novaStavka.cijena = cijena;
    this.novaStavka.narudzbaId=this.narudzbaresponse.id;

    this.stavkaNarudzbeDodajEndpoint.obradi(this.novaStavka!).subscribe((x)=>{
      this.novaStavka = null;
      this.ngOnInit();
      this.refreshComponent1()

    })
  }
  refreshComponent1() {
    this.refreshService.triggerRefresh();
  }
}
