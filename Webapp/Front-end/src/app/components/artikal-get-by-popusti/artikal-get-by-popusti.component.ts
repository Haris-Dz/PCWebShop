import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {
  ArtikalGetbyPopustArtikli,
  ArtikalGetbyPopustEndpoint, ArtikalGetbyPopustResponse
} from "../../endpoints/artikal-endpoints/artikal-getbypopust.endpoint";
@Component({
  selector: 'app-artikal-get-by-popusti',
  templateUrl: './artikal-get-by-popusti.component.html',
  styleUrls: ['./artikal-get-by-popusti.component.css']
})
export class ArtikalGetByPopustiComponent implements OnInit {

  constructor(private activatedroute:ActivatedRoute,
              private router:Router,
              private artikalGetbyPopustEndpoint:ArtikalGetbyPopustEndpoint
              ) { }
  id = this.activatedroute.snapshot.params["id"];
  artikli:ArtikalGetbyPopustArtikli[]=[]
  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => { return false; };
    this.artikalGetbyPopustEndpoint.obradi(this.id).subscribe((x:ArtikalGetbyPopustResponse)=>{
      this.artikli = x.artikal;
    })
  }

}
