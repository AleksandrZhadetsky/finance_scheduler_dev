import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginDialogComponent } from 'src/app/dialogs/login-dialog/login-dialog.component';
import { RegistrationDialogComponent } from 'src/app/dialogs/registration-dialog/registration-dialog.component';

@Component({
  selector: 'app-auth-handler',
  templateUrl: './dialog-handler.component.html',
  styleUrls: ['./dialog-handler.component.scss']
})
export class DialogHandlerComponent implements OnInit {
  private formData: any;

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  public openRegistrationDialog() {
    const dialogRef = this.dialog.open(RegistrationDialogComponent, {
      maxWidth: '50vw',
      maxHeight: '60vh',
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.formData = result;
    });
  }

  public openLoginDialog() {
    const dialogRef = this.dialog.open(LoginDialogComponent, {
      maxWidth: '50vw',
      maxHeight: '60vh',
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      this.formData = result;
    });
  }
}
