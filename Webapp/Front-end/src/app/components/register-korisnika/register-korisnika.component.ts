import { Component, OnInit } from '@angular/core';
import {
  GradGetallEndpoint,
  GradGetAllResponse,
  GradGetAllResponseGradovi
} from "../../endpoints/grad-endpoints/grad-getall.endpoint";
import { NovaRegistracijaEndpoint } from "../../endpoints/registracija-endpoints/nova-registracija.endpoint";
import { Router } from "@angular/router";

declare function porukaSuccess(a: string): any;
declare function porukaError(a: string): any;

@Component({
  selector: 'app-register-korisnika',
  templateUrl: './register-korisnika.component.html',
  styleUrls: ['./register-korisnika.component.css']
})
export class RegisterKorisnikaComponent implements OnInit {

  constructor(
    private router: Router,
    private gradGetAllEndpoint: GradGetallEndpoint,
    private novaRegistracijaEndpoint: NovaRegistracijaEndpoint
  ) { }

  gradovi: GradGetAllResponseGradovi[] = [];
  pripremikorisnik: any = null;
  passwordprovjera: string = "";
  validationErrors: any = {};
  showPassword: boolean = false;
  showConfirmPassword: boolean = false;

  ngOnInit(): void {
    this.fetchGradovi();
    this.passwordprovjera = "";

    this.pripremikorisnik = {
      korisnickoIme: "",
      lozinka: "",
      slika_base64_format: "",
      ime: "",
      prezime: "",
      email: "",
      brojMobitela: "",
      gradId: 1
    }
  }

  fetchGradovi() {
    this.gradGetAllEndpoint.obradi().subscribe((x: GradGetAllResponse) => {
      this.gradovi = x.gradovi;
    })
  }

  registruj() {
    this.validationErrors = {}; // Reset errors

    // Validation checks
    if (!this.pripremikorisnik.korisnickoIme) {
      this.validationErrors.korisnickoIme = 'Required field';
    }
    if (!this.pripremikorisnik.ime) {
      this.validationErrors.ime = 'Required field';
    }
    if (!this.pripremikorisnik.prezime) {
      this.validationErrors.prezime = 'Required field';
    }
    if (!this.pripremikorisnik.email) {
      this.validationErrors.email = 'Required field';
    }
    if (!this.pripremikorisnik.brojMobitela) {
      this.validationErrors.brojMobitela = 'Required field';
    }
    if (!this.pripremikorisnik.gradId) {
      this.validationErrors.gradId = 'Required field';
    }
    if (!this.pripremikorisnik.lozinka) {
      this.validationErrors.lozinka = 'Required field';
    }
    if (this.pripremikorisnik.lozinka !== this.passwordprovjera) {
      this.validationErrors.passwordprovjera = 'Passwords do not match';
    }
    const fullMobileNumber = `+387${this.pripremikorisnik.brojMobitela}`;
    this.pripremikorisnik.brojMobitela = fullMobileNumber;

    // If no validation errors, proceed with registration
    if (Object.keys(this.validationErrors).length === 0) {
      this.novaRegistracijaEndpoint.obradi(this.pripremikorisnik!).subscribe((x) => {
        porukaSuccess("Successfully Registered");
        this.pripremikorisnik = null;
        this.router.navigate(['/home']);
      })
    }
  }

  validateMobileNumber(event: any): void {
    const input = event.target.value;
    event.target.value = input.replace(/\D/g, '');
    this.pripremikorisnik.brojMobitela = event.target.value;

    if (!event.target.value) {
      this.validationErrors.brojMobitela = 'Please enter a valid contact number';
    } else if (event.target.value.length < 8) {
      this.validationErrors.brojMobitela = 'Phone number is required';
    } else {
      this.validationErrors.brojMobitela = '';
    }
  }

  passwordCriteria = {
    minLength: false,
    upperCase: false,
  };

  validatePassword(password: string): void {
    this.passwordCriteria.minLength = password.length >= 8;
    this.passwordCriteria.upperCase = /[A-Z]/.test(password);

    if (this.passwordCriteria.minLength && this.passwordCriteria.upperCase) {
      this.validationErrors.lozinka = null;
    } else {
      this.validationErrors.lozinka = 'Password must be at least 8 characters long and contain at least one uppercase letter.';
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
