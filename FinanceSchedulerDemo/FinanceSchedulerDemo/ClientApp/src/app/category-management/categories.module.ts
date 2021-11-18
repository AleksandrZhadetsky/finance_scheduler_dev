import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CreateCategoryComponent } from "./create-category/create-category.component";
import { FormsModule } from "@angular/forms";
import {
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
} from "@angular/material";

@NgModule({
  declarations: [CreateCategoryComponent],
  exports: [CreateCategoryComponent],
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
  ],
})
export class CategoriesModule {}
