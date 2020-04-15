import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactModel } from '../../../../models/contact.model';
import { ContactService } from '../../../../services/contact.service';

@Component({
  templateUrl: './contact-add.component.html',
})
export class ContactAddComponent {

  loginForm: FormGroup;
  isSubmitted = false;
  contact: ContactModel;
  constructor(private router: Router, private activatedRoute: ActivatedRoute,private formBuilder: FormBuilder, private _contactService: ContactService) { }

  ngOnInit() {


    this.activatedRoute.queryParams.subscribe(params => {
      const id = params['id'];
      const promise = new Promise((resolve, reject) => {
        let contact: ContactModel = {
          id: 0,
          email: '',
          firstName: '',
          lastName: '',
          phoneNumber: '',
          status: 1
        };

        if (id > 0) {

          this._contactService.getcontact(id).subscribe(x => {
            if (x != null && x.result != null) {
              resolve(x.result);
            }
            else {
              resolve(contact);

            }
          });

        }
        else {

          resolve(contact)
        }

      });

      promise.then((value: ContactModel) => {
        this.contact = value;
        this.loginForm = this.formBuilder.group({
          firstName: [value.firstName, Validators.required],
          lastName: [value.lastName, Validators.required],
          email: [value.email, Validators.required],
          phoneNumber: [value.phoneNumber, Validators.required],
          status: [value.status == 1]
        });
      });


    });

    
  }
  get f() { return this.loginForm.controls; }

  AddContact() {
    console.log(this.loginForm.value);
    this.isSubmitted = true;
    if (this.loginForm.invalid) {
      return;
    }

    let contact: ContactModel = {
      id: this.contact.id,
      email: this.f.email.value,
      firstName: this.f.firstName.value,
      lastName: this.f.lastName.value,
      phoneNumber: this.f.phoneNumber.value,
      status: this.f.status.value == true ? 1 : 0
    };

    if (this.contact.id > 0) {
      this._contactService.updateContact(contact).subscribe(x => {
        this.router.navigateByUrl('/contact');
      });
    }
    else {
      this._contactService.AddContact(contact).subscribe(x => {
        this.router.navigateByUrl('/contact');
      });
    }
  }
}
