import { Component, OnInit } from "@angular/core";
import { IdentityUser } from "../../models/identity/user/identityUser";
import { IdentityService } from "../../services/identity/identity.service";

@Component({
  templateUrl: "./user-account-page.component.html",
  styleUrls: ["./user-account-page.component.scss"],
})
export class UserAccountPageComponent implements OnInit {
  public readonly user: IdentityUser;
  public panelOpenState = false;

  constructor(private identityService: IdentityService) {
    this.user = identityService.userValue;
  }

  ngOnInit() {}
}
