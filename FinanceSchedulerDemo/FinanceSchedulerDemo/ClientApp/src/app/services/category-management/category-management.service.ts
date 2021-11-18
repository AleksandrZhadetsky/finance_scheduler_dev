import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { CategoryCreationModel } from "src/app/models/categories/category-creation-model";
import { CommandResponse } from "src/app/models/categories/responses/command-response";
import { DeleteCommand } from "src/app/models/common/delete-command";
import { AppStateService } from "src/app/state/app-state.service";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class CategoryManagementService {
  private readonly controller = "categories";
  private readonly createAction = "create";
  private readonly deleteAction = "delete";

  constructor(private httpClient: HttpClient, private store: AppStateService) {}

  public registerCategory(
    purchase: CategoryCreationModel
  ): Observable<CommandResponse> {
    return this.httpClient
      .post<CommandResponse>(
        `${environment.apiUrl}/${this.controller}/${this.createAction}`,
        purchase
      )
      .pipe(
        tap((response) => {
          if (!!response.responseModel) {
            this.store.categories.push(response.responseModel);
          }
        }),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }

  public deletePurchase(id: string): Observable<CommandResponse> {
    return this.httpClient
      .post<CommandResponse>(
        `${environment.apiUrl}/${this.controller}/${this.deleteAction}`,
        new DeleteCommand(id)
      )
      .pipe(
        tap((response) => {}),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }
}
