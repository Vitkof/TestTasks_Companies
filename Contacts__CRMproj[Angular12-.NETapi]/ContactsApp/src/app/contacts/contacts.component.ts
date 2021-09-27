import { Component, OnInit } from '@angular/core';
import { ContactService } from '../shared/contact.service';
import { Contact } from '../shared/contact.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: [ './contacts.component.css'
  ]
})
export class ContactsComponent implements OnInit {

  constructor(public svc: ContactService,
              private toastr:ToastrService) { }

  ngOnInit(): void {
    this.getContacts();
  }

 
  getContacts() {
    this.svc.refreshList();
  }

  fillForm(selRecord: Contact) {
    this.svc.formData = Object.assign({}, selRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.svc.delContact(id).subscribe(
        res => {
          this.getContacts();
          this.toastr.warning('Deleted successfully', 'Contact Register');
        },
        err => { console.log(err); }
      );
    }
  }
}
