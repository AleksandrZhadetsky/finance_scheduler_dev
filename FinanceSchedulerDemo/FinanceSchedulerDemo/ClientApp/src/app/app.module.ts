import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatDialogModule } from "@angular/material/dialog";
import { IdentityModule } from "./services/identity.module";
import { IdentityService } from "./services/identity/identity.service";
import { CommonModule } from "@angular/common";
import { AccountModule } from "./account/account.module";
import { TabsModule } from "./nav-menu/tabs/tabs.module";
import { PurchasesModule } from "./purchase-management/purchases.module";
import { DialogsModule } from "./dialogs/dialogs.module";

@NgModule({
  declarations: [AppComponent, NavMenuComponent, HomeComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    MatDialogModule,
    TabsModule,
    CommonModule,
    AccountModule,
    IdentityModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      // { path: 'account/:id', component: UserAccountPageComponent, pathMatch: 'full', canActivate: [AuthGuard] },
    ]),
    BrowserAnimationsModule,
    AccountModule,
    PurchasesModule,
    DialogsModule,
  ],
  providers: [IdentityService],
  bootstrap: [AppComponent],
})
export class AppModule {}
