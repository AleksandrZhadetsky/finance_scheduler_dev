import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { UserAccountPageComponent } from "./user-account-page/user-account-page.component";
import { PurchasesModule } from "../purchase-management/purchases.module";
import { MatCardModule } from "@angular/material/card";
import { MatExpansionModule } from "@angular/material/expansion";
import { CategoriesModule } from "../category-management/categories.module";

@NgModule({
  declarations: [UserAccountPageComponent],
  imports: [
    CommonModule,
    PurchasesModule,
    CategoriesModule,
    MatCardModule,
    MatExpansionModule,
  ],
})
export class AccountModule {}
