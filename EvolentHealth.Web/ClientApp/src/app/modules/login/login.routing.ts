import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { LoginIndexComponent } from './components/login-index.component';

const routes: Routes = [
  {
    path: '',
    component: LoginIndexComponent,
  },
  {
    path: 'login',
    component: LoginIndexComponent,
  }
];

export const LoginRouting: ModuleWithProviders = RouterModule.forChild(routes);
