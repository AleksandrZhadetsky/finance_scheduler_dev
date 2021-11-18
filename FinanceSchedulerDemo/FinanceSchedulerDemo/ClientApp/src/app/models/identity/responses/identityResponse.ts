import { IdentityUser } from "../user/identityUser";

export class IdentityResponse {
  constructor(
    public user: IdentityUser,
    public token: string,
    public succeeded: boolean,
    public errors: string[]
  ) {}
}
