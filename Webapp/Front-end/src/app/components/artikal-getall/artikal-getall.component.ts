import { Component, OnInit } from '@angular/core';
import {
  ArtikalGetallEndpoint, ArtikalGetAllResponse,
  ArtikalGetAllResponseArtikli
} from "../../endpoints/artikal-endpoints/artikal-getall.endpoint";


@Component({
  selector: 'app-artikal-getall',
  templateUrl: './artikal-getall.component.html',
  styleUrls: ['./artikal-getall.component.css']
})
export class ArtikalGetallComponent implements OnInit {

  constructor(private artikalgetalldendpoint:ArtikalGetallEndpoint) {

  }

  artikli: ArtikalGetAllResponseArtikli[] = [];
  ngOnInit(): void {
      this.artikalgetalldendpoint.obradi().subscribe((x:ArtikalGetAllResponse)=>{
        this.artikli = x.artikal
    })
  }


}
