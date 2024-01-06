import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(public router: Router) {
  }
    naziv="";
  ngOnInit(): void {
    this.router.navigate(["/prikaz"])
  }
  preuzmiPodatke($event:Event){
    // @ts-ignore
    this.naziv = $event.target.value;

  }

  reload() {
    this.router.navigate(["/pretraganaziv/"+this.naziv]);
  }
}
