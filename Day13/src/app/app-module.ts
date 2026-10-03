import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { EmployeeRegistration } from './employee-registration/employee-registration';
import { ReactiveRegistration } from './reactive-registration/reactive-registration';
import { ForbiddenName } from './forbidden-name';

@NgModule({
  declarations: [App, EmployeeRegistration, ReactiveRegistration, ForbiddenName],

  imports: [BrowserModule, AppRoutingModule, FormsModule, ReactiveFormsModule],

  providers: [provideBrowserGlobalErrorListeners()],

  bootstrap: [App],
})
export class AppModule {}
