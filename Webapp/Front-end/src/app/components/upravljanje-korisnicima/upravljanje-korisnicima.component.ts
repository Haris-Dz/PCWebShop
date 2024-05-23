import { Component, OnInit } from '@angular/core';
import {
  GetAllZaposleniciResponse,
  ZaposlenikGetallEndpoint
} from "../../endpoints/zaposlenik-endpoint/zaposlenik-getall.endpoint";
import {ZaposlenikGetByNazivEndpoint} from "../../endpoints/zaposlenik-endpoint/zaposlenik-getbynaziv.endpoint";
import {GradGetallEndpoint, GradGetAllResponse} from "../../endpoints/grad-endpoints/grad-getall.endpoint";
import {ZaposlenikDodajEndpoint} from "../../endpoints/zaposlenik-endpoint/zaposlenik-dodaj.endpoint";
import {ErrorHandlerService} from "../../helper/error-handler.service";
import {ZaposlenikUrediEndpoint} from "../../endpoints/zaposlenik-endpoint/zaposlenik-uredi.endpoint";
import {ZaposlenikObrisiEndpoint} from "../../endpoints/zaposlenik-endpoint/zaposlenik-obrisi.endpoint";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-upravljanje-korisnicima',
  templateUrl: './upravljanje-korisnicima.component.html',
  styleUrls: ['./upravljanje-korisnicima.component.css']
})
export class UpravljanjeKorisnicimaComponent implements OnInit {

  constructor(private zaposlenikGetallEndpoint:ZaposlenikGetallEndpoint,
              private zaposlenikGetByNazivEndpoint:ZaposlenikGetByNazivEndpoint,
              private gradGetallEndpoint:GradGetallEndpoint,
              private zaposlenikDodajEndpoint:ZaposlenikDodajEndpoint,
              private zaposlenikUrediEndpoint:ZaposlenikUrediEndpoint,
              private errorHandlerService:ErrorHandlerService,
              private zaposlenikObrisiEndpoint:ZaposlenikObrisiEndpoint) { }
  zaposlenici:any;
  novizaposlenik:any=null;
  gradovi:any;
  zaposlenikEdit:any= null;
  ngOnInit(): void {
    this.fetchZaposlenici();
  }
  fetchZaposlenici(){
    this.zaposlenikGetallEndpoint.obradi().subscribe((x:GetAllZaposleniciResponse)=>{
      this.zaposlenici = x.zaposlenik;
    })
  }
  fetchGradovi(){
    this.gradGetallEndpoint.obradi().subscribe((x:GradGetAllResponse)=>{
      this.gradovi = x.gradovi;
    })
  }


  preuzmiNovePodatke($event: Event) {

    // @ts-ignore
    let pretrazivaniZaposlenik = $event.target.value;
    this.zaposlenikGetByNazivEndpoint.obradi(pretrazivaniZaposlenik).subscribe((x:GetAllZaposleniciResponse)=>{
      this.zaposlenici = x.zaposlenik;
    })
  }

  pripremi() {
    this.novizaposlenik=
      {
        korisnickoIme: "",
        slika_base64_format: "",
        ime: "",
        prezime: "",
        ulica: "",
        email: "",
        brojMobitela: "",
        gradId: 5
      }
      this.fetchGradovi();
  }

  spasi() {
   this.zaposlenikDodajEndpoint.obradi(this.novizaposlenik).subscribe((x)=>{
     porukaSuccess("Uspjesno Registrovan");
     this.novizaposlenik=null;
    },(error)=>{
     porukaError(this.errorHandlerService.handleError(error))
   })


  }

  pripremiUredi(item:any) {
    this.zaposlenikEdit = item;
    this.zaposlenikEdit.gradId=item.gradId
    this.fetchGradovi();
  }

  spasiedit() {
    this.zaposlenikUrediEndpoint.obradi(this.zaposlenikEdit).subscribe((x)=>{
      porukaSuccess("Uspjesno Uredjen");
      this.zaposlenikEdit = null;
      this.ngOnInit();
    },(error)=>{
      porukaError(this.errorHandlerService.handleError(error))
    })

  }

  obrisi(id:number) {
    this.zaposlenikObrisiEndpoint.obradi(id).subscribe((x)=>{
      porukaSuccess("Uspjesno Obrisan");
      this.ngOnInit();
    },(error)=>{
      porukaError(this.errorHandlerService.handleError(error))
    })

  }

  generisi_preview() {
    // @ts-ignore
    var file = document.getElementById("slika-input").files[0];
    if (file && this.novizaposlenik) {
      var reader = new FileReader();
      reader.onload = () => {
        this.novizaposlenik!.slika_base64_format = reader.result?.toString();
      }
      reader.readAsDataURL(file)
    }
  }
}
