import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {
  ArtikalGetbyKategorijaArtikli, ArtikalGetbyKategorijaEndpoint,
  ArtikalGetbyKategorijaResponse
} from "../../endpoints/artikal-endpoints/artikal-getbykategorija.endpoint";

@Component({
  selector: 'app-artikal-get-by-kategorija',
  templateUrl: './artikal-get-by-kategorija.component.html',
  styleUrls: ['./artikal-get-by-kategorija.component.css']
})
export class ArtikalGetByKategorijaComponent implements OnInit {

  constructor(private activatedroute:ActivatedRoute,
              private artikalgetbykategorijaendpoint:ArtikalGetbyKategorijaEndpoint,
              private router:Router) { }
  id = this.activatedroute.snapshot.params["id"];
  artikli:ArtikalGetbyKategorijaArtikli[]=[]
  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => { return false; };
    this.artikalgetbykategorijaendpoint.obradi(this.id).subscribe((x:ArtikalGetbyKategorijaResponse)=>{
      this.artikli = x.artikal;
    })
  }

}
