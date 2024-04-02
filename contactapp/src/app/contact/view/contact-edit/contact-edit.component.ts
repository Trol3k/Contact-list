import { Component, OnInit } from '@angular/core';
import { ContactForm } from '../../model/contactForm';
import { ContactService } from '../../service/contact.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrl: './contact-edit.component.css'
})
export class ContactEditComponent implements OnInit {
  uuid: string | undefined;
  contact: ContactForm | undefined;
  original: ContactForm | undefined

  constructor(
    private contactService: ContactService,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.contactService.getContact(params['uuid'])
        .subscribe(contact => {
          this.uuid = contact.id;
          this.contact = {
            firstName: contact.firstName,
            lastName: contact.lastName,
            email: contact.email,
            password: contact.password,
            category: contact.category,
            subcategory: contact.subcategory,
            phoneNumber: contact.phoneNumber,
            birthDate: contact.birthDate
          };
          this.original = { ...this.contact };
        });
    });
  }

  onSubmit(): void {
    this.contactService.putContact(this.uuid!, this.contact!)
      .subscribe(() => this.router.navigate((['/contacts'])));
  }
}