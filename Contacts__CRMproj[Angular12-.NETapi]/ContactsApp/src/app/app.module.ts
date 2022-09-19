import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { ContactsComponent } from './contacts/contacts.component';
import { ContactFormComponent } from './contacts/contact-form/contact-form.component';
import { HttpClientModule } from '@angular/common/http';
import { PhoneNumberValidatorDirective } from './phone-number-validator.directive';
import { NameValidatorDirective } from './name-validator.directive';

@NgModule({
  declarations: [
    AppComponent,
    ContactsComponent,
    ContactFormComponent,
    PhoneNumberValidatorDirective,
    NameValidatorDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
