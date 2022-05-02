import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LoginDialogComponent } from "./login-dialog/login-dialog.component";
import { RegistrationDialogComponent } from "./registration-dialog/registration-dialog.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatCardModule } from "@angular/material/card";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";

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
