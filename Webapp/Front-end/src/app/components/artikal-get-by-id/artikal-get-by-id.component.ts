import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {ArtikalGetbyIdEndpoint, ArtikalGetbyIdResponse} from "../../endpoints/artikal-endpoints/artikal-getbyid.endpoint";

@Component({
  selector: 'app-artikal-get-by-id',
  templateUrl: './artikal-get-by-id.component.html',
  styleUrls: ['./artikal-get-by-id.component.css']
})
export class ArtikalGetByIdComponent implements OnInit {

  constructor(private activatedroute:ActivatedRoute,private artikalgetbyidendpoint:ArtikalGetbyIdEndpoint) {

  }
   id = this.activatedroute.snapshot.params["id"];
  artikal:any;

  fetchArtikal(){
    this.artikalgetbyidendpoint.obradi(this.id).subscribe((x:ArtikalGetbyIdResponse)=>{
      this.artikal=x;
    })
  }

  ngOnInit(): void {
    this.fetchArtikal();
    this.artikal={}
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
