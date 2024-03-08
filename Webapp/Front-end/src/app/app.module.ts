import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { ArtikalGetallComponent } from './components/artikal-getall/artikal-getall.component';
import {HttpClientModule} from "@angular/common/http";
import {RouterModule, RouterOutlet} from "@angular/router";
import { ArtikalGetByIdComponent } from './components/artikal-get-by-id/artikal-get-by-id.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UpravljanjeArtiklimaComponent } from './components/upravljanje-artiklima/upravljanje-artiklima.component';
import { ArtikalPretragaNazivComponent } from './components/artikal-pretraga-naziv/artikal-pretraga-naziv.component';
import { ArtikalGetByKategorijaComponent } from './components/artikal-get-by-kategorija/artikal-get-by-kategorija.component';
import { UpravljanjeGradovimaComponent } from './components/upravljanje-gradovima/upravljanje-gradovima.component';
import { UpravljanjePopustimaComponent } from './components/upravljanje-popustima/upravljanje-popustima.component';
import { UpravljanjeProizvodjacimaComponent } from './components/upravljanje-proizvodjacima/upravljanje-proizvodjacima.component';
import {LocationStrategy, HashLocationStrategy, NgOptimizedImage} from '@angular/common';
import { RegisterKorisnikaComponent } from './components/register-korisnika/register-korisnika.component';
import { ErrorHandlerService } from './helper/error-handler.service';
import {ErrorInterceptor} from "./helper/error-interceptor";
import{AuthInterceptor} from "./services/auth-interceptor.service";


@NgModule({
  declarations: [
    AppComponent,
    ArtikalGetallComponent,
    ArtikalGetByIdComponent,
    UpravljanjeArtiklimaComponent,
    ArtikalPretragaNazivComponent,
    ArtikalGetByKategorijaComponent,
    UpravljanjeGradovimaComponent,
    UpravljanjePopustimaComponent,
    UpravljanjeProizvodjacimaComponent,
    RegisterKorisnikaComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,

    HttpClientModule,
    RouterOutlet,
    RouterModule.forRoot([
      {path: 'home', component: ArtikalGetallComponent},
      {path: '', redirectTo: '/home', pathMatch: 'full'},
      {path: 'artikalGetById/:id', component: ArtikalGetByIdComponent},
      {path: 'upravljanjeArtiklima', component: UpravljanjeArtiklimaComponent},
      {path: 'pretraganaziv/:naziv', component: ArtikalPretragaNazivComponent},
      {path: 'artikalGetByKategorija/:id', component: ArtikalGetByKategorijaComponent},
      {path: 'upravljanje-gradovima', component: UpravljanjeGradovimaComponent},
      {path: 'upravljanje-popusutima', component: UpravljanjePopustimaComponent},
      {path: 'upravljanje-proizvodjacima', component: UpravljanjeProizvodjacimaComponent},
      {path: 'register-korisnika', component: RegisterKorisnikaComponent},

    ]),
    NgbModule,
    ReactiveFormsModule,
    NgOptimizedImage
  ],
  providers: [{provide: LocationStrategy, useClass: HashLocationStrategy}
    ,ErrorHandlerService,{provide:HTTP_INTERCEPTORS,useClass:AuthInterceptor,multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
