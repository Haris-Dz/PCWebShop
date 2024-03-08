import { Component, OnInit } from '@angular/core';
import {
  ArtikalGetallEndpoint, ArtikalGetAllResponse,
  ArtikalGetAllResponseArtikli
} from "../../endpoints/artikal-endpoints/artikal-getall.endpoint";
import {Event} from "@angular/router";


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

  handleError($event: ErrorEvent) {
    // @ts-ignore
    event.target.src = "assets/prazno.jpg"
  }
}
