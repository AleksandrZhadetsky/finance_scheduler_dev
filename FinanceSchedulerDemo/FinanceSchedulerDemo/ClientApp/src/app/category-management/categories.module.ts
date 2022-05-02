import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CreateCategoryComponent } from "./create-category/create-category.component";
import { FormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSelectModule } from "@angular/material/select";

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
