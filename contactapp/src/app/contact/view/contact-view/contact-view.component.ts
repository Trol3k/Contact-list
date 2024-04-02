import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../service/contact.service';
import { ContactDetails } from '../../model/contactDetails';
import { ActivatedRoute } from '@angular/router';
import { Contact } from '../../model/contact';

@Component({
  selector: 'app-contact-view',
  templateUrl: './contact-view.component.html',
  styleUrl: './contact-view.component.css'
})
export class ContactViewComponent implements OnInit {
  contact: ContactDetails | undefined;

  constructor(private contactService: ContactService, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.contactService.getContact(params['uuid'])
        .subscribe(contact => this.contact = contact)
    });
  }

  onDelete(contact: Contact): void {
    this.contactService.deleteContact(contact.id).subscribe(() => this.ngOnInit());
  }
}
