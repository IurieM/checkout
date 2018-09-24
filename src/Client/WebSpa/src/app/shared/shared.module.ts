import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './interceptors/token-interceptor';
import { ErrorInterceptor } from './interceptors/error-interceptor';
import { MaterialModule } from '../material.module';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth-guard.service';
import { AlertService } from './services/alert-service';
import { ShowErrorComponent } from './components/show-error.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    AuthService,
    AuthGuard,
    AlertService
  ],
  declarations: [ShowErrorComponent],
  exports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    ShowErrorComponent
  ]
})
export class SharedModule { }
