import { AlgoValidationNames } from "../../Enums/AlgoValidationNames";

export interface ValidatorModel {
  required:boolean;
  minLength?: number;
  maxLength?: number;
  pattern?: string;
  algorithmCheck?: AlgoValidationNames;
}
