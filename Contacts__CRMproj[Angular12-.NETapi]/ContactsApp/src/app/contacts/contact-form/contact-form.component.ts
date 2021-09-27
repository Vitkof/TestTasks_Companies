import { Component, OnInit } from '@angular/core';
import { ContactService } from '../../shared/contact.service';
import { NgForm } from '@angular/forms';
import { Contact } from 'src/app/shared/contact.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styles: [
  ]
})
export class ContactFormComponent implements OnInit {

  constructor(public svc: ContactService,
              private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.svc.formData.id == 0)
      this.createRecord(form);
    else
      this.updateRecord(form);
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.svc.formData = new Contact();
  }

  createRecord(form: NgForm) {
    this.svc.postContact().subscribe(
      res => {
        this.resetForm(form);
        this.svc.refreshList();
        this.toastr.success('Created successfully', 'Contact Register');
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.svc.putContact().subscribe(
      res => {
        this.resetForm(form);
        this.svc.refreshList();
        this.toastr.success('Updated successfully', 'Contact Register');
      },
      err => { console.log(err); }
    );
  }
}
