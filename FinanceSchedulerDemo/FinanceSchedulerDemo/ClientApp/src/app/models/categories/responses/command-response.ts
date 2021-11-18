import { CategoryModel } from "../category-model";

export class CommandResponse {
  constructor(
    public responseModel: CategoryModel,
    public responseMessage: string
  ) {}
}
