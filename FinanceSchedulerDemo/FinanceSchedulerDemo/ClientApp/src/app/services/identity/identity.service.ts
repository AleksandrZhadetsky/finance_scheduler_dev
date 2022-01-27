import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, throwError } from "rxjs";
import { catchError, map, tap } from "rxjs/operators";
import { SignInRequest } from "src/app/models/identity/requests/signInRequest";
import { SignUpRequest } from "src/app/models/identity/requests/signUpRequest";
import { IdentityResponse } from "src/app/models/identity/responses/identityResponse";
import { IdentityUser } from "src/app/models/identity/user/identityUser";
import { environment } from "src/environments/environment";
import { TokenStorage } from "../token-storage/token-storage.service";

@Injectable({
  providedIn: "root",
})
export class IdentityService {
  private readonly controller = "identity";
  private readonly signUpAction = "sign-up";
  private readonly signInAction = "sign-in";
  private readonly getEnvironmentAction = "environment";

  private userSubject: BehaviorSubject<IdentityUser>;

  public user: Observable<IdentityUser>;
  public currentEnvironment$: Observable<string>;

  constructor(
    private httpClient: HttpClient,
    private tokenStorage: TokenStorage
  ) {
    this.userSubject = new BehaviorSubject<IdentityUser>(
      JSON.parse(localStorage.getItem("user"))
    );

    this.user = this.userSubject.asObservable();
    this.currentEnvironment$ = this.httpClient
      .get<string>(
        `${environment.apiUrl}/${this.controller}/${this.getEnvironmentAction}`
      )
      .pipe();
  }

  public get userValue(): IdentityUser {
    return this.userSubject.value;
  }

  public isAuthorized(): Observable<boolean> {
    return this.tokenStorage.getAccessToken().pipe(map((token) => !!token));
  }

  public getAccessToken(): Observable<string> {
    return this.tokenStorage.getAccessToken();
  }

  public signUp(request: SignUpRequest): Observable<IdentityResponse> {
    return this.httpClient
      .post<IdentityResponse>(
        `${environment.apiUrl}/${this.controller}/${this.signUpAction}`,
        request
      )
      .pipe(
        tap((response) => {
          if (response.succeeded) {
            this.saveAccessData(response.token);
            localStorage.setItem("user", JSON.stringify(response.user));
            this.userSubject = new BehaviorSubject<any>(
              JSON.parse(localStorage.getItem("user"))
            );
          }
        }),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }

  public signIn(request: SignInRequest): Observable<IdentityResponse> {
    return this.httpClient
      .post<IdentityResponse>(
        `${environment.apiUrl}/${this.controller}/${this.signInAction}`,
        request
      )
      .pipe(
        tap((response) => {
          if (response.succeeded) {
            this.saveAccessData(response.token);
            localStorage.setItem("user", JSON.stringify(response.user));
            this.userSubject = new BehaviorSubject<any>(
              JSON.parse(localStorage.getItem("user"))
            );
          }
        }),
        catchError((error) => {
          console.log("error caught in service");
          console.error(error);

          return throwError(error); // Rethrow it back to component
        })
      );
  }

  public logout(): void {
    this.tokenStorage.clear();
    localStorage.removeItem("user");
    this.userSubject.next(null);
    location.reload();
  }

  private saveAccessData(accessToken) {
    this.tokenStorage.setAccessToken(accessToken);
  }
}
