import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  constructor() { }

  handleError(error: any) {

    let errorMessage = 'An error occurred';

    if (error instanceof HttpErrorResponse) {
      if (error.error instanceof ErrorEvent) {
        // Client-side error
        errorMessage = `Client-side error: ${error.error.message}`;
      } else if (error.status >= 400 && error.status < 500) {
        // Server-side error with HTTP status code 4xx
        errorMessage = this.extractErrorMessage(error.error) || `Unknown client error (${error.status}) occurred`;
      } else if (error.status >= 500 && error.status < 600) {
        // Server-side error with HTTP status code 5xx
        errorMessage = this.extractErrorMessage(error.error) || `Unknown server error (${error.status}) occurred`;
      } else {
        // Other types of HTTP errors
        errorMessage = `HTTP error (${error.status}): ${error.message || 'Unknown HTTP error occurred'}`;
      }
    } else {
      // Other types of errors
      errorMessage = `Unknown error occurred: ${error.message || 'No error message available'}`;
    }

    console.error(errorMessage);
    return throwError(errorMessage);
  }

  private extractErrorMessage(error: any): string {
    if (typeof error === 'string') {
      return error;
    } else if (error && error.Message) {
      return error.Message;
    } else {
      return '';
    }
  }
}
