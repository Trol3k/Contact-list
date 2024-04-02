import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../service/contact.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-add',
  templateUrl: './contact-add.component.html',
  styleUrl: './contact-add.component.css'
})
export class ContactAddComponent implements OnInit {
  uuid: string | undefined;
  contact: {
    firstName: string,
    lastName: string,
    email: string,
    password: string,
    category: string,
    subcategory: string,
    phoneNumber: string,
    birthDate: string
  } | undefined;

  constructor(private contactService: ContactService, private router: Router) {
  }

  ngOnInit() {
    this.uuid = crypto.randomUUID();
    this.contact = {
      firstName: "",
      lastName: "",
      email: "",
      password: "",
      category: "",
      subcategory: "",
      phoneNumber: "",
      birthDate: ""
    }
  }

  onSubmit(): void {
    this.contactService.putContact(this.uuid!, this.contact!)
      .subscribe(() => this.router.navigate((['/contacts'])));
  }

}
