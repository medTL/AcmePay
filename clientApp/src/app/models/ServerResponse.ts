export interface ServerResponse<T> {
  data: T;
  error: string;
  message: string;
}
