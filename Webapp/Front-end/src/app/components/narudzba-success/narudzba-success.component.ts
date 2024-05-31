import { Component, OnInit } from '@angular/core';
import {
  NarudzbaZavrsiEndpoint,
  NarudzbaZavrsiResponse
} from "../../endpoints/narudzba-endpoints/narudzba-zavrsi.endpoint";
import {ActivatedRoute} from "@angular/router";
import {ArtikalGetbyIdResponse} from "../../endpoints/artikal-endpoints/artikal-getbyid.endpoint";
import {RefreshService} from "../../services/refresh.service";

@Component({
  selector: 'app-narudzba-success',
  templateUrl: './narudzba-success.component.html',
  styleUrls: ['./narudzba-success.component.css']
})
export class NarudzbaSuccessComponent implements OnInit {

  constructor(private narudzbaZavrsiEndpoint:NarudzbaZavrsiEndpoint,
              private activatedroute:ActivatedRoute,
              private refreshService: RefreshService) { }
  id = this.activatedroute.snapshot.params["id"];
  narudzba:any;
  zavrsiKupovinu(){
    this.narudzbaZavrsiEndpoint.obradi(this.id).subscribe((x:NarudzbaZavrsiResponse)=>{
      this.narudzba=x;
      this.refreshComponent1()
    });
  }
  ngOnInit(): void {
    this.zavrsiKupovinu();
  }
  refreshComponent1() {
    this.refreshService.triggerRefresh();
  }
}
