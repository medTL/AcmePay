import { FieldTypes } from "../../Enums/FieldTypes";
import { ValidatorModel } from "./ValidatorModel";

export interface FieldModel {
  id: string;
  name:string;
  label:string;
  type: FieldTypes;
  placeHolder: string;
  validator: ValidatorModel;
}
