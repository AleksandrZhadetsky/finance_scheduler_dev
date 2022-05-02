import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { SignInRequest } from "src/app/models/identity/requests/signInRequest";
import { IdentityService } from "src/app/services/identity/identity.service";

@Component({
  selector: "app-login-dialog",
  templateUrl: "./login-dialog.component.html",
  styleUrls: ["./login-dialog.component.scss"],
})
export class LoginDialogComponent implements OnInit {
  public userNameValue = "";
  public password = "";
  public profileForm: FormGroup;
  public isLoginSucceeded = true;
  public errorMessage: string;

  constructor(
    public dialogRef: MatDialogRef<LoginDialogComponent>,
    private identityService: IdentityService,
    private router: Router,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onDialogClosing(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {
    this.profileForm = new FormGroup({
      userName: new FormControl(this.userNameValue, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(25),
      ]),
      password: new FormControl(this.password, [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(20),
      ]),
    });
  }

  public onLoginFormSubmit(): void {
    const request = new SignInRequest(
      this.profileForm.controls["userName"].value,
      this.profileForm.controls["password"].value
    );

    this.identityService.signIn(request).subscribe(
      (response) => {
        console.log(response);
        if (response.succeeded) {
          this.isLoginSucceeded = true;
          this.dialogRef.close();
          location.assign(`account/${response.user.id}`);
        } else {
          this.isLoginSucceeded = false;
          this.errorMessage = response.errors[0];
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
