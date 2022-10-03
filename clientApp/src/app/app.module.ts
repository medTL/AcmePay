import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { PaymentService } from './services/payment-service.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { ErrorInterceptor } from './services/error.interceptor';

export const interceptors = [
  {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
  },

];
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    ToastrModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

  ],
  providers: [PaymentService, ToastrService, interceptors],
  bootstrap: [AppComponent]
})
export class AppModule { }
