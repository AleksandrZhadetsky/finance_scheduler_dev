import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { CategoryModel } from "../models/categories/category-model";
import { PurchaseModel } from "../models/purchases/purchase-model";

@Injectable({
  providedIn: "root",
})
export class AppStateService {
  private readonly _purchases = new BehaviorSubject<PurchaseModel[]>([]);
  private readonly _categories = new BehaviorSubject<CategoryModel[]>([]);

  public readonly purchases$ = this._purchases.asObservable();
  public readonly categories$ = this._categories.asObservable();

  constructor() {}

  get purchases(): PurchaseModel[] {
    return this._purchases.getValue();
  }

  set purchases(val: PurchaseModel[]) {
    this._purchases.next(val);
  }

  get categories(): CategoryModel[] {
    return this._categories.getValue();
  }

  set categories(val: CategoryModel[]) {
    this._categories.next(val);
  }
}
