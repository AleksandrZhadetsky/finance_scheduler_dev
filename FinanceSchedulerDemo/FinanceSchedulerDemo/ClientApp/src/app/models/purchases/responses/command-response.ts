import { PurchaseModel } from '../purchase-model';

export class CommandResponse {
  constructor(
    public responseModel: PurchaseModel,
    public responseMessage: string,
  ) {}
}
