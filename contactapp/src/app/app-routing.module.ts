import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactEditComponent } from './contact/view/contact-edit/contact-edit.component';
import { ContactViewComponent } from './contact/view/contact-view/contact-view.component';
import { ContactAddComponent } from './contact/view/contact-add/contact-add.component';
import { ContactListComponent } from './contact/view/contact-list/contact-list.component';

const routes: Routes = [
  {
    path: "",
    redirectTo: "contacts",
    pathMatch: 'full'
  },
  {
    component: ContactListComponent,
    path: "contacts"
  },
  {
    component: ContactAddComponent,
    path: "contacts/add"
  },
  {
    component: ContactViewComponent,
    path: "contacts/:uuid"
  },
  {
    component: ContactEditComponent,
    path: "contacts/:uuid/edit"
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
