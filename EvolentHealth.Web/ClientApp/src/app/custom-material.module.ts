
import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import {
  MatButtonModule, MatCardModule, MatInputModule, MatIconModule, MatSnackBarModule,  MatCheckboxModule, MAT_SNACK_BAR_DEFAULT_OPTIONS
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatSnackBarModule
  ],
  exports: [
    CommonModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatSnackBarModule
  ],
  providers: [
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: { duration: 2500, verticalPosition: 'top' } }
  ]
})
export class CustomMaterialModule { }
