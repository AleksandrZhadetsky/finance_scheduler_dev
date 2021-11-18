import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { IdentityService } from '../services/identity/identity.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent {
  public isExpanded = false;
  public isAuthenticated: boolean;

  public constructor(
    private service: IdentityService,
    private router: Router
  ) {
    service.isAuthorized()
      .subscribe(
        res => this.isAuthenticated = res
      );
  }

  public showAccount() {
    const userId = this.service.userValue.id;
    this.router.navigateByUrl(`account/${userId}`);
  }

  public collapse(): void {
    this.isExpanded = false;
  }

  public toggle(): void {
    this.isExpanded = !this.isExpanded;
  }

  public logout(): void {
    this.service.logout();
  }
}
