import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ContactDetails } from '../model/contactDetails';
import { ContactForm } from '../model/contactForm';
import { Observable } from 'rxjs';
import { Contact } from '../model/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) {
  }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>('/api/contact');
  }

  getContact(uuid: string): Observable<ContactDetails> {
      return this.http.get<ContactDetails>('/api/contact/' + uuid);
  }

  deleteContact(uuid: string): Observable<any> {
      return this.http.delete('/api/contact/' + uuid);
  }

  putContact(uuid: string, request: ContactForm): Observable<any> {
      return this.http.put('/api/contact/' + uuid, request)
  }
}
