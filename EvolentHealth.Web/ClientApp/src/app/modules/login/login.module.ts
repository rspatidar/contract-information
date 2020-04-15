import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoginIndexComponent } from './components/login-index.component';
import { LoginRouting } from './login.routing';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    LoginIndexComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    LoginRouting,
    ReactiveFormsModule
  ],
  providers: [],
 
})
export class LoginModule { }
