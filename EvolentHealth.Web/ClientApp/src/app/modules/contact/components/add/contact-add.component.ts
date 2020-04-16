import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ContactModel } from '../../../../models/contact.model';
import { ContactService } from '../../../../services/contact.service';
import { MatSnackBar } from '@angular/material';

@Component({
  templateUrl: './contact-add.component.html',
})
export class ContactAddComponent {

  loginForm: FormGroup;
  isSubmitted = false;
  contact: ContactModel;
  constructor(private router: Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,
    private _contactService: ContactService, private _snackBar: MatSnackBar) { }

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
          },
            () => (resolve(contact))
          );
         

        }
        else {

          resolve(contact)
        }

      });

      promise.then((value: ContactModel) => {
        this.contact = value;
        this.loginForm = this.formBuilder.group({
          firstName: [value.firstName, [Validators.required, this.noWhitespaceValidator]],
          lastName: [value.lastName, [Validators.required, this.noWhitespaceValidator]],
          email: [value.email, [Validators.required, Validators.email]],
          phoneNumber: [value.phoneNumber,[ Validators.required, Validators.pattern("^[0-9]{10}$")]],
          status: [value.status == 1]
        });
      });


    });

    
  }

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
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
      email: this.f.email.value.trim(),
      firstName: this.f.firstName.value.trim(),
      lastName: this.f.lastName.value.trim(),
      phoneNumber: this.f.phoneNumber.value.trim(),
      status: this.f.status.value == true ? 1 : 0
    };

    if (this.contact.id > 0) {
      this._contactService.updateContact(contact).subscribe(x => {
        if (x != null) {
          this.openSnackBar("contact information updated sucessfully", "Update");
          this.router.navigateByUrl('/contact');
        }
        
      },
        () => {
          alert("Application facing some problem while updating contact information, please try again later")
        }
      );
    }
    else {
      this._contactService.AddContact(contact).subscribe(x => {
        if (x != null) {
          this.openSnackBar("contact information added sucessfully", "Add");
          this.router.navigateByUrl('/contact');
        }
      },
        () => {
          alert("application facing some problem while adding contact information, please try again later")
        });
    }
  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
}
