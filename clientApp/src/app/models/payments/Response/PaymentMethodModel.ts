import { PaymentMethodNames } from "../../Enums/PaymentMethodNames";
import { FieldModel } from "./FieldModel";

export interface PaymentMethodModel {
  id: string;
  name:PaymentMethodNames;
  fields: FieldModel[];
}
