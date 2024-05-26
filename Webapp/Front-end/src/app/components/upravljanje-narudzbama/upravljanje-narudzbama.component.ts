import { Component, OnInit } from '@angular/core';
import {NarudzbaGetEndpoint} from "../../endpoints/narudzba-endpoints/narudzba-get.endpoint";
import {MyAuthService} from "../../services/myAuthService";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-upravljanje-narudzbama',
  templateUrl: './upravljanje-narudzbama.component.html',
  styleUrls: ['./upravljanje-narudzbama.component.css']
})
export class UpravljanjeNarudzbamaComponent implements OnInit {

  constructor(private narudzbaGetEndpoint:NarudzbaGetEndpoint,
              private activatedroute:ActivatedRoute,
              public myAuthService:MyAuthService) { }
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

}
