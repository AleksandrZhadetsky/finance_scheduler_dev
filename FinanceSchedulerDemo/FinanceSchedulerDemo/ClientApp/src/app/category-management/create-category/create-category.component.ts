import { Component, OnInit } from "@angular/core";
import { CategoryCreationModel } from "src/app/models/categories/category-creation-model";
import { CategoryManagementService } from "src/app/services/category-management/category-management.service";
import { AppStateService } from "src/app/state/app-state.service";

@Component({
  selector: "app-create-category",
  templateUrl: "./create-category.component.html",
  styleUrls: ["./create-category.component.scss"],
})
export class CreateCategoryComponent implements OnInit {
  public categoryName = "";
  public categoryDescription = "";

  constructor(
    private service: CategoryManagementService,
    private store: AppStateService
  ) {}

  ngOnInit(): void {}

  public onCategoryCreationTriggered(): void {
    this.service
      .registerCategory(
        new CategoryCreationModel(this.categoryName, this.categoryDescription)
      )
      .subscribe();
  }
}
