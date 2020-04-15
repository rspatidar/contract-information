import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ContactAddComponent } from './components/add/contact-add.component';
import { ContactListComponent } from './components/list/contact-list.component';
import { ContactIndexComponent } from './components/contact-index.component';
import { ContactRouting } from './contact.routing';
import { CustomMaterialModule } from '../../custom-material.module';


@NgModule({
  declarations: [
    ContactAddComponent,
    ContactListComponent,
    ContactIndexComponent
  ],
  imports: [
    CustomMaterialModule,
    CommonModule,
    FormsModule,
    ContactRouting,
    ReactiveFormsModule
  ],
  providers: [],
 
})
export class ContactModule { }
