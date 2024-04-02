import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../service/contact.service';
import { Contact } from '../../model/contact';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent implements OnInit {
  contacts: Contact[] | undefined;

  constructor(private contactService: ContactService) {
  }

  ngOnInit() {
    this.contactService.getContacts().subscribe({ next: (contacts) => this.contacts = contacts });
  }

}
