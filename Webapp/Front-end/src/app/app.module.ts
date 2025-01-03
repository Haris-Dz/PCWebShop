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
import{AuthInterceptor} from "./services/auth-interceptor.service";
import { UpravljanjeKorisnicimaComponent } from './components/upravljanje-korisnicima/upravljanje-korisnicima.component';
import { KorisnikProfilComponent } from './components/korisnik-profil/korisnik-profil.component';
import { UpravljanjeNarudzbamaComponent } from './components/upravljanje-narudzbama/upravljanje-narudzbama.component';
import { ArtikalGetByPopustiComponent } from './components/artikal-get-by-popusti/artikal-get-by-popusti.component';
import { NarudzbaSuccessComponent } from './components/narudzba-success/narudzba-success.component';
import { SlanjeSmsComponent } from './components/slanje-sms/slanje-sms.component';
import { ZaposlenikProfilComponent } from './components/zaposlenik-profil/zaposlenik-profil.component';
import { AdministratorProfilComponent } from './components/administrator-profil/administrator-profil.component';
import { PregledNarudzbiComponent } from './components/pregled-narudzbi/pregled-narudzbi.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';


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
    UpravljanjeKorisnicimaComponent,
    KorisnikProfilComponent,
    UpravljanjeNarudzbamaComponent,
    ArtikalGetByPopustiComponent,
    NarudzbaSuccessComponent,
    SlanjeSmsComponent,
    ZaposlenikProfilComponent,
    AdministratorProfilComponent,
    PregledNarudzbiComponent,
    ResetPasswordComponent,

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
      {path: 'upravljanje-korisnicima', component: UpravljanjeKorisnicimaComponent},
      {path: 'korisnik-profil', component:KorisnikProfilComponent},
      {path:'upravljanje-narudzbama/:id',component:UpravljanjeNarudzbamaComponent},
      {path:'artikalGetByPopust/:id',component:ArtikalGetByPopustiComponent},
      {path:'narudzba-success/:id',component:NarudzbaSuccessComponent},
      {path:'slanje-sms',component:SlanjeSmsComponent},
      {path:'zaposlenik-profil',component:ZaposlenikProfilComponent},
      {path:'administrator-profil',component:AdministratorProfilComponent},
      {path:'pregled-narudzbi',component:PregledNarudzbiComponent},
      {path:'reset-password',component:ResetPasswordComponent}
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
