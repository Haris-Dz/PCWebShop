import { Component, OnInit } from '@angular/core';
import {
  GradGetallEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGradovi
} from "../../endpoints/grad-endpoints/grad-getall.endpoint";
import {NovaRegistracijaEndpoint} from "../../endpoints/registracija-endpoints/nova-registracija.endpoint";
import {provideRoutes, Router} from "@angular/router";
import {
  PretragaUsernameEndpoint,
  PretragaUsernameResponse
} from "../../endpoints/registracija-endpoints/pretraga-username.endpoint";
import {PretragaEmailEndpoint} from "../../endpoints/registracija-endpoints/pretraga-email.endpoint";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;
@Component({
  selector: 'app-register-korisnika',
  templateUrl: './register-korisnika.component.html',
  styleUrls: ['./register-korisnika.component.css']
})
export class RegisterKorisnikaComponent implements OnInit {
  nazivNaloga?: string;


  constructor(private router: Router,
              private gradGetAllEndpoint:GradGetallEndpoint,
              private novaRegistracijaEndpoint:NovaRegistracijaEndpoint,
              private pretragaUsernameEndpoint:PretragaUsernameEndpoint,
              private pretragaEmailEndpoint:PretragaEmailEndpoint
              ) { }
  gradovi: GradGetAllResponseGradovi[]=[];
  pripremikorisnik:any=null;
  passwordprovjera:string="";
  emailResponse:any;
  ngOnInit(): void {
    this.fetchGradovi();
   this.passwordprovjera="";

    this.pripremikorisnik=
      {
        korisnickoIme:"",
        lozinka: "",
        slika_base64_format: "",
        ime: "",
        prezime: "",
        email: "",
        brojMobitela: "",
        gradId: 1
      }
  }
  fetchGradovi()
  {
    this.gradGetAllEndpoint.obradi().subscribe((x:GradGetAllResponse)=>{
      this.gradovi=x.gradovi
    })
  }
  preuzmiNovePodatke($event: Event) {

    // @ts-ignore
    let pretrazivaniKnalog = $event.target.value;
    this.pretragaUsernameEndpoint.obradi(pretrazivaniKnalog).subscribe((x:PretragaUsernameResponse)=>{
      this.nazivNaloga = x.kNalog;
    })
  }
  provjeri():boolean {
    return  this.nazivNaloga != "";
  }
  registruj() {
    this.pretragaEmailEndpoint.obradi(this.pripremikorisnik.email).subscribe((x)=>{
      this.emailResponse = x;

    })
    if (this.emailResponse.email == this.pripremikorisnik.email)
    {

      porukaError("email se vec koristi")
      return;
    }

    if(this.pripremikorisnik.lozinka!=this.passwordprovjera)
    {
      porukaError("Lozinke nisu iste")
      return;
    }
    if(this.pripremikorisnik.korisnickoIme == ""
      || this.pripremikorisnik.ime == ""
      || this.pripremikorisnik.prezime==""
      || this.pripremikorisnik.brojMobitela == ""
      || this.pripremikorisnik.email == ""
      || this.pripremikorisnik.lozinka == ""){
      porukaError("Polje obavezno")
      return;
    }

    this.novaRegistracijaEndpoint.obradi(this.pripremikorisnik!).subscribe((x)=>{

      porukaSuccess("Uspjesno Registrovan");
      this.pripremikorisnik=null;
      this.router.navigate(['/home'])
    })


  }
  generisi_previewDefault() {
    // @ts-ignore
    var file = document.getElementById("/assets/").files[0];
    if (file && this.pripremikorisnik) {
      var reader = new FileReader();
      reader.onload = () => {
        this.pripremikorisnik!.slika_base64_format = reader.result?.toString();
      }
      reader.readAsDataURL(file)
    }
  }

  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file && this.pripremikorisnik) {
      var reader = new FileReader();
      reader.onload = () => {
        this.pripremikorisnik!.slika_base64_format = reader.result?.toString();
      }
      reader.readAsDataURL(file)
    }
  }
}
