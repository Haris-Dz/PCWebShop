import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MojConfig } from '../../moj-config';

@Injectable({ providedIn: 'root' })
export class NovaRegistracijaEndpoint {
  constructor(public httpClient: HttpClient) {}

  obradi(request: RegistracijaRequest): Observable<number> {
    const url = MojConfig.adresa_servera + `/registracija/nova`;

    return this.httpClient.post<number>(url, request).pipe(
      catchError((error) => {
        // Extract error message from the response
        let errorMessage = 'Unexpected error occurred';
        if (error.error?.message) {
          errorMessage = error.error.message; // JSON response with a "message" field
        } else if (typeof error.error === 'string') {
          errorMessage = error.error; // Plain text response
        }
        return throwError(() => new Error(errorMessage));
      })
    );
  }
}

export interface RegistracijaRequest {
  korisnickoIme: string;
  lozinka: string;
  slika_base64_format: string;
  ime: string;
  prezime: string;
  email: string;
  brojMobitela: string;
  gradId: number;
}
