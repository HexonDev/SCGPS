import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private snackBar: MatSnackBar) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let errorCode: string = "0001";
    let errorMessage: string = "Unknown error!";

    return next.handle(request).pipe(
      catchError((err) => {
        console.log(err);
        if (err.status === 0) {
          errorCode = '0001';
          errorMessage = 'API is unreachable!';
        } else if (err.status == 404 && err.error?.status == 404) {
          errorCode = '404';
          errorMessage = 'API endpoint is unreachable!';
        } else if (err.error?.errorDescription || err.error?.errorCode) {
          errorCode = err.error.errorCode;
          errorMessage = err.error.errorDescription;
        } else {
          errorCode = '0001';
          errorMessage = 'Unknown error! (' + err.status + ')';
        }
 
        this.snackBar.open(`ERROR! ${errorCode} - ${errorMessage}`, "Ok");

        return throwError(() => err);
      })
    );
  }
}
