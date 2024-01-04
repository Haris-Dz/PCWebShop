import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  constructor(public router: Router, private httpClient: HttpClient) {
  }
  ngOnInit(): void {
  }
  idi(s:string)
  {
    this.router.navigate([s])
  }
}
