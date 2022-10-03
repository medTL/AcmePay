import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { AcmeError } from '../models/Enums/AcmeErros';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor( private toast: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        switch (error.status) {
          case 400:
            switch(error.error.error)
            {
              case AcmeError.INVALID_DATA:
                this.ToastHandler("Invalid data");
                break;

                case AcmeError.PAYMENT_METHOD_NOT_FOUND:
                  this.ToastHandler("This payment method does not exist");
                  break;

                  case AcmeError.PAYMENT_NOT_FOUND:
                    this.ToastHandler("Payment not found");
                    break;
                    default :
                    break;
            }
            return throwError(error);
            case 500:
              this.ToastHandler("Ops!, something went wrong please try again later");
              return throwError(error);
        }
        return throwError(() => error);
      })
    );
  }

   /**
   * Toast handler
   * @param error
   */
    ToastHandler(error: string): void {
        this.toast.error(
         error, "ERROR!"
        );
    }
}
