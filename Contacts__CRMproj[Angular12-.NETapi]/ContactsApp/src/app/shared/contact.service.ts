import { Injectable } from '@angular/core';
import { Contact } from './contact.model';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'http://localhost:50994/api/Contacts';
  formData: Contact = new Contact();
  contacts: Contact[] = [];

  postContact() {
    return this.http.post(this.baseURL, this.formData);
  }

  putContact() {
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  delContact(id:number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

    
  getData(): Observable<Contact[]> {
    return this.http.get(this.baseURL)
      .pipe(map((data: any) => {
        let list = data;
        return list.map(function (c: any): Contact {
          return new Contact(c.Id, c.Name, c.MobilePhone, c.JobTitle, c.BirthDate);
        });
      }));
  }

  refreshList() {
    this.getData().subscribe(
      (data: Contact[]) => this.contacts = data);
  }
}

