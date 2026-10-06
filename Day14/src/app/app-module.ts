import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import {
  provideHttpClient,
  withInterceptors
} from '@angular/common/http';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';

import { EmployeeList } from './employee-list/employee-list';

import { loggingInterceptor } from './interceptors/logging-interceptor';

@NgModule({
  declarations: [
    App,
    EmployeeList
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],

  providers: [
    provideBrowserGlobalErrorListeners(),

    provideHttpClient(
      withInterceptors([
        loggingInterceptor
      ])
    )
  ],

  bootstrap: [
    App
  ]
})
export class AppModule { }
