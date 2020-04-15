
import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import {
  MatButtonModule, MatCardModule,  MatInputModule,  MatIconModule, MatProgressSpinnerModule,  MatCheckboxModule
} from '@angular/material';
@NgModule({
  imports: [
    CommonModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  exports: [
    CommonModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
})
export class CustomMaterialModule { }
