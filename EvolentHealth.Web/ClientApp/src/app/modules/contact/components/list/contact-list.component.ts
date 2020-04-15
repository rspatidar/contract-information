import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ContactService } from '../../../../services/contact.service';
import { ContactModel } from '../../../../models/contact.model';

@Component({
  templateUrl: './contact-list.component.html',
})
export class ContactListComponent {

  
  contactList: ContactModel[] = [];
  constructor(private router: Router, private _contactService: ContactService) { }

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
  
}
