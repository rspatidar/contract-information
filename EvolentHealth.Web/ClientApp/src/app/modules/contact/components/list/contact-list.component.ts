import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ContactService } from '../../../../services/contact.service';
import { ContactModel } from '../../../../models/contact.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  templateUrl: './contact-list.component.html',
})
export class ContactListComponent {

  
  contactList: ContactModel[] = [];
  constructor(private router: Router, private _contactService: ContactService, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getContactList();
  }

  getContactList() {
    this._contactService.getcontactList().subscribe(x => {
      if (x != null && x.result != null) {
        this.contactList = x.result;
      }
    })
  }

  update(contact: ContactModel) {

  }

  delete(contact: ContactModel) {

    let bConfim = confirm("Are you sure to delete this contact?")
    if (bConfim) {
      this._contactService.deleteContact(contact.id).subscribe(x => {
        if (x == 1) {
          this.getContactList();
          this.openSnackBar("Contact deleted successfully", "Delete");
        }

      });
    }

  }

  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }

  
}
