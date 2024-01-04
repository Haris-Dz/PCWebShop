import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ArtikalGetbyIdResponse} from "./artikal-getbyId-response";
import { ActivatedRoute } from '@angular/router';
import {MojConfig} from "../moj-config";



@Component({
  selector: 'app-artikal-get-by-id',
  templateUrl: './artikal-get-by-id.component.html',
  styleUrls: ['./artikal-get-by-id.component.css']
})
export class ArtikalGetByIdComponent implements OnInit {

  constructor(public httpClient: HttpClient, private activatedroute:ActivatedRoute) {

  }
   id  = this.activatedroute.snapshot.params["id"];

  artikal:any;
  ngOnInit(): void {
    let url = MojConfig.adresa_servera + `/artikal/get-by-id?id=${this.id}`
    this.httpClient.get<ArtikalGetbyIdResponse>(url).subscribe((x:ArtikalGetbyIdResponse)=>{
      this.artikal = x;

    })
  }
  isEmpty(element:any) {
    if (element == null) {
      return "Nije Pronađeno";
    }
    else
    {
      return element;
    }

  }


}
