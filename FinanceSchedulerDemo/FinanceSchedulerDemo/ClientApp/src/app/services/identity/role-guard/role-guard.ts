import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IdentityService } from '../identity.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {

  constructor(
    private service: IdentityService,
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> {
    let role = !!this.service.userValue ? null : this.service.userValue.role;

    // if (!this.service.isAuthorized() || role === null || role !== environment.adminRole) {
    //   this.router.navigate(['forbidden']);

    //   return false;
    // }

    return true;
  }
}
