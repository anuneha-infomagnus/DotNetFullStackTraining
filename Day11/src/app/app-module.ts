import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { EmployeeList } from './employee-list/employee-list';
import { EmployeeSummary } from './employee-summary/employee-summary';

@NgModule({
  declarations: [App, EmployeeList, EmployeeSummary],
  imports: [BrowserModule, AppRoutingModule],
  providers: [provideBrowserGlobalErrorListeners()],
  bootstrap: [App],
})
export class AppModule {}
