import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ContactAddComponent } from './contact/view/contact-add/contact-add.component';
import { ContactEditComponent } from './contact/view/contact-edit/contact-edit.component';
import { ContactListComponent } from './contact/view/contact-list/contact-list.component';
import { ContactViewComponent } from './contact/view/contact-view/contact-view.component';
import { ContactService } from './contact/service/contact.service';
import { MainComponent } from './component/main/main.component';
import { FooterComponent } from './component/footer/footer.component';
import { HeaderComponent } from './component/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    ContactViewComponent,
    ContactAddComponent,
    ContactEditComponent,
    ContactListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    ContactService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
