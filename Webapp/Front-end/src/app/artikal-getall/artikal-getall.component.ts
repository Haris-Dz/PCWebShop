import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ArtikliGetAllResponse, ArtikliGetAllResponseArtikli} from "./artikli-getall-response";
import {MojConfig} from "../moj-config";


@Component({
  selector: 'app-artikal-getall',
  templateUrl: './artikal-getall.component.html',
  styleUrls: ['./artikal-getall.component.css']
})
export class ArtikalGetallComponent implements OnInit {

  constructor(public httpClient: HttpClient) {

  }

  artikli: ArtikliGetAllResponseArtikli[] = [];
  ngOnInit(): void {
    let url = MojConfig.adresa_servera +'/artikal/get-all'
    this.httpClient.get<ArtikliGetAllResponse>(url).subscribe((x:ArtikliGetAllResponse)=>{
      this.artikli = x.artikal;
    })
  }


}
