import { Component, OnInit } from '@angular/core';
import {NarudzbaGetEndpoint} from "../../endpoints/narudzba-endpoints/narudzba-get.endpoint";
import {MyAuthService} from "../../services/myAuthService";
import {StavkaNarudzbeUkloniEndpoint} from "../../endpoints/narudzba-endpoints/stavka-narudzbe-ukloni.endpoint";
import {RefreshService} from "../../services/refresh.service";

@Component({
  selector: 'app-upravljanje-narudzbama',
  templateUrl: './upravljanje-narudzbama.component.html',
  styleUrls: ['./upravljanje-narudzbama.component.css']
})
export class UpravljanjeNarudzbamaComponent implements OnInit {

  constructor(private narudzbaGetEndpoint:NarudzbaGetEndpoint,
              private stavkaNarudzbeUkloniEndpoint:StavkaNarudzbeUkloniEndpoint,
              public myAuthService:MyAuthService,
              private refreshService: RefreshService) { }
  narudzbareq : any=null;
  narudzbaresponse:any=null;
  ukupno:number=0;
  ngOnInit(): void {
    this.narudzbareq={
      kupacId:0
    }
    this.fetchNarudzbe();
  }
  fetchNarudzbe(){
    this.narudzbareq.kupacId=this.myAuthService.getId();
    this.narudzbaGetEndpoint.obradi(this.narudzbareq).subscribe((x)=>{
      this.narudzbaresponse = x;
      this.ukupno=x.ukupnoStavki;
    })
  }
  UkloniStavku(idStavke:number) {
    this.stavkaNarudzbeUkloniEndpoint.obradi(idStavke).subscribe((x)=>{
      alert("Uklonjeno");
      this.refreshComponent1()
      this.ngOnInit();
    })
  }
  refreshComponent1() {
    this.refreshService.triggerRefresh();
  }
}
