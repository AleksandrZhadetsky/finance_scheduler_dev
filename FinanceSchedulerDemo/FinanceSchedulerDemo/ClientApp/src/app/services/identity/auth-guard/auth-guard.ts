import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";
import { Observable } from "rxjs";
import { IdentityService } from "../identity.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private service: IdentityService,
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    this.service.isAuthorized()
    .subscribe(
      res => {
        if (!res) {
          this.router.navigate(['unauthorized']);

          return false;
        }
      }
    );

    return true;
  }
}
