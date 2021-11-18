import { Component, OnInit } from "@angular/core";
import { CategoryModel } from "src/app/models/categories/category-model";
import { PurchaseCreationModel } from "src/app/models/purchases/purchase-creation-model";
import { PurchaseManagementService } from "src/app/services/purchase-management/purchase-management.service";
import { AppStateService } from "src/app/state/app-state.service";

@Component({
  selector: "app-create-purchase",
  templateUrl: "./create-purchase.component.html",
  styleUrls: ["./create-purchase.component.scss"],
})
export class CreatePurchaseComponent implements OnInit {
  public categories: CategoryModel;
  public submitBtnDisabled: boolean;
  public purchaseName: string;
  public purchaseCost: number;
  public itemsCount: number;

  constructor(
    private service: PurchaseManagementService,
    private store: AppStateService
  ) {}

  ngOnInit(): void {}

  public onPurchaseCreationTriggered(): void {
    this.service
      .registerPurchase(
        new PurchaseCreationModel(
          this.purchaseName,
          this.purchaseCost,
          this.itemsCount
        )
      )
      .subscribe();
  }
}
