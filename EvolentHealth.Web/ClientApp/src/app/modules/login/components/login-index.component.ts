import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  templateUrl: './login-index.component.html',
  styleUrls: ['./login-index.component.css']
})
export class LoginIndexComponent {

  loginForm: FormGroup;
  isSubmitted = false;

  constructor( private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
  get f() { return this.loginForm.controls; }

  login() {
    console.log(this.loginForm.value);
    this.isSubmitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    //this.authService.login(this.loginForm.value);
    this.router.navigateByUrl('/contact');
  }
}
