import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LoginDialogComponent } from "./login-dialog/login-dialog.component";
import { RegistrationDialogComponent } from "./registration-dialog/registration-dialog.component";
import {
  MatCardModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
} from "@angular/material";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [RegistrationDialogComponent, LoginDialogComponent],
  exports: [RegistrationDialogComponent, LoginDialogComponent],
  imports: [
    CommonModule,
    MatCardModule,
    MatExpansionModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
})
export class DialogsModule {}
