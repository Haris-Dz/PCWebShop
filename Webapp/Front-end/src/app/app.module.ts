import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { ArtikalGetallComponent } from './components/artikal-getall/artikal-getall.component';
import {HttpClientModule} from "@angular/common/http";
import {RouterModule, RouterOutlet} from "@angular/router";
import { ArtikalGetByIdComponent } from './components/artikal-get-by-id/artikal-get-by-id.component';
import { DodajArtikalComponent } from './components/dodaj-artikal/dodaj-artikal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UpravljanjeArtiklimaComponent } from './components/upravljanje-artiklima/upravljanje-artiklima.component';
import { ArtikalPretragaNazivComponent } from './components/artikal-pretraga-naziv/artikal-pretraga-naziv.component';


@NgModule({
  declarations: [
    AppComponent,
    ArtikalGetallComponent,
    ArtikalGetByIdComponent,
    DodajArtikalComponent,
    UpravljanjeArtiklimaComponent,
    ArtikalPretragaNazivComponent,
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
            {path: 'upravljanjeArtiklima', component: UpravljanjeArtiklimaComponent},
            {path: 'pretraganaziv/:naziv', component: ArtikalPretragaNazivComponent},

        ]),
        NgbModule,
        ReactiveFormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
