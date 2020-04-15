import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { ContactListComponent } from './components/list/contact-list.component';
import { ContactAddComponent } from './components/add/contact-add.component';

const routes: Routes = [
  {
    path: '',
    component: ContactListComponent,
  },
  {
    path: 'add',
    component: ContactAddComponent,
  }
  ,
  {
    path: 'update',
    component: ContactAddComponent,
  }
];

export const ContactRouting: ModuleWithProviders = RouterModule.forChild(routes);
