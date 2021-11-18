import { NgModule } from '@angular/core';
import { IdentityService } from './identity/identity.service';
import { TokenStorage } from './token-storage/token-storage.service';
import { AuthGuard } from './identity/auth-guard/auth-guard';
import { RouterModule } from '@angular/router';
import { UserAccountPageComponent } from '../account/user-account-page/user-account-page.component';
import { UnauthorizedComponent } from '../error-pages/unauthorized/unauthorized.component';
import { ForbiddenComponent } from '../error-pages/forbidden/forbidden.component';

export function factory(authenticationService: IdentityService) {
  return authenticationService;
}

@NgModule({
    imports:[
      RouterModule.forRoot([
        { path: 'account/:id', component: UserAccountPageComponent, pathMatch: 'full', canActivate: [AuthGuard] },
        { path: 'unauthorized', component: UnauthorizedComponent, pathMatch: 'full' },
        { path: 'forbidden', component: ForbiddenComponent, pathMatch: 'full' },
      ]),
    ],
    providers: [
      TokenStorage,
      IdentityService,
      {
        provide: IdentityService,
        useFactory: factory
      },
      AuthGuard
    ],
    declarations: []
})
export class IdentityModule {

}
