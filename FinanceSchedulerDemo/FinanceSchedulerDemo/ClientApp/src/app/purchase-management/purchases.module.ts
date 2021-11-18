import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CreatePurchaseComponent } from "./create-purchase/create-purchase.component";
import { PurchaseListComponent } from "./purchase-list/purchase-list.component";
import { FormsModule } from "@angular/forms";
import {
  MatFormFieldModule,
  MatInputModule,
  MatLabel,
  MatSelectModule,
} from "@angular/material";

@NgModule({
  declarations: [CreatePurchaseComponent, PurchaseListComponent],
  exports: [CreatePurchaseComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
  ],
})
export class PurchasesModule {}
