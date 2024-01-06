import { Component, OnInit } from '@angular/core';
import {
  ArtikalPretragaNazivArtikli,
  ArtikalPretragaNazivEndpoint, ArtikalPretragaNazivResponse
} from "../../endpoints/artikal-endpoints/artika-pretraganaziv.endpoint";
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-artikal-pretraga-naziv',
  templateUrl: './artikal-pretraga-naziv.component.html',
  styleUrls: ['./artikal-pretraga-naziv.component.css']
})
export class ArtikalPretragaNazivComponent implements OnInit {

  constructor(private activatedroute:ActivatedRoute, private artikalpretraganazivendpoint:ArtikalPretragaNazivEndpoint,private router:Router) { }
  naziv = this.activatedroute.snapshot.params["naziv"]
  artikli:ArtikalPretragaNazivArtikli[]=[];

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => { return false; };
    this.artikalpretraganazivendpoint.obradi(this.naziv).subscribe((x:ArtikalPretragaNazivResponse)=>{
      this.artikli=x.artikal;
    })
  }

}
