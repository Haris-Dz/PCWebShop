import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {
  KategorijeGetAllEndpoint, KategorijeGetAllResponse,
  KategorijeGetAllResponseKategorije
} from "./endpoints/kategorija-endpoints/kategorija-getall.endpoint";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(public router: Router,private kategorijagetallendpoint:KategorijeGetAllEndpoint) {
  }
    naziv="";
    kategorije:KategorijeGetAllResponseKategorije[]=[];


  ngOnInit(): void {
    this.router.navigate(["/prikaz"])
    this.kategorijagetallendpoint.obradi().subscribe((x:KategorijeGetAllResponse)=>{
      this.kategorije = x.kategorije;
    })

  }

  preuzmiPodatke($event:Event){
    // @ts-ignore
    this.naziv = $event.target.value;

  }

  reloadnaziv() {
    this.router.navigate(["/pretraganaziv/"+this.naziv]);
  }
  reloadkategorija(id:number) {
    this.router.navigate(["artikalGetByKategorija/"+id]);
  }
}
