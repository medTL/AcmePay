export interface ValidatorModel {
  required:boolean;
  minLength?: number;
  maxLength?: number;
  pattern?: string;
}
