import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginTabComponent } from './login-tab/login-tab.component';
import { RegistrationTabComponent } from './registration-tab/registration-tab.component';
import { DialogHandlerComponent } from '../../dialog-handlers/sign-in-sign-up-handler/dialog-handler.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    LoginTabComponent,
    RegistrationTabComponent,
    DialogHandlerComponent
  ],
  exports: [
    DialogHandlerComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class TabsModule { }
