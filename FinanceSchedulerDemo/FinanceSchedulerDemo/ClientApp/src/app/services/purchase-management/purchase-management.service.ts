import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { tap, catchError } from "rxjs/operators";
import { DeleteCommand } from "src/app/models/common/delete-command";
import { PurchaseCreationModel } from "src/app/models/purchases/purchase-creation-model";
import { CommandResponse } from "src/app/models/purchases/responses/command-response";
import { AppStateService } from "src/app/state/app-state.service";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: "root",
})
export class PurchaseManagementService {
  private readonly controller = "purchases";
  private readonly createAction = "create";
  private readonly deleteAction = "delete";

  constructor(private httpClient: HttpClient, private store: AppStateService) {}

  public registerPurchase(
    purchase: PurchaseCreationModel
  ): Observable<CommandResponse> {
    return this.httpClient
      .post<CommandResponse>(
        `${environment.apiUrl}/${this.controller}/${this.createAction}`,
        purchase
      )
      .pipe(
        tap((response) => {
          if (!!response.responseModel) {
            this.store.purchases.push(response.responseModel);
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
