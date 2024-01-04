import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { ArtikalGetallComponent } from './artikal-getall/artikal-getall.component';
import {HttpClientModule} from "@angular/common/http";
import {RouterModule, RouterOutlet} from "@angular/router";
import { ArtikalGetByIdComponent } from './artikal-get-by-id/artikal-get-by-id.component';
import { DodajArtikalComponent } from './dodaj-artikal/dodaj-artikal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    AppComponent,
    ArtikalGetallComponent,
    ArtikalGetByIdComponent,
    DodajArtikalComponent,
  ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        RouterOutlet,
        RouterModule.forRoot([
            {path: 'prikaz', component: ArtikalGetallComponent},
            {path: 'artikalGetById/:id', component: ArtikalGetByIdComponent},
            {path: 'dodajArtikal', component: DodajArtikalComponent},
        ]),
        NgbModule,
        ReactiveFormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
